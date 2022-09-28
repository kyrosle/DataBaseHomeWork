using HomeWork.api.Context;
using HomeWork.api.Models;
using HomeWork.Share.Dtos;
using HomeWork.Share.Parmeters;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HomeWork.Api.Service
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
                return new ApiResponse(true, "StaffChange Added");
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
                if (staffChange is null)
                {
                    return new ApiResponse("Id not Found");
                }
                else
                {
                    db.StaffChanges.Remove(staffChange);
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
                IQueryable<AttendanceDto> addendanceDtosQuery = from ad in db.Attendances
                                                                join ads in db.AttendanceStatuses
                                                                    on ad.AttendanceStatusId equals ads.Id
                                                                join st in db.Staffs
                                                                    on ad.StaffId equals st.Id
                                                                select new AttendanceDto()
                                                                {
                                                                    StaffId = st.Id,
                                                                    StaffName = st.Name,
                                                                    AttendanceType = ads.Id,
                                                                    AttendanceStatus = ads.EnumType,
                                                                    FineOrBouns = ads.FineOrBouns,
                                                                    RateFineOrBouns = ads.RateFineOrBouns,
                                                                    RecordTime = ad.RecordTime,
                                                                    CountTime = ad.CountTime,
                                                                };
                var addendanceDtosQuerySplitedPage = addendanceDtosQuery
                    .Skip(parameter.PageIndex * parameter.PageSize).Take(parameter.PageSize);
                var attendancesDtos = await addendanceDtosQuerySplitedPage.ToArrayAsync();
                return new ApiResponse(true, attendancesDtos);
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
                var staffChange = await db.StaffChanges
                    .OrderByDescending(stc => stc.ChangeTime)
                    .FirstAsync(stc => stc.StaffId.Equals(id));
                if (staffChange is not null)
                {
                    return new ApiResponse(true, staffChange);
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

        public async Task<ApiResponse> UpdateAsync(AttendanceDto model)
        {
            try
            {
                var attendance = mapper.Map<Attendance>(model);
                db.Attendances.Update(attendance);
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
