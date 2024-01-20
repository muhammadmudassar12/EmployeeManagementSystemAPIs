using Dapper;
using EmployManagementSystemAPIs.Model;
using System.Data.SqlClient;
using System.Data;
using EmployManagementSystemAPIs.Connection;

namespace EmployManagementSystemAPIs.Services.SalaryInfoServices
{
    public class SalaryInfoServices : ISalaryInfoServices
    {
        public async Task<List<SalaryInfo>> GetAllSalaryInfo()
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                var salaryinfo = await connection.QueryAsync<SalaryInfo>("GetAllSalaryInfo", null, commandType: CommandType.StoredProcedure);
                return salaryinfo.ToList();
            }
        }
        public async Task<SalaryInfo> GetSalaryInfoById(int id)
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                var salaryinfo = await connection.QueryAsync<SalaryInfo>("GetSalaryInfoById", parameters, commandType: CommandType.StoredProcedure);
                return salaryinfo.FirstOrDefault();
            }
        }
        public async Task<int> PostSalaryInfo(SalaryInfo salaryinfo)
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SalaryMonth", salaryinfo.SalaryMonth);
                parameters.Add("@BasicSalary", salaryinfo.BasicSalary);
                parameters.Add("@Allowance", salaryinfo.Allowance);
                parameters.Add("@Bonus", salaryinfo.Bonus);
                parameters.Add("@TotalSalary", salaryinfo.TotalSalary);
                parameters.Add("@BasicId", salaryinfo.BasicId);
                var result = await connection.ExecuteAsync("PostSalaryInfo", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<int> UpdateSalaryInfo(SalaryInfo salaryinfo)
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SalaryMonth", salaryinfo.SalaryMonth);
                parameters.Add("@BasicSalary", salaryinfo.BasicSalary);
                parameters.Add("@Allowance", salaryinfo.Allowance);
                parameters.Add("@Bonus", salaryinfo.Bonus);
                parameters.Add("@TotalSalary", salaryinfo.TotalSalary);
                parameters.Add("@BasicId", salaryinfo.BasicId);
                parameters.Add("@Id", salaryinfo.Id);
                var result = await connection.ExecuteAsync("UpdateSalaryInfo", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<int> DeleteSalaryInfo(int Id)
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                var result = await connection.ExecuteAsync("DeleteSalaryInfo", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
