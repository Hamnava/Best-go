using Data.ApplicationContext;
using Hamnava.Core.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamnava.Core.Repository.Services
{
    public class EntityDatabaseTransaction : IEntityDatabaseTransaction
    {
        private readonly IDbContextTransaction _transaction;
        public EntityDatabaseTransaction(Context context)
        {
            _transaction = context.Database.BeginTransaction();
        }

        public async Task Commit()
        {
            // when all changes has been aplied succssfully
            await _transaction.CommitAsync();
        }

        public async Task RollBack()
        {
            // when changes does not applied
           await _transaction.RollbackAsync();
        }


        public async Task Dispose()
        {
            // Destroy the object Of database
           await _transaction.DisposeAsync();
        }
    }
}
