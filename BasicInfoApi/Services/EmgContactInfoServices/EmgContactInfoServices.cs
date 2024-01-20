using EmployManagementSystemAPIs.Model;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using EmployManagementSystemAPIs.Connection;

namespace EmployManagementSystemAPIs.Services.EmgContactInfoServices
{
    public class EmgContactInfoServices : IEmgContactInfoServices
    {
        public async Task<List<EmgContactInfo>> GetAllEmgContactInfo()
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                var emgcontactinfo = await connection.QueryAsync<EmgContactInfo>("GetAllEmgContactInfo", null, commandType: CommandType.StoredProcedure);
                return emgcontactinfo.ToList();
            }
        }
        public async Task<EmgContactInfo> GetEmgContactInfoById(int id)
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                var emgcontactinfo = await connection.QueryAsync<EmgContactInfo>("GetEmgContactInfoById", parameters, commandType: CommandType.StoredProcedure);
                return emgcontactinfo.FirstOrDefault();
            }
        }
        public async Task<int> PostEmgContactInfo(EmgContactInfo emgcontactinfo)
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmgContactName", emgcontactinfo.EmgContactName);
                parameters.Add("@EmgContactPhone", emgcontactinfo.EmgContactPhone);
                parameters.Add("@EmgContactEmail", emgcontactinfo.EmgContactEmail);
                parameters.Add("@BasicId", emgcontactinfo.BasicId);

                var result = await connection.ExecuteAsync("PostEmgContactInfo", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<int> UpdateEmgContactInfo(EmgContactInfo emgcontactinfo)
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmgContactName", emgcontactinfo.EmgContactName);
                parameters.Add("@EmgContactPhone", emgcontactinfo.EmgContactPhone);
                parameters.Add("@EmgContactEmail", emgcontactinfo.EmgContactEmail);
                parameters.Add("@BasicId", emgcontactinfo.BasicId);
                parameters.Add("@Id", emgcontactinfo.Id);
                var result = await connection.ExecuteAsync("UpdateEmgContactInfo", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<int> DeleteEmgContactInfo(int Id)
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                var result = await connection.ExecuteAsync("DeleteEmgContactInfo", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}

