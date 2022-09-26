using HomeWork.Share.Parmeters;
using HomeWork.Share.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.App.Service
{
    internal class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        public Task<ApiResponse<TEntity>> AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<TEntity>> GetAllAsync(QueryParameter parameter)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<TEntity>> GetFirstOrDefault(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<TEntity>> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
