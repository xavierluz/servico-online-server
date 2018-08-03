using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicoOnlineBusiness.factory;
using ServicoOnlineBusiness.tiposervico.abstracts;
using ServicoOnlineBusiness.tiposervico.dominio.interfaces;
using ServicoOnlineServer.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServicoOnlineServer.Controllers
{
    [Produces("application/json")]
    [Route("api/TipoServico")]
    [ApiController]
    public class TipoServicoController : Controller
    {
        private ServicoFactory servicoFactory = null;
        private IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted;
        private IHostingEnvironment _hostingEnvironment;
        public TipoServicoController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet(Name = "GetTipos")]
        public async Task<ActionResult<IEnumerable<ITipoServicoDominio>>> Gets()
        {
            servicoFactory = ServicoFactory.Create(this.isolationLevel);
            TipoServicoAbstract tipoServico = servicoFactory.getTipoServico();
            List<ITipoServicoDominio> tiposServicos = await tipoServico.GetsAsync();

            return Json(tiposServicos.ToList());
        }
        [HttpPost(Name = "Upload")]
        [Route("Upload")]
        public async Task Upload(IFormFile file)
        {
            if (file == null) throw new Exception("File is null");
            if (file.Length == 0) throw new Exception("File is empty");

            using (Stream stream = file.OpenReadStream())
            {
                using (var binaryReader = new BinaryReader(stream))
                {
                    var fileContent = binaryReader.ReadBytes((int)file.Length);
                    //await _uploadService.AddFile(fileContent, file.FileName, file.ContentType);
                }
            }
        }
        [Route("PostTipoServico")]
        [HttpPost(Name = "PostTipoServico"), DisableRequestSizeLimit]
        public ActionResult UploadFile()
        {
            try
            {
                var file = Request.Form.Files[0];
                string folderName = "Upload";
                string webRootPath = _hostingEnvironment.WebRootPath;
                string newPath = Path.Combine(webRootPath, folderName);
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                if (file.Length > 0)
                {
                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                return Json("Upload Successful.");
            }
            catch (System.Exception ex)
            {
                return Json("Upload Failed: " + ex.Message);
            }
        }
    
        [HttpPost(Name = "PostTipos")]
        public async Task<ActionResult<IEnumerable<ITipoServicoDominio>>> GetsAdmin()
        {
            string search = Request.Form["search[value]"].ToString();
            string draw = Request.Form["draw"].ToString();
            string order = Request.Form["order[0][column]"].ToString();
            string orderDir = Request.Form["order[0][dir]"].ToString();
            int startRec = Convert.ToInt32(Request.Form["start"].ToString());
            int pageSize = Convert.ToInt32(Request.Form["length"].ToString());

            servicoFactory = ServicoFactory.Create(this.isolationLevel);
            TipoServicoAbstract tipoServico = servicoFactory.getTipoServicoAdmin("ffffff");
            List<ITipoServicoDominio> tiposServicos = await tipoServico.Gets(startRec, search, pageSize);

            return tiposServicos.ToList();
        }
        [Produces(typeof(ITipoServicoDominio))]
        [HttpGet("{Id}", Name = "GetTipo")]
        public ActionResult<ITipoServicoDominio> Get(int Id)
        {
            servicoFactory = ServicoFactory.Create(this.isolationLevel);
            TipoServicoAbstract tipoServico = servicoFactory.getTipoServico();
            ITipoServicoDominio tiposServicos = tipoServico.Get(Id);

            return Ok(tiposServicos);
        }
      


       
    }
}
