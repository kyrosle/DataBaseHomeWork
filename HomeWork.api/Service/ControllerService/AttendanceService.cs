using HomeWork.api.Context;
using HomeWork.api.Models;
using HomeWork.Share.Dtos;
using HomeWork.Share.Parameters;
using HomeWork.Share.Parmeters;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace HomeWork.Api.Service.ControllerService
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
        /// <summary>
        /// 添加 一条 考勤记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ApiResponse> AddAsync(AttendanceDto model)
        {
            try
            {
                // turn attendance -> attendanceDto
                var attendance = mapper.Map<Attendance>(model);
                // add to datebase
                await db.Attendances.AddAsync(attendance);
                await db.SaveChangesAsync();
                return new ApiResponse(true, mapper.Map<AttendanceDto>(attendance));
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }
        /// <summary>
        /// 删除 一条考勤记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                // judge whether is not exists
                var attendance = await db.Attendances.SingleAsync(at => at.Id.Equals(id));
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
        /// 获取所有 考勤记录
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GetAllAsync(QueryParameter parameter)
        {
            try
            {
                if (parameter.PageSize == 0) parameter.PageSize = 20;
                IQueryable<AttendanceDto> addendanceDtoQuery =
                    from ad in db.Attendances
                    join ads in db.AttendanceStatuses
                        on ad.AttendanceStatusId equals ads.Id
                    join st in db.Staffs
                        on ad.StaffId equals st.Id
                    select new AttendanceDto(ad.Id, st.Name, ads.EnumType, ad.RecordTime, ad.CountTime);
                var addendanceDtosQuerySplitedPage = addendanceDtoQuery
                    .Skip(parameter.PageIndex * parameter.PageSize)
                    .Take(parameter.PageSize);
                var attendancesDtos =
                    await addendanceDtosQuerySplitedPage.AsNoTracking().ToArrayAsync();
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
                IQueryable<AttendanceDto> addendanceDtoQuery =
                    from ad in db.Attendances
                    join ads in db.AttendanceStatuses
                        on ad.AttendanceStatusId equals ads.Id
                    join st in db.Staffs
                        on ad.StaffId equals st.Id
                    select new AttendanceDto(ad.Id, st.Name, ads.EnumType, ad.RecordTime, ad.CountTime);

                if (parameter.SelectStaffs != 0)
                {
                    addendanceDtoQuery = addendanceDtoQuery.Where(ad => ad.StaffId.Equals(parameter.SelectStaffs));
                }
                else if (parameter.SelectAttendStatus != 0)
                {
                    addendanceDtoQuery = addendanceDtoQuery.Where(ad => ad.AttendanceType.Equals(parameter.SelectAttendStatus));
                }

                if (parameter.IsDescending.HasValue && (bool)parameter.IsDescending)
                {
                    addendanceDtoQuery = addendanceDtoQuery.OrderByDescending(ad => ad.RecordTime);
                }
                else
                {
                    addendanceDtoQuery = addendanceDtoQuery.OrderBy(ad => ad.RecordTime);
                }

                addendanceDtoQuery = addendanceDtoQuery
                    .Skip(parameter.PageIndex * parameter.PageSize)
                    .Take(parameter.PageSize);

                var attendancesDtos = await addendanceDtoQuery.ToArrayAsync();

                return new ApiResponse(true, attendancesDtos);
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }

        /// <summary>
        /// 查询 某一 考勤id 考情记录
        /// </summary>
        /// <param name="attendance_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GetSingleAsync(int attendance_id)
        {
            try
            {
                var attendance = await db.Attendances.SingleAsync(pt => pt.Id.Equals(attendance_id));
                return new ApiResponse(true, attendance);
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }

        /// <summary>
        /// 更新 考勤信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
