using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public class SystemLanguageCodeRepository : BaseADO, IDataRepository<SystemLanguageCodePoco>
    {
        public void Add(params SystemLanguageCodePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach(SystemLanguageCodePoco pocoItem in items)
                {

                    cmd.CommandText = @"Insert into [JOB_PORTAL_DB].[dbo].[System_Language_Codes]
                        ([LanguageID],[Name],[Native_Name])
                        values(@LanguageID,@Name,@Native_Name)";

                    cmd.Parameters.AddWithValue("@LanguageID",pocoItem.LanguageID);
                    cmd.Parameters.AddWithValue("@Name",pocoItem.Name);
                    cmd.Parameters.AddWithValue("@Native_Name",pocoItem.NativeName);

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

        public IList<SystemLanguageCodePoco> GetAll(params System.Linq.Expressions.Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            SystemLanguageCodePoco[] pocos = new SystemLanguageCodePoco[5];
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("select * from [JOB_PORTAL_DB].[dbo].[System_Language_Codes]", conn);
                conn.Open();
                int position = 0;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SystemLanguageCodePoco poco = new SystemLanguageCodePoco();
                    poco.LanguageID = reader.GetString(0);
                    poco.Name = reader.GetString(1);
                    poco.NativeName = reader.GetString(2);
                    pocos[position++] = poco;
                }

                conn.Close();
            }
            return pocos.Where(a => a != null).ToList();
        }

        public IList<SystemLanguageCodePoco> GetList(System.Linq.Expressions.Expression<Func<SystemLanguageCodePoco, bool>> where, params System.Linq.Expressions.Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SystemLanguageCodePoco GetSingle(System.Linq.Expressions.Expression<Func<SystemLanguageCodePoco, bool>> where, params System.Linq.Expressions.Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            IQueryable<SystemLanguageCodePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SystemLanguageCodePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SystemLanguageCodePoco pocoItem in items)
                {
                    cmd.CommandText = @"Delete from [JOB_PORTAL_DB].[dbo].[System_Language_Codes]
                        where LanguageId =@LanguageID";

                    cmd.Parameters.AddWithValue("@LanguageID", pocoItem.LanguageID);
                    
                    conn.Open();
                    int noOfRows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params SystemLanguageCodePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SystemLanguageCodePoco pocoItem in items)
                {

                    cmd.CommandText = @"Update [JOB_PORTAL_DB].[dbo].[System_Language_Codes]
                        set Name = @Name,
                            Native_Name = @Native_Name
                            where LanguageID =@LanguageID";

                    cmd.Parameters.AddWithValue("@LanguageID", pocoItem.LanguageID);
                    cmd.Parameters.AddWithValue("@Name", pocoItem.Name);
                    cmd.Parameters.AddWithValue("@Native_Name", pocoItem.NativeName);

                    conn.Open();
                    int noOfRows = cmd.ExecuteNonQuery();
                    conn.Close();

                }
            }
        }
    }
}
