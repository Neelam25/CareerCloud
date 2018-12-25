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
    public class CompanyJobEducationRepository : BaseADO, IDataRepository<CompanyJobEducationPoco>
    {
        public void Add(params CompanyJobEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (CompanyJobEducationPoco pocoItem in items)
                {
                    cmd.CommandText = @"Insert into [JOB_PORTAL_DB].[dbo].[Company_Job_Educations]
                        ([Id],[Job],[Major],[Importance])
                        values(@Id,@Job,@Major,@Importance)";
                    cmd.Parameters.AddWithValue("@Id",pocoItem.Id);
                    cmd.Parameters.AddWithValue("@Job",pocoItem.Job);
                    cmd.Parameters.AddWithValue("@Major",pocoItem.Major);
                    cmd.Parameters.AddWithValue("@Importance",pocoItem.Importance);
                    

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

        public IList<CompanyJobEducationPoco> GetAll(params System.Linq.Expressions.Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            CompanyJobEducationPoco[] pocos = new CompanyJobEducationPoco[1500];
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("Select * from [JOB_PORTAL_DB].[dbo].[Company_Job_Educations]", conn);
                conn.Open();
                int position = 0;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CompanyJobEducationPoco poco = new CompanyJobEducationPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Job = reader.GetGuid(1);
                    poco.Major = reader.GetString(2);
                    poco.Importance = reader.GetInt16(3);
                    poco.TimeStamp = (byte[])reader[4];

                    pocos[position++] = poco;
                }
            }
            return pocos.Where(a => a != null).ToList();
        }

        public IList<CompanyJobEducationPoco> GetList(System.Linq.Expressions.Expression<Func<CompanyJobEducationPoco, bool>> where, params System.Linq.Expressions.Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobEducationPoco GetSingle(System.Linq.Expressions.Expression<Func<CompanyJobEducationPoco, bool>> where, params System.Linq.Expressions.Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobEducationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (CompanyJobEducationPoco pocoItem in items)
                {
                    cmd.CommandText = @"Delete from [JOB_PORTAL_DB].[dbo].[Company_Job_Educations]
                        where Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", pocoItem.Id);
                   
                    conn.Open();
                    int noOfRows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params CompanyJobEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (CompanyJobEducationPoco pocoItem in items)
                {
                    cmd.CommandText = @"Update [JOB_PORTAL_DB].[dbo].[Company_Job_Educations]
                          set  Major = @Major,
                            Importance = @Importance
                        where Id =  @Id";
                            
                    cmd.Parameters.AddWithValue("@Id", pocoItem.Id);
                    cmd.Parameters.AddWithValue("@Job", pocoItem.Job);
                    cmd.Parameters.AddWithValue("@Major", pocoItem.Major);
                    cmd.Parameters.AddWithValue("@Importance", pocoItem.Importance);
                   
                    conn.Open();
                    int noOfRows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
