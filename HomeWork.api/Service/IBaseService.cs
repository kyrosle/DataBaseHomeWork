
using HomeWork.Api.Service;
using HomeWork.Share.Parmeters;

namespace HomeWork.api.Service
{
    public interface IBaseService<T>
    {
        Task<ApiResponse> GetAllAsync(QueryParameter parameter);
        Task<ApiResponse> GetSingleAsync(int id);
        Task<ApiResponse> AddAsync(T model);
        Task<ApiResponse> UpdateAsync(T model);
        Task<ApiResponse> DeleteAsync(int id);
    }
}
