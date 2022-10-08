using HomeWork.api.Context;
using HomeWork.api.Models;
using HomeWork.Share.Dtos;
using HomeWork.Share.Parmeters;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace HomeWork.Api.Service
{
    public class PostService : IPostService
    {
        private readonly MyDbContext db;
        private readonly IMapper mapper;

        public PostService(MyDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        /// <summary>
        /// 添加一个Post
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ApiResponse> AddAsync(PostDto model)
        {
            try
            {
                bool isExist = await db.Posts.AsNoTracking().AnyAsync(st => st.Name.Trim().Equals(model.Name));
                if (isExist)
                {
                    return new ApiResponse("Staff is Existed");
                }

                var post = mapper.Map<Post>(model);
                await db.Posts.AddAsync(post);
                await db.SaveChangesAsync();
                return new ApiResponse(true, "Post Added");
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }
        /// <summary>
        /// 删除一个Post
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                var post = await db.Posts.SingleAsync(pt => pt.Id.Equals(id));
                if (post is null)
                {
                    return new ApiResponse("Id not Found");
                }
                else
                {
                    db.Posts.Remove(post);
                    var result = await db.SaveChangesAsync();
                    return new ApiResponse(true, $"Delete {result} Records");
                }
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }
        /// <summary>
        /// 获取所有的 Post
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GetAllAsync(QueryParameter parameter)
        {
            try
            {
                if (parameter.PageSize == 0) parameter.PageSize = 20;
                IQueryable<PostDto> postDtosQuery = from pt in db.Posts
                                                    select new PostDto()
                                                    {
                                                        Id = pt.Id,
                                                        Name = pt.Name,
                                                    };
                var postDtosQuerySplitedPage = postDtosQuery
                    .AsNoTracking()
                    .Where(pt => string.IsNullOrWhiteSpace(parameter.Search) || pt.Name.Trim().Contains(parameter.Search))
                    .Skip(parameter.PageIndex * parameter.PageSize)
                    .Take(parameter.PageSize);
                var postDtos = await postDtosQuerySplitedPage.ToArrayAsync();
                return new ApiResponse(true, postDtos);
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }
        /// <summary>
        /// 根据 id 查询 Post
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GetSingleAsync(int id)
        {
            try
            {
                var post = await db.Posts.SingleAsync(pt => pt.Id.Equals(id));
                var postDto = mapper.Map<PostDto>(post);
                return new ApiResponse(true, postDto);
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }
        /// <summary>
        /// 更新 Post 数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ApiResponse> UpdateAsync(PostDto model)
        {
            try
            {
                var post = mapper.Map<Post>(model);
                db.Posts.Update(post);
                var result = await db.SaveChangesAsync();
                return new ApiResponse(true, $"Updated {result} record(s)");
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }
    }
}
