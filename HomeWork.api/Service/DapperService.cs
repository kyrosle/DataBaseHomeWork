using Dapper;
using HomeWork.api.Models;
using MySqlConnector;

namespace HomeWork.api.Service
{
    public class DapperService : IDapperService
    {
        private readonly IConfiguration config;
        private readonly string mysqlConnectStr;

        public DapperService(IConfiguration config)
        {
            this.config = config;
            mysqlConnectStr = config.GetConnectionString("MyDbContext");
        }

        public Task<object[]> Action()
        {
            var conn = new MySqlConnection(mysqlConnectStr);
            conn.Open();
            var sqlstr = @"select * from T_Staff";
            object[] result = conn.Query<Staff>(sqlstr).ToArray();
            return Task.FromResult(result);
        }
    }
}
