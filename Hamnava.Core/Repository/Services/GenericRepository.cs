using Data.Entities;
using Hamnava.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamnava.Core.Repository.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public Task<IReadOnlyList<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetEntityByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
