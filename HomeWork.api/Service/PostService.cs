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
        public async Task<ApiResponse> AddAsync(PostDto model)
        {
            try
            {
                bool isExist = db.Posts.AsNoTracking().Where(st => st.Name.Trim().Equals(model.Name)).Any();
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

        public async Task<ApiResponse> GetAllAsync(QueryParameter parameter)
        {
            try
            {
                if (parameter.PageSize == 0) parameter.PageSize = 20;
                IQueryable<PostDto> postDtosQuery = from pt in db.Posts
                                                    join sl in db.Salarys
                                                       on pt.SaralyId equals sl.SalaryId
                                                    select new PostDto()
                                                    {
                                                        Id = pt.Id,
                                                        Name = pt.Name,
                                                        Saraly = sl.Salary
                                                    };
                var postDtosQuerySplitedPage = postDtosQuery
                    .Skip(parameter.PageIndex * parameter.PageSize).Take(parameter.PageSize);
                var postDtos = await postDtosQuerySplitedPage.ToArrayAsync();
                return new ApiResponse(true, postDtos);
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }

        public async Task<ApiResponse> GetSingleAsync(int id)
        {
            try
            {
                var post = await db.Posts.SingleAsync(pt => pt.Id.Equals(id));
                if (post is not null)
                {
                    return new ApiResponse(true, post);
                }
                else
                {
                    return new ApiResponse("Id not Found");
                }
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }

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
