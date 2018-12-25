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
    public class CompanyProfileRepository : BaseADO, IDataRepository<CompanyProfilePoco>
    {
        public void Add(params CompanyProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (CompanyProfilePoco pocoItem in items)
                {
                    cmd.CommandText = @"Insert into [JOB_PORTAL_DB].[dbo].[Company_Profiles]
                        ([Id],[Registration_Date],[Company_Website],[Contact_Phone],[Contact_Name],[Company_Logo])
                        values(@Id,@Registration_Date,@Company_Website,@Contact_Phone,@Contact_Name,@Company_Logo)";
                    cmd.Parameters.AddWithValue("@Id",pocoItem.Id);
                    cmd.Parameters.AddWithValue("@Registration_Date",pocoItem.RegistrationDate);
                    cmd.Parameters.AddWithValue("@Company_Website",pocoItem.CompanyWebsite);
                    cmd.Parameters.AddWithValue("@Contact_Phone",pocoItem.ContactPhone);
                    cmd.Parameters.AddWithValue("@Contact_Name",pocoItem.ContactName);
                    cmd.Parameters.AddWithValue("@Company_Logo",pocoItem.CompanyLogo);
                   
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

        public IList<CompanyProfilePoco> GetAll(params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            CompanyProfilePoco[] pocos = new CompanyProfilePoco[500];
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("Select * from [JOB_PORTAL_DB].[dbo].[Company_Profiles]", conn);
                conn.Open();
                int position = 0;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CompanyProfilePoco poco = new CompanyProfilePoco();
                    poco.Id = reader.GetGuid(0);
                    poco.RegistrationDate = reader.GetDateTime(1);
                    if (!reader.IsDBNull(2))
                    {
                        poco.CompanyWebsite = reader.GetString(2);
                    }
                    else
                    {
                        poco.CompanyWebsite = null;
                    }
                    poco.ContactPhone = reader.GetString(3);
                    if (!reader.IsDBNull(4))
                    {
                        poco.ContactName = reader.GetString(4);
                    }
                    else
                    {
                        poco.ContactName = null;
                    }
                    if (!reader.IsDBNull(5))
                    {
                        poco.CompanyLogo = (byte[])reader[5];
                    }
                    else
                    {
                        poco.CompanyLogo = null;
                    }
                    if (!reader.IsDBNull(6))
                    {
                        poco.TimeStamp = (byte[])reader[6];
                    }
                    else
                    {
                        poco.TimeStamp = null;
                    }
                    pocos[position++] = poco;
                }
                conn.Close();
            }
            return pocos.Where(a => a != null).ToList();
        }

        public IList<CompanyProfilePoco> GetList(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyProfilePoco GetSingle(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyProfilePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (CompanyProfilePoco pocoItem in items)
                {
                    cmd.CommandText = @"Delete from [JOB_PORTAL_DB].[dbo].[Company_Profiles]
                        where Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", pocoItem.Id);
                   
                    conn.Open();
                    int noOfRows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params CompanyProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (CompanyProfilePoco pocoItem in items)
                {
                    cmd.CommandText = @"Update  [JOB_PORTAL_DB].[dbo].[Company_Profiles]
                       set Registration_Date = @Registration_Date,
                            Company_Website = @Company_Website,
                            Contact_Phone = @Contact_Phone,
                            Contact_Name = @Contact_Name,
                            Company_Logo = @Company_Logo
                            where Id = @Id";
                        
                    cmd.Parameters.AddWithValue("@Id", pocoItem.Id);
                    cmd.Parameters.AddWithValue("@Registration_Date", pocoItem.RegistrationDate);
                    cmd.Parameters.AddWithValue("@Company_Website", pocoItem.CompanyWebsite);
                    cmd.Parameters.AddWithValue("@Contact_Phone", pocoItem.ContactPhone);
                    cmd.Parameters.AddWithValue("@Contact_Name", pocoItem.ContactName);
                    cmd.Parameters.AddWithValue("@Company_Logo", pocoItem.CompanyLogo);
                    
                    conn.Open();
                    int noOfRows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
