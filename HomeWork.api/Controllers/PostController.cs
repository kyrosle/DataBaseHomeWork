using HomeWork.Api.Service;
using HomeWork.Share.Dtos;
using HomeWork.Share.Parmeters;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork.Api.Controllers
{
    [ApiController]
    [Route("ap/[controller]/[action]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService service;

        public PostController(IPostService service)
        {
            this.service = service;
        }


        [HttpGet]
        public async Task<ApiResponse> Get(int id) => await service.GetSingleAsync(id);

        [HttpGet]
        public async Task<ApiResponse> GetAllPost([FromQuery] QueryParameter parameter) => await service.GetAllAsync(parameter);

        [HttpPost]
        public async Task<ApiResponse> Add([FromBody] PostDto post) => await service.AddAsync(post);

        [HttpPost]
        public async Task<ApiResponse> Update([FromBody] PostDto post) => await service.UpdateAsync(post);

        [HttpGet]
        public async Task<ApiResponse> Delete(int id) => await service.DeleteAsync(id);
    }
}
