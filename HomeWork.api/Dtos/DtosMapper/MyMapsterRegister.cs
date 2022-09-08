using HomeWork.api.Models;
using Mapster;

namespace HomeWork.api.Dtos.DtosMapper
{
    public class MyMapsterRegister : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<Department, DepartmentDto>()
                .Map(dest => dest.Manager, src => new StaffDto()
                {
                    Id=src.Manager.Id,
                    Name=src.Manager.Name,
                    Brith=src.Manager.Brith,
                    Health=src.Manager.Health,
                    Post=src.Manager.Post.Name,
                    PoliticalType=(Datadictionary.Political)src.Manager.PoliticalType.Id,
                });
        }
    }
}
