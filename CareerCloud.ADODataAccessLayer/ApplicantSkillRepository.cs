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
    public class ApplicantSkillRepository : BaseADO, IDataRepository<ApplicantSkillPoco>
    {
        public void Add(params ApplicantSkillPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                foreach (ApplicantSkillPoco pocoItem in items)
                {
                    cmd.CommandText = @"Insert into  [JOB_PORTAL_DB].[dbo].[Applicant_Skills] 
                                   ([Id],[Applicant],[Skill],[Skill_Level],[Start_Month],[Start_Year],[End_Month],[End_Year])
                                values(@Id,@Applicant,@Skill,@Skill_Level,@Start_Month,@Start_Year,@End_Month,@End_year)";
                    cmd.Parameters.AddWithValue("@Id",pocoItem.Id);
                    cmd.Parameters.AddWithValue("@Applicant", pocoItem.Applicant);
                    cmd.Parameters.AddWithValue("@Skill",pocoItem.Skill);
                    cmd.Parameters.AddWithValue("@Skill_Level",pocoItem.SkillLevel);
                    cmd.Parameters.AddWithValue("@Start_Month", pocoItem.StartMonth);
                    cmd.Parameters.AddWithValue("@Start_Year",pocoItem.StartYear);
                    cmd.Parameters.AddWithValue("@End_Month",pocoItem.EndMonth);
                    cmd.Parameters.AddWithValue("@End_Year", pocoItem.EndYear);
                   
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

        public IList<ApplicantSkillPoco> GetAll(params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            ApplicantSkillPoco[] pocos = new ApplicantSkillPoco[500];

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("select * from [JOB_PORTAL_DB].[dbo].[Applicant_Skills] ", conn);
                conn.Open(); 
                SqlDataReader reader = cmd.ExecuteReader();
                int position = 0;
                while (reader.Read())
                { 
                    ApplicantSkillPoco poco = new ApplicantSkillPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Applicant = reader.GetGuid(1);
                    poco.Skill = reader.GetString(2);
                    poco.SkillLevel = reader.GetString(3);
                    poco.StartMonth = reader.GetByte(4);
                    poco.StartYear = reader.GetInt32(5);
                    poco.EndMonth = reader.GetByte(6);
                    poco.EndYear = reader.GetInt32(7);
                    poco.TimeStamp = (byte[])reader[8];
                    pocos[position++] = poco;

                }
            }
            return pocos.Where(a => a != null).ToList();
        }

        public IList<ApplicantSkillPoco> GetList(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantSkillPoco GetSingle(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantSkillPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantSkillPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantSkillPoco pocoItem in items)
                {
                    cmd.CommandText = @"Delete from [JOB_PORTAL_DB].[dbo].[Applicant_Skills]  where Id = @Id";
                    cmd.Parameters.AddWithValue("@Id",pocoItem.Id);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params ApplicantSkillPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantSkillPoco pocoItem in items)
                {
                    cmd.CommandText = @"Update [JOB_PORTAL_DB].[dbo].[Applicant_Skills] 
                            set Applicant = @Applicant,
                                Skill = @Skill,
                                Skill_Level = @Skill_Level,
                                Start_Month = @Start_Month,
                                Start_Year = @Start_Year,
                                End_Month = @End_Month,
                                End_Year = @End_Year
                                where Id =@Id";
                    cmd.Parameters.AddWithValue("@Id", pocoItem.Id);
                    cmd.Parameters.AddWithValue("@Applicant", pocoItem.Applicant);
                    cmd.Parameters.AddWithValue("@Skill", pocoItem.Skill);
                    cmd.Parameters.AddWithValue("@Skill_Level", pocoItem.SkillLevel);
                    cmd.Parameters.AddWithValue("@Start_Month", pocoItem.StartMonth);
                    cmd.Parameters.AddWithValue("@Start_Year", pocoItem.StartYear);
                    cmd.Parameters.AddWithValue("@End_Month", pocoItem.EndMonth);
                    cmd.Parameters.AddWithValue("@End_Year", pocoItem.EndYear);
                   
                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }
    }
}
