using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Shared.Common.Interfaces
{
   public interface IRepository<TEntity> where TEntity:class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(int id);

        Task<int> Create(TEntity entity);

        Task<int> Update(TEntity entity);

        Task<int> Delete(TEntity entity);
        Task<int> AddRange(List<TEntity> entity);
        Task<int> UpdateRange(List<TEntity> entity);
    }
}
