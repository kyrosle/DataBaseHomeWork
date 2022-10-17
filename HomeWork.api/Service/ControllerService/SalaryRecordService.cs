using HomeWork.api.Context;
using HomeWork.Api.Models;
using HomeWork.Share.Dtos;
using HomeWork.Share.Parameters;
using HomeWork.Share.Parmeters;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace HomeWork.Api.Service.ControllerService
{
    public class SalaryRecordService : ISalaryRecordService
    {
        private readonly MyDbContext db;
        private readonly IMapper mapper;

        public SalaryRecordService(MyDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<ApiResponse> AddAsync(SalaryRecordDto model)
        {
            try
            {
                var record = mapper.Map<SalaryRecord>(model);
                await db.SalaryRecords.AddAsync(record);
                await db.SaveChangesAsync();
                return new ApiResponse(true, mapper.Map<SalaryRecordDto>(record));
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

                var record = await db.SalaryRecords.SingleAsync(rc => rc.Id.Equals(id));
                db.SalaryRecords.Remove(record);
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
                IQueryable<SalaryRecordDto> salaryRecordDtosQuery =
                    from rc in db.SalaryRecords
                    join st in db.Staffs on rc.StaffId equals st.Id
                    select new SalaryRecordDto(rc.Id, st.Name, rc.BasicSalary, rc.Bouns, rc.Fine, rc.StartTime, rc.CutOfTime);
                var salaryRecordDtosQuerySplitedPage = salaryRecordDtosQuery
                    .Skip(parameter.PageIndex * parameter.PageSize)
                    .Take(parameter.PageSize);
                var salaryRecordDtos =
                    await salaryRecordDtosQuerySplitedPage.AsNoTracking().ToArrayAsync();
                return new ApiResponse(true, salaryRecordDtos);
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }
        public async Task<ApiResponse> GetAllAsync(SalaryRecordParameter parameter)
        {
            try
            {
                if (parameter.PageSize == 0) parameter.PageSize = 20;
                IQueryable<SalaryRecordDto> salaryRecordDtosQuery =
                    from rc in db.SalaryRecords
                    join st in db.Staffs on rc.StaffId equals st.Id
                    select new SalaryRecordDto(rc.Id, st.Name, rc.BasicSalary, rc.Bouns, rc.Fine, rc.StartTime, rc.CutOfTime);

                if (!)


                var salaryRecordDtosQuerySplitedPage = salaryRecordDtosQuery
                    .Skip(parameter.PageIndex * parameter.PageSize)
                    .Take(parameter.PageSize);
                var salaryRecordDtos =
                    await salaryRecordDtosQuerySplitedPage.AsNoTracking().ToArrayAsync();
                return new ApiResponse(true, salaryRecordDtos);
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
                IQueryable<SalaryRecordDto> salaryRecordDtoQuery =
                    from rc in db.SalaryRecords
                    join st in db.Staffs on rc.StaffId equals st.Id
                    where rc.Id == id
                    select new SalaryRecordDto(rc.Id, st.Name, rc.BasicSalary, rc.Bouns, rc.Fine, rc.StartTime, rc.CutOfTime);
                var salaryRecordDto = await salaryRecordDtoQuery.SingleAsync();
                return new ApiResponse(true, salaryRecordDto);
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }

        public async Task<ApiResponse> UpdateAsync(SalaryRecordDto model)
        {
            try
            {
                var salaryRecord = mapper.Map<SalaryRecord>(model);
                db.SalaryRecords.Update(salaryRecord);
                var result = await db.SaveChangesAsync();
                return new ApiResponse(true, $"Update {result} Record(s)");
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }
    }
}
