using HomeWork.api.Context;
using HomeWork.api.Models;
using HomeWork.Share.Dtos;
using HomeWork.Share.Parameters;
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
                db.Attendances.Remove(attendance);
                var result = await db.SaveChangesAsync();
                return new ApiResponse(true, $"Delete {result} Records");
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }

        /// <summary>
        /// 获取所有 Attendance
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
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
                    .Skip(parameter.PageIndex * parameter.PageSize)
                    .Take(parameter.PageSize)
                    .Where(at => string.IsNullOrWhiteSpace(parameter.Search));
                var attendancesDtos = await addendanceDtosQuerySplitedPage.ToArrayAsync();
                return new ApiResponse(true, attendancesDtos);
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }
        /// <summary>
        /// 获取所有 Attendance 带筛选条件
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GetAllAsync(AttendanceParameter parameter)
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
                if (parameter.SelectStaffs != 0)
                {
                    addendanceDtosQuery = addendanceDtosQuery.Where(ad => ad.StaffId.Equals(parameter.SelectStaffs));
                }
                else if (parameter.SelectAttendStatus != 0)
                {
                    addendanceDtosQuery = addendanceDtosQuery.Where(ad => ad.AttendanceType.Equals(parameter.SelectAttendStatus));
                }

                if (parameter.IsDescending.HasValue && (bool)(parameter.IsDescending))
                {
                    addendanceDtosQuery = addendanceDtosQuery.OrderByDescending(ad => ad.RecordTime);
                }
                else
                {
                    addendanceDtosQuery = addendanceDtosQuery.OrderBy(ad => ad.RecordTime);
                }

                addendanceDtosQuery = addendanceDtosQuery
                    .Skip(parameter.PageIndex * parameter.PageSize)
                    .Take(parameter.PageSize);

                var attendancesDtos = await addendanceDtosQuery.ToArrayAsync();

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
                return new ApiResponse(true, attendance);
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
