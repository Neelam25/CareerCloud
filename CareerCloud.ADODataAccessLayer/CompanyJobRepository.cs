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
    public class CompanyJobRepository : BaseADO, IDataRepository<CompanyJobPoco>
    {
        public void Add(params CompanyJobPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (CompanyJobPoco pocoItem in items)
                {
                    cmd.CommandText = @"Insert into [JOB_PORTAL_DB].[dbo].[Company_Jobs]
                        ([Id],[Company],[Profile_Created],[Is_Inactive],[Is_Company_Hidden])
                         values(@Id,@Company,@Profile_Created,@Is_Inactive,@Is_Company_Hidden)";
                    cmd.Parameters.AddWithValue("@Id",pocoItem.Id);
                    cmd.Parameters.AddWithValue("@Company",pocoItem.Company);
                    cmd.Parameters.AddWithValue("@Profile_Created",pocoItem.ProfileCreated);
                    cmd.Parameters.AddWithValue("@Is_Inactive",pocoItem.IsInactive);
                    cmd.Parameters.AddWithValue("@Is_Company_Hidden",pocoItem.IsCompanyHidden);

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

        public IList<CompanyJobPoco> GetAll(params System.Linq.Expressions.Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            CompanyJobPoco[] pocos = new CompanyJobPoco[1500];
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("select * from [JOB_PORTAL_DB].[dbo].[Company_Jobs]", conn);
                conn.Open();
                int position = 0;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CompanyJobPoco poco = new CompanyJobPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Company = reader.GetGuid(1);
                    poco.ProfileCreated = reader.GetDateTime(2);
                    poco.IsInactive = reader.GetBoolean(3);
                    poco.IsCompanyHidden = reader.GetBoolean(4);
                    if (! reader.IsDBNull(5))
                    {
                        poco.TimeStamp = (byte[])reader[5];
                    }
                    else
                    {
                        poco.TimeStamp = null;
                    }
                    pocos[position++]= poco;
                }
                conn.Close();
            }
            return pocos.Where(a => a != null).ToList();
        }

        public IList<CompanyJobPoco> GetList(System.Linq.Expressions.Expression<Func<CompanyJobPoco, bool>> where, params System.Linq.Expressions.Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobPoco GetSingle(System.Linq.Expressions.Expression<Func<CompanyJobPoco, bool>> where, params System.Linq.Expressions.Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (CompanyJobPoco pocoItem in items)
                {
                    cmd.CommandText = @"Delete from [JOB_PORTAL_DB].[dbo].[Company_Jobs]
                       where Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", pocoItem.Id);
                   
                    conn.Open();
                    int noOfRows = cmd.ExecuteNonQuery();
                    conn.Close();

                }
            }
        }

        public void Update(params CompanyJobPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (CompanyJobPoco pocoItem in items)
                {
                    cmd.CommandText = @"Update [JOB_PORTAL_DB].[dbo].[Company_Jobs]
                        set Company = @Company,
                            Profile_Created =@Profile_Created,
                            Is_Inactive = @Is_Inactive,
                            Is_Company_Hidden = @Is_Company_Hidden
                    where Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", pocoItem.Id);
                    cmd.Parameters.AddWithValue("@Company", pocoItem.Company);
                    cmd.Parameters.AddWithValue("@Profile_Created", pocoItem.ProfileCreated);
                    cmd.Parameters.AddWithValue("@Is_Inactive", pocoItem.IsInactive);
                    cmd.Parameters.AddWithValue("@Is_Company_Hidden", pocoItem.IsCompanyHidden);
                    
                    conn.Open();
                    int noOfRows = cmd.ExecuteNonQuery();
                    conn.Close();

                }
            }
        }
    }
}
