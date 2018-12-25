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
    public class SystemCountryCodeRepository : BaseADO, IDataRepository<SystemCountryCodePoco>
    {
        public void Add(params SystemCountryCodePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SystemCountryCodePoco pocoItem in items)
                {
                    cmd.CommandText = @"Insert into [JOB_PORTAL_DB].[dbo].[System_Country_Codes]
                        ([Code],[Name])
                        values(@Code,@Name)";
                    cmd.Parameters.AddWithValue("@Code", pocoItem.Code);
                    cmd.Parameters.AddWithValue("@Name", pocoItem.Name);
                
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

        public IList<SystemCountryCodePoco> GetAll(params System.Linq.Expressions.Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            SystemCountryCodePoco[] pocos = new SystemCountryCodePoco[5];
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("select * from [JOB_PORTAL_DB].[dbo].[System_Country_Codes]", conn);
                conn.Open();
                int position = 0;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SystemCountryCodePoco poco = new SystemCountryCodePoco();
                    poco.Code = reader.GetString(0);
                    poco.Name = reader.GetString(1);
                    pocos[position++] = poco;
                 }
                conn.Close();
            }
            return pocos.Where(a => a != null).ToList();
        }

        public IList<SystemCountryCodePoco> GetList(System.Linq.Expressions.Expression<Func<SystemCountryCodePoco, bool>> where, params System.Linq.Expressions.Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SystemCountryCodePoco GetSingle(System.Linq.Expressions.Expression<Func<SystemCountryCodePoco, bool>> where, params System.Linq.Expressions.Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            IQueryable<SystemCountryCodePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SystemCountryCodePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SystemCountryCodePoco pocoItem in items)
                {
                    cmd.CommandText = @"Delete from [JOB_PORTAL_DB].[dbo].[System_Country_Codes]
                        where Code = @Code";

                    cmd.Parameters.AddWithValue("@Code", pocoItem.Code);

                    conn.Open();
                    int noOfRows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params SystemCountryCodePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SystemCountryCodePoco pocoItem in items)
                {
                    cmd.CommandText = @"Update  [JOB_PORTAL_DB].[dbo].[System_Country_Codes]
                        set Name = @Name
                            where Code= @Code";
                    cmd.Parameters.AddWithValue("@Code", pocoItem.Code);
                    cmd.Parameters.AddWithValue("@Name", pocoItem.Name);
                    conn.Open();
                    int noOfRows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
