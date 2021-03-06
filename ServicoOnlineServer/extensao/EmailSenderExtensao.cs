﻿using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace ServicoOnlineServer.extensao
{
    public static class EmailSenderExtensao
    {
        public static Task SendEmailConfirmacaoAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Confirme o email",
                $"Por favor, clique no link para confiormar o email: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }
    }
}
