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
    public class ApplicantProfileRepository : BaseADO, IDataRepository<ApplicantProfilePoco>
    {
        public void Add(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn
                };

                foreach (ApplicantProfilePoco pocoItem in items)
                {
                    cmd.CommandText = @"Insert into [JOB_PORTAL_DB].[dbo].[Applicant_Profiles]
                    ([Id],[Login],[Current_Salary],[Current_Rate],[Currency],[Country_Code],[State_Province_Code],[Street_Address],[City_Town],[Zip_Postal_Code])
                    values(@Id,@Login,@Current_Salary,@Current_Rate,@Currency,@Country_Code,@State_Province_Code,@Street_Address,@City_Town,@Zip_Postal_Code)";
                    cmd.Parameters.AddWithValue("@Id",pocoItem.Id);
                    cmd.Parameters.AddWithValue("@Login",pocoItem.Login);
                    cmd.Parameters.AddWithValue("@Current_Salary",pocoItem.CurrentSalary);
                    cmd.Parameters.AddWithValue("@Current_Rate",pocoItem.CurrentRate);
                    cmd.Parameters.AddWithValue("@Currency",pocoItem.Currency);
                    cmd.Parameters.AddWithValue("@Country_Code", pocoItem.Country);
                    cmd.Parameters.AddWithValue("@State_Province_Code", pocoItem.Province);
                    cmd.Parameters.AddWithValue("@Street_Address", pocoItem.Street);
                    cmd.Parameters.AddWithValue("@City_Town",pocoItem.City);
                    cmd.Parameters.AddWithValue("@Zip_Postal_Code",pocoItem.PostalCode);
                    
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

        public IList<ApplicantProfilePoco> GetAll(params System.Linq.Expressions.Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            ApplicantProfilePoco[] pocos = new ApplicantProfilePoco[500];
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("Select * from [JOB_PORTAL_DB].[dbo].[Applicant_Profiles]", conn);
                conn.Open();
                int position = 0;
                SqlDataReader reader = cmd.ExecuteReader();
               
                while (reader.Read())
                {
                    ApplicantProfilePoco poco = new ApplicantProfilePoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Login = reader.GetGuid(1);
                    poco.CurrentSalary = (Decimal?)reader.GetDecimal(2) ?? null;
                    poco.CurrentRate = (Decimal?)reader.GetDecimal(3) ?? null;
                    if (!reader.IsDBNull(4))
                    {
                        poco.Currency = reader.GetString(4);
                    }
                    else
                    {
                        poco.Currency = null;
                    }
                    if (!reader.IsDBNull(5))
                    {
                        poco.Country = reader.GetString(5);
                    }
                    else
                    {
                        poco.Country = null;
                    }
                    if (!reader.IsDBNull(6))
                    {
                        poco.Province = reader.GetString(6);
                    }
                    else
                    {
                        poco.Province = null;
                    }
                    if (!reader.IsDBNull(7))
                    {
                        poco.Street = reader.GetString(7);
                    }
                    else
                    {
                        poco.Street = null;
                    }
                    if (!reader.IsDBNull(8))
                    {
                        poco.City = reader.GetString(8);
                    }
                    else
                    {
                        poco.City = null;
                    }
                    if (!reader.IsDBNull(9))
                    {
                        poco.PostalCode = reader.GetString(9);
                    }
                    else
                    {
                        poco.PostalCode = null;
                    }

                    poco.TimeStamp = (byte[])reader[10];
                    pocos[position++] = poco;
                }
                conn.Close();
            
            }
            return pocos.Where(a => a != null).ToList();
        }

        public IList<ApplicantProfilePoco> GetList(System.Linq.Expressions.Expression<Func<ApplicantProfilePoco, bool>> where, params System.Linq.Expressions.Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantProfilePoco GetSingle(System.Linq.Expressions.Expression<Func<ApplicantProfilePoco, bool>> where, params System.Linq.Expressions.Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantProfilePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantProfilePoco pocoItem in items)
                {
                    cmd.CommandText = @"Delete from [JOB_PORTAL_DB].[dbo].[Applicant_Profiles] where Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", pocoItem.Id);
                    conn.Open();
                    int numOfRows = cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }

         public void Update(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantProfilePoco pocoItem in items)
                {
                    cmd.CommandText = @"Update [JOB_PORTAL_DB].[dbo].[Applicant_Profiles]
                        SET Login = @Login,
                            Current_Salary = @Current_Salary,
                            Current_Rate = @Current_Rate,
                            Currency = @Currency,
                            Country_Code = @Country_Code,
                            State_Province_Code = @State_Province_Code,
                            Street_Address = @Street_Address,
                            City_Town = @City_Town,
                            Zip_Postal_Code = @Zip_Postal_Code
                             where @Id =Id";
                    
                    cmd.Parameters.AddWithValue("@Id", pocoItem.Id);
                    cmd.Parameters.AddWithValue("@Login", pocoItem.Login);
                    cmd.Parameters.AddWithValue("@Current_Salary", pocoItem.CurrentSalary);
                    cmd.Parameters.AddWithValue("@Current_Rate", pocoItem.CurrentRate);
                    cmd.Parameters.AddWithValue("@Currency", pocoItem.Currency);
                    cmd.Parameters.AddWithValue("@Country_Code", pocoItem.Country);
                    cmd.Parameters.AddWithValue("@State_Province_Code", pocoItem.Province);
                    cmd.Parameters.AddWithValue("@Street_Address", pocoItem.Street);
                    cmd.Parameters.AddWithValue("@City_Town", pocoItem.City);
                    cmd.Parameters.AddWithValue("@Zip_Postal_Code", pocoItem.PostalCode);
                   
                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
