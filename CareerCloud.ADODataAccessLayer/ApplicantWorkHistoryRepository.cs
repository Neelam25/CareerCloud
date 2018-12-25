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
    public class ApplicantWorkHistoryRepository : BaseADO, IDataRepository<ApplicantWorkHistoryPoco>
    {
        public void Add(params ApplicantWorkHistoryPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach(ApplicantWorkHistoryPoco pocoItem in items)
                {
                    cmd.CommandText = @"Insert into [JOB_PORTAL_DB].[dbo].[Applicant_Work_History]
                        ([Id],[Applicant],[Company_Name],[Country_Code],[Location],[Job_Title],[Job_Description],[Start_Month],[Start_Year],[End_Month],[End_Year])
                        values(@Id,@Applicant,@Company_Name,@Country_Code,@Location,@Job_Title,@Job_Description,@Start_Month,@Start_Year,@End_Month,@End_Year)";
                    cmd.Parameters.AddWithValue("@Id",pocoItem.Id);
                    cmd.Parameters.AddWithValue("@Applicant",pocoItem.Applicant);
                    cmd.Parameters.AddWithValue("@Company_Name",pocoItem.CompanyName);
                    cmd.Parameters.AddWithValue("@Country_Code", pocoItem.CountryCode);
                    cmd.Parameters.AddWithValue("@Location",pocoItem.Location);
                    cmd.Parameters.AddWithValue("@Job_Title",pocoItem.JobTitle);
                    cmd.Parameters.AddWithValue("@Job_Description",pocoItem.JobDescription);
                    cmd.Parameters.AddWithValue("@Start_Month", pocoItem.StartMonth);
                    cmd.Parameters.AddWithValue("@Start_Year", pocoItem.StartYear);
                    cmd.Parameters.AddWithValue("@End_Month",pocoItem.EndMonth);
                    cmd.Parameters.AddWithValue("@End_year",pocoItem.EndYear);
                   
                    conn.Open();
                    int rowsEffected = cmd.ExecuteNonQuery();
                    conn.Close();

                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantWorkHistoryPoco> GetAll(params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            ApplicantWorkHistoryPoco[] pocos = new ApplicantWorkHistoryPoco[500];
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("Select * from [JOB_PORTAL_DB].[dbo].[Applicant_Work_History]", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int position = 0;
                while(reader.Read())
                {
                    ApplicantWorkHistoryPoco poco = new ApplicantWorkHistoryPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Applicant = reader.GetGuid(1);
                    poco.CompanyName = reader.GetString(2);
                    poco.CountryCode = reader.GetString(3);
                    poco.Location = reader.GetString(4);
                    poco.JobTitle = reader.GetString(5);
                    poco.JobDescription = reader.GetString(6);
                    poco.StartMonth = reader.GetInt16(7);
                    poco.StartYear = reader.GetInt32(8);
                    poco.EndMonth = reader.GetInt16(9);
                    poco.EndYear = reader.GetInt32(10);
                    poco.TimeStamp = (byte[])reader[11];
                      pocos[position++] = poco;  
                }
                conn.Close();
            }
            return pocos.Where(a=>a !=null).ToList();
        }

        public IList<ApplicantWorkHistoryPoco> GetList(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantWorkHistoryPoco GetSingle(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantWorkHistoryPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantWorkHistoryPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantWorkHistoryPoco pocoItem in items)
                {
                    cmd.CommandText = @"Delete from [JOB_PORTAL_DB].[dbo].[Applicant_Work_History] where Id = @Id";
                    cmd.Parameters.AddWithValue("@Id",pocoItem.Id);
                    conn.Open();
                    int numOfRows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params ApplicantWorkHistoryPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach(ApplicantWorkHistoryPoco pocoItem in items)
                {
                    cmd.CommandText = @"Update [JOB_PORTAL_DB].[dbo].[Applicant_Work_History]
                        SET Applicant = @Applicant,
                            Company_Name = @Company_Name,
                            Country_Code = @Country_Code,
                            Location = @Location,
                            Job_Title = @Job_Title,
                            Job_Description = @Job_Description,
                            Start_Month = @Start_Month,
                            Start_Year = @Start_Year,
                            End_Month = @End_Month,
                            End_year = @End_year
                        where Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", pocoItem.Id);
                    cmd.Parameters.AddWithValue("@Applicant", pocoItem.Applicant);
                    cmd.Parameters.AddWithValue("@Company_Name", pocoItem.CompanyName);
                    cmd.Parameters.AddWithValue("@Country_Code", pocoItem.CountryCode);
                    cmd.Parameters.AddWithValue("@Location", pocoItem.Location);
                    cmd.Parameters.AddWithValue("@Job_Title", pocoItem.JobTitle);
                    cmd.Parameters.AddWithValue("@Job_Description", pocoItem.JobDescription);
                    cmd.Parameters.AddWithValue("@Start_Month", pocoItem.StartMonth);
                    cmd.Parameters.AddWithValue("@Start_Year", pocoItem.StartYear);
                    cmd.Parameters.AddWithValue("@End_Month", pocoItem.EndMonth);
                    cmd.Parameters.AddWithValue("@End_year", pocoItem.EndYear);
                 
                    conn.Open();
                    int rowsEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
