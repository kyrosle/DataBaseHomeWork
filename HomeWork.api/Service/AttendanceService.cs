using HomeWork.api.Context;
using HomeWork.api.Models;
using HomeWork.Share.Dtos;
using HomeWork.Share.Parmeters;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace HomeWork.Api.Service
{
    public class AttendanceService : IAttendanceService
    {
        private readonly MyDbContext db;
        private readonly IMapper mapper;

        public AttendanceService(MyDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<ApiResponse> AddAsync(AttendanceDto model)
        {
            try
            {
                var attendance = mapper.Map<Attendance>(model);
                await db.Attendances.AddAsync(attendance);
                await db.SaveChangesAsync();
                return new ApiResponse(true, "Attendance Added");
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
                var attendance = await db.Attendances.SingleAsync(dp => dp.Id.Equals(id));
                if (attendance is null)
                {
                    return new ApiResponse("Id not Found");
                }
                else
                {
                    db.Attendances.Remove(attendance);
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
                var attendance = await db.Attendances.SingleAsync(pt => pt.Id.Equals(id));
                if (attendance is not null)
                {
                    return new ApiResponse(true, attendance);
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
