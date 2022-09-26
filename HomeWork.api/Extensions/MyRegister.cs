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
                .Map(std => std.Id, st => st.Id)
                .Map(std => std.Name, st => st.Name)
                .Map(std => std.Brith, st => st.Brith)
                .Map(std => std.DepartmentId, st => st.DepartmentId)
                .Map(std => std.PostId, st => st.PostId);
        }
    }
}
