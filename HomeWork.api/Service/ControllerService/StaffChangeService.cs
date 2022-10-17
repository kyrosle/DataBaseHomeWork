using HomeWork.api.Context;
using HomeWork.api.Models;
using HomeWork.Share.Dtos;
using HomeWork.Share.Parameters;
using HomeWork.Share.Parmeters;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HomeWork.Api.Service.ControllerService
{
    public class StaffChangeService : IStaffChangeService
    {
        private readonly MyDbContext db;
        private readonly IMapper mapper;

        public StaffChangeService(MyDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> AddAsync(StaffChangeDto model)
        {
            try
            {
                var staffChange = mapper.Map<StaffChange>(model);
                await db.StaffChanges.AddAsync(staffChange);
                await db.SaveChangesAsync();
                return new ApiResponse(true, mapper.Map<StaffChangeDto>(staffChange));
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
                var staffChange = await db.StaffChanges.SingleAsync(stc => stc.Id.Equals(id));
                db.StaffChanges.Remove(staffChange);
                var result = await db.SaveChangesAsync();
                return new ApiResponse(true, $"Delete {result} Records");
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

                IQueryable<StaffChangeDto> staffChangeDtosQuery =
                    from stc in db.StaffChanges
                    join dp in db.Departments
                     on stc.DepartmentId equals dp.Id
                    join pt in db.Posts
                     on stc.PostId equals pt.Id
                    join st in db.Staffs
                     on stc.StaffId equals st.Id
                    select new StaffChangeDto(stc.Id, st.Name, pt.Name, dp.Name, stc.ChangeTime);

                staffChangeDtosQuery = staffChangeDtosQuery
                .Skip(parameter.PageIndex * parameter.PageSize)
                .Take(parameter.PageSize);

                var staffChangeDtos = await staffChangeDtosQuery.AsNoTracking().ToArrayAsync();

                return new ApiResponse(true, staffChangeDtos);
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }

        /// <summary>
        /// 带筛选条件查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GetAllAsync(StaffChangeParameter parameter)
        {
            try
            {
                if (parameter.PageSize == 0) parameter.PageSize = 20;

                IQueryable<StaffChangeDto> staffChangeDtosQuery =
                    from stc in db.StaffChanges
                    join dp in db.Departments
                     on stc.DepartmentId equals dp.Id
                    join pt in db.Posts
                     on stc.PostId equals pt.Id
                    join st in db.Staffs
                     on stc.StaffId equals st.Id
                    select new StaffChangeDto(stc.Id, st.Name, pt.Name, dp.Name, stc.ChangeTime);

                if (parameter.SelectStaffs.HasValue && (int)parameter.SelectStaffs > 0)
                {
                    staffChangeDtosQuery = staffChangeDtosQuery.Where(stc => stc.StaffId.Equals(parameter.SelectStaffs));
                }
                else if (parameter.SelectDepartment.HasValue && (int)parameter.SelectDepartment > 0)
                {
                    staffChangeDtosQuery = staffChangeDtosQuery.Where(stc => stc.DepartmentId.Equals(parameter.SelectDepartment));
                }

                if (parameter.IsDescending.HasValue && (bool)parameter.IsDescending)
                {
                    staffChangeDtosQuery = staffChangeDtosQuery.OrderByDescending(stc => stc.ChangeTime);
                }
                else
                {
                    staffChangeDtosQuery = staffChangeDtosQuery.OrderBy(stc => stc.ChangeTime);
                }

                staffChangeDtosQuery = staffChangeDtosQuery
                    .Skip(parameter.PageIndex * parameter.PageSize)
                    .Take(parameter.PageSize);

                var staffChangeDtos = await staffChangeDtosQuery.AsNoTracking().ToArrayAsync();

                return new ApiResponse(true, staffChangeDtos);
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
                var staffChangeQuery =
                    from stc in db.StaffChanges
                    join dp in db.Departments
                     on stc.DepartmentId equals dp.Id
                    join pt in db.Posts
                     on stc.PostId equals pt.Id
                    join st in db.Staffs
                     on stc.StaffId equals st.Id
                    where stc.Id == id
                    select new StaffChangeDto(stc.Id, st.Name, pt.Name, dp.Name, stc.ChangeTime);

                var staffChangeDto = await staffChangeQuery.SingleAsync();
                return new ApiResponse(true, staffChangeDto);
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }

        public async Task<ApiResponse> UpdateAsync(StaffChangeDto model)
        {
            try
            {
                var staffChange = mapper.Map<StaffChange>(model);
                db.StaffChanges.Update(staffChange);
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
