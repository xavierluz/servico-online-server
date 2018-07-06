using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoOnlineBusiness.bases.repositorio
{
    internal class RepositorioBase<T> : IDisposable where T : class
    {
        internal DbContext Contexto = null;
        protected StringBuilder exceptionBuilder = null;
        protected IQueryable<T> Queryable = null;
        protected IsolationLevel isolationLevel = IsolationLevel.Unspecified;

        protected RepositorioBase(IsolationLevel isolationLevel)
        {
            this.isolationLevel = isolationLevel;
        }

        protected void configurarContextoPerformance()
        {
            this.Contexto.ChangeTracker.AutoDetectChangesEnabled = false;
            this.Contexto.ChangeTracker.LazyLoadingEnabled = false;
            this.Contexto.Database.AutoTransactionsEnabled = false;
          
        }
        protected void configurarContextoPadrao()
        {
            this.Contexto.ChangeTracker.AutoDetectChangesEnabled = true;
            this.Contexto.ChangeTracker.LazyLoadingEnabled = true;

        }
        internal async void createTransacao()
        {
            await this.Contexto.Database.BeginTransactionAsync(this.isolationLevel);
        }
        internal void Commit()
        {
            if (this.Contexto.Database.CurrentTransaction != null)
                this.Contexto.Database.CommitTransaction();
        }
        internal void Rollback()
        {
            if (this.Contexto.Database.CurrentTransaction != null)
                this.Contexto.Database.RollbackTransaction();
        }

        internal IDbContextTransaction getTransacao()
        {
            return this.Contexto.Database.CurrentTransaction;
        }

        internal async void Adicionar(T entidade)
        {
            await this.Contexto.Set<T>().AddAsync(entidade);
        }

        internal async void Adicionar(IList<T> entidades)
        {
            await this.Contexto.Set<T>().AddRangeAsync(entidades);
        }

        internal void Atualizar(T entidade)
        {
            this.Contexto.Entry(entidade).State = EntityState.Modified;

        }

        internal async void Excluir(Func<T, bool> predicate)
        {
            var Entidades = await this.Contexto.Set<T>().Where(predicate).AsQueryable().ToListAsync();
            Entidades.ForEach(d => this.Contexto.Set<T>().Remove(d));

        }

        internal Task<T> Find(params object[] key)
        {
            return this.Contexto.Set<T>().FindAsync(key);
        }

        internal Task<int> SalvarAsync()
        {
            try
            {

                return this.Contexto.SaveChangesAsync();

            }


            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        internal int Salvar()
        {
            try
            {
                return this.Contexto.SaveChanges();
            }


            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        internal Task<int> executeNoQuery(string query)
        {
            this.Contexto.Database.SetCommandTimeout(0);
            this.Contexto.ChangeTracker.AutoDetectChangesEnabled = false;
            return this.Contexto.Database.ExecuteSqlCommandAsync(query);

        }
        public void Dispose()
        {
            this.Contexto.Dispose();
        }


    }
}
