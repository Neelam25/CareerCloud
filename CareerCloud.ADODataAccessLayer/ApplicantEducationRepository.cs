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
    public class ApplicantEducationRepository : BaseADO, IDataRepository<ApplicantEducationPoco>
    {
        public void Add(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach(ApplicantEducationPoco pocoItem in items)
                {
                    cmd.CommandText = @"Insert into [JOB_PORTAL_DB].[dbo].[Applicant_Educations]
                        ([Id],[Applicant],[Major],[Certificate_Diploma],[Start_Date],[Completion_Date],[Completion_Percent])
                    values(@Id,@Applicant,@Major,@CertificateDiploma,@StartDate,@CompletionDate,@CompletionPercent)";
                    cmd.Parameters.AddWithValue("@Id", pocoItem.Id);
                    cmd.Parameters.AddWithValue("@Applicant",pocoItem.Applicant);
                    cmd.Parameters.AddWithValue("@Major",pocoItem.Major);
                    cmd.Parameters.AddWithValue("@CertificateDiploma",pocoItem.CertificateDiploma);
                    cmd.Parameters.AddWithValue("@StartDate",pocoItem.StartDate);
                    cmd.Parameters.AddWithValue("@CompletionDate",pocoItem.CompletionDate);
                    cmd.Parameters.AddWithValue("@CompletionPercent", pocoItem.CompletionPercent);
                   // cmd.Parameters.AddWithValue("@Time_Stamp", pocoItem.TimeStamp);
                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantEducationPoco> GetAll(params System.Linq.Expressions.Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            ApplicantEducationPoco[] pocos = new ApplicantEducationPoco[500];
            using ( SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("select * from [JOB_PORTAL_DB].[dbo].[Applicant_Educations]", conn);
                conn.Open();
                int position = 0;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ApplicantEducationPoco poco = new ApplicantEducationPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Applicant = (Guid)reader[1];
                    poco.Major = (string)reader[2];
                    if (!reader.IsDBNull(5))
                    {
                        poco.CertificateDiploma = (string)reader[3];
                    }
                    else
                    {
                        poco.CertificateDiploma = null;
                    }
                        
                    poco.StartDate = reader.IsDBNull(4) ?  null : (DateTime?)reader.GetDateTime(4) ;
                    if (!reader.IsDBNull(5))
                    {
                        poco.CompletionDate = reader.GetDateTime(5);
                    }
                    else
                    {
                        poco.CompletionDate = null;
                    }
                    poco.CompletionPercent = reader.IsDBNull(6)? null: (byte?)reader[6];
                    poco.TimeStamp = (byte[])reader[7];

                    pocos[position++] = poco;
                }
                conn.Close();
            }
            
            return pocos.Where(a => a != null).ToList();
        }

        public IList<ApplicantEducationPoco> GetList(System.Linq.Expressions.Expression<Func<ApplicantEducationPoco, bool>> where, params System.Linq.Expressions.Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantEducationPoco GetSingle(System.Linq.Expressions.Expression<Func<ApplicantEducationPoco, bool>> where, params System.Linq.Expressions.Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantEducationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();

        }


        public void Remove(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantEducationPoco pocoItem in items)
                {
                    cmd.CommandText = @"DELETE FROM [JOB_PORTAL_DB].[dbo].[Applicant_Educations] where Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", pocoItem.Id);
                }
                conn.Open();
                int numOfRows = cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void Update(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach(ApplicantEducationPoco poco in items)
                {
                    cmd.CommandText = @"UPDATE [JOB_PORTAL_DB].[dbo].[Applicant_Educations]
                    SET Applicant = @Applicant,
                        Major = @Major,
                        Certificate_Diploma = @CertDiploma,
                        Start_Date = @StartDate,
                        Completion_Date= @compDate,
                        Completion_Percent = @compPercent
                        where Id = @Id";
                    cmd.Parameters.AddWithValue("@Applicant",poco.Applicant);
                    cmd.Parameters.AddWithValue("@Major",poco.Major);
                    cmd.Parameters.AddWithValue("@CertDiploma", poco.CertificateDiploma);
                    cmd.Parameters.AddWithValue("@StartDate", poco.StartDate);
                    cmd.Parameters.AddWithValue("@compDate", poco.CompletionDate);
                    cmd.Parameters.AddWithValue("@compPercent", poco.CompletionPercent);
                    cmd.Parameters.AddWithValue("@Id",poco.Id);
                    conn.Open();
                    int numOfRows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
               
            }
        }
    }
}
