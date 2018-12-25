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
    public class ApplicantResumeRepository : BaseADO, IDataRepository<ApplicantResumePoco>
    {
        public void Add(params ApplicantResumePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach(ApplicantResumePoco pocoItem in items)
                {
                    cmd.CommandText = @"Insert into [JOB_PORTAL_DB].[dbo].[Applicant_Resumes]
                    ([Id],[Applicant],[Resume],[Last_Updated])
                    values(@Id,@Applicant,@Resume,@Last_Updated)";
                    cmd.Parameters.AddWithValue("@Id",pocoItem.Id);
                    cmd.Parameters.AddWithValue("@Applicant",pocoItem.Applicant);
                    cmd.Parameters.AddWithValue("@Resume",pocoItem.Resume);
                    cmd.Parameters.AddWithValue("@Last_Updated",pocoItem.LastUpdated);

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

        public IList<ApplicantResumePoco> GetAll(params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            ApplicantResumePoco[] pocos = new ApplicantResumePoco[55];
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("Select * from [JOB_PORTAL_DB].[dbo].[Applicant_Resumes]", conn);
                conn.Open();
                int position = 0;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ApplicantResumePoco poco = new ApplicantResumePoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Applicant = reader.GetGuid(1);
                    poco.Resume = reader.GetString(2);
                    // poco.LastUpdated = reader.IsDBNull(3) ? null : (DateTime?)reader.GetDateTime(3) ;
                    if (!reader.IsDBNull(3))
                    {
                        poco.LastUpdated = reader.GetDateTime(3);
                    }
                    else
                    {
                        poco.LastUpdated = null;
                    }
                    pocos[position++] = poco;
                }
                conn.Close();
            }
            return pocos.Where(a => a != null).ToList();
        }

        public IList<ApplicantResumePoco> GetList(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantResumePoco GetSingle(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantResumePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantResumePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantResumePoco pocoItem in items)
                {
                    cmd.CommandText = @"Delete from [JOB_PORTAL_DB].[dbo].[Applicant_Resumes] 
                        where Id = @Id";
                    cmd.Parameters.AddWithValue("@Id",pocoItem.Id);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params ApplicantResumePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantResumePoco pocoItem in items)
                {
                    cmd.CommandText = @"Update [JOB_PORTAL_DB].[dbo].[Applicant_Resumes]
                                        set Applicant = @Applicant,
                                            Resume = @Resume,
                                            Last_Updated = @Last_Updated
                                        where Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", pocoItem.Id);
                    cmd.Parameters.AddWithValue("@Applicant", pocoItem.Applicant);
                    cmd.Parameters.AddWithValue("@Resume", pocoItem.Resume);
                    cmd.Parameters.AddWithValue("@Last_Updated", pocoItem.LastUpdated);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
