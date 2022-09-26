using HomeWork.Share.Dtos;
using Mapster;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeWork.api.Models
{
    public class Department : IdentityModel
    {
        // 部门 Id

        // 部门 名称

        // 部门 管理员
        public int? ManagerId { get; set; }
    }
}
