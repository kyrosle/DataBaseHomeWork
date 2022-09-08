using HomeWork.Share.Parmeters;
using HomeWork.Share.Service;

namespace HomeWork.App.Service
{
    internal interface IBaseService<TEntity> where TEntity : class
    {
        Task<ApiResponse<TEntity>> AddAsync(TEntity entity);
        Task<ApiResponse<TEntity>> UpdateAsync(TEntity entity);
        Task<ApiResponse> DeleteAsync(int id);
        Task<ApiResponse<TEntity>> GetFirstOrDefault(int id);
        Task<ApiResponse<TEntity>> GetAllAsync(QueryParameter parameter);
    }
}
