using HomeWork.api.Models;
using HomeWork.Share.Dtos;
using Mapster;

namespace HomeWork.Api.Extensions
{
    public class MyRegister : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<StaffDto, Staff>()
                .Map(st => st.Id, std => std.Id)
                .Map(st => st.Name, std => std.Name)
                .Map(st => st.Brith, std => std.Brith)
                .Map(st => st.PoliticalType, std => std.PoliticalTypeId)
                .Map(st => st.DepartmentId, std => std.DepartmentId)
                .Map(st => st.Health, std => std.Health)
                .Map(st => st.PostId, sdt => sdt.PostId)
                .Map(st => st.Introduce, std => std.Introduce)
                .Map(st => st.Salary, std => std.Salary);

            config.NewConfig<PostDto, Post>()
                .Map(pt => pt.Id, ptd => ptd.Id)
                .Map(pt => pt.Name, ptd => ptd.Name)
                .Map(pt => pt.StandSalaryId, ptd => ptd.StandSalaryId);

            config.NewConfig<DepartmentDto, Department>()
                .Map(dp => dp.Id, dpd => dpd.Id)
                .Map(dp => dp.Name, dpd => dpd.Name)
                .Map(dp => dp.ManagerId, dpd => dpd.ManagerId);

            config.NewConfig<AttendanceDto, Attendance>()
                .Map(at => at.Id, atd => atd.Id)
                .Map(at => at.StaffId, atd => atd.StaffId)
                .Map(at => at.AttendanceStatusId, atd => atd.AttendanceStatus)
                .Map(at => at.CountTime, atd => atd.CountTime)
                .Map(at => at.RecordTime, atd => atd.RecordTime);

            config.NewConfig<StaffChangeDto, StaffChange>()
                .Map(stc => stc.Id, stcd => stcd.Id)
                .Map(stc => stc.StaffId, stcd => stcd.StaffId)
                .Map(stc => stc.PostId, stcd => stcd.PostId)
                .Map(stc => stc.DepartmentId, stcd => stcd.DepartmentId)
                .Map(stc => stc.ChangeTime, stcd => stcd.ChangeTime);
        }
    }
}
