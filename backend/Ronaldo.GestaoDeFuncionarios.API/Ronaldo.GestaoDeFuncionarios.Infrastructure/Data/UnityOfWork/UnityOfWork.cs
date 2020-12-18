using Microsoft.EntityFrameworkCore;
using Ronaldo.GestaoDeFuncionarios.Core.SharedKernel.Interfaces.UnityOfWork;
using Serilog;
using System;
using System.Linq;

namespace Ronaldo.GestaoDeFuncionarios.Infrastructure.Data.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork
    {
        protected readonly DataContext DbContext;

        public UnityOfWork(DataContext dbContext)
        {
            DbContext = dbContext;
        }

        public bool Commit()
        {
            try
            {
                if (DbContext.ChangeTracker.Entries().Any(e =>
                    e.State == EntityState.Added || e.State == EntityState.Deleted || e.State == EntityState.Modified))
                {
                    Log.Information("Commit Done");
                    return DbContext.SaveChanges() > 0;
                }

                return false;
            }
            catch (Exception e)
            {
                Log.Error($"Commit Failed. The reason is {e.Message}");
                throw;
            }
        }
    }
}
