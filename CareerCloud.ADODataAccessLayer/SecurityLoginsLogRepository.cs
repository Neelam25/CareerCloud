using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public class SecurityLoginsLogRepository : BaseADO, IDataRepository<SecurityLoginsLogPoco>
    {
        public void Add(params SecurityLoginsLogPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SecurityLoginsLogPoco pocoItem in items)
                {
                    cmd.CommandText = @"Insert into [JOB_PORTAL_DB].[dbo].[Security_Logins_Log]
                        ([Id],[Login],[Source_IP],[Logon_Date],[Is_Succesful])
                        values(@Id,@Login,@Source_IP,@Logon_Date,@Is_Successful)";
                    cmd.Parameters.AddWithValue("@Id",pocoItem.Id);
                    cmd.Parameters.AddWithValue("@Login",pocoItem.Login);
                    cmd.Parameters.AddWithValue("@Source_IP",pocoItem.SourceIP);
                    cmd.Parameters.AddWithValue("@Logon_Date", pocoItem.LogonDate);
                    cmd.Parameters.AddWithValue("@Is_Successful",pocoItem.IsSuccesful);

                    conn.Open();
                    int noOfRows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginsLogPoco> GetAll(params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            SecurityLoginsLogPoco[] pocos = new SecurityLoginsLogPoco[1800];
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("select * from [JOB_PORTAL_DB].[dbo].[Security_Logins_Log]", conn);
                conn.Open();
                int position = 0;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SecurityLoginsLogPoco poco = new SecurityLoginsLogPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Login = reader.GetGuid(1);
                    poco.SourceIP = reader.GetString(2);
                    poco.LogonDate = reader.GetDateTime(3);
                    poco.IsSuccesful = reader.GetBoolean(4);
                    pocos[position++] = poco;
                }
                conn.Close();
            }
            return pocos.Where(a => a != null).ToList();
        }

        public IList<SecurityLoginsLogPoco> GetList(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginsLogPoco GetSingle(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginsLogPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginsLogPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SecurityLoginsLogPoco pocoItem in items)
                {
                    cmd.CommandText = @"Delete from [JOB_PORTAL_DB].[dbo].[Security_Logins_Log] where Id = @Id";
                    cmd.Parameters.AddWithValue("@Id",pocoItem.Id);
                    conn.Open();
                    int noOfRows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params SecurityLoginsLogPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SecurityLoginsLogPoco pocoItem in items)
                {
                    cmd.CommandText = @"Update  [JOB_PORTAL_DB].[dbo].[Security_Logins_Log]
                    set Login = @Login,
                        Source_IP = @Source_IP,
                        Logon_Date = @Logon_Date,
                        Is_Succesful = @Is_Succesful
                        where Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", pocoItem.Id);
                    cmd.Parameters.AddWithValue("@Login", pocoItem.Login);
                    cmd.Parameters.AddWithValue("@Source_IP", pocoItem.SourceIP);
                    cmd.Parameters.AddWithValue("@Logon_Date", pocoItem.LogonDate);
                    cmd.Parameters.AddWithValue("@Is_Succesful", pocoItem.IsSuccesful);

                    conn.Open();
                    int noOfRows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
