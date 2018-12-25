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
    public class CompanyLocationRepository : BaseADO, IDataRepository<CompanyLocationPoco>
    {
        public void Add(params CompanyLocationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach(CompanyLocationPoco pocoItem in items)
                {
                    cmd.CommandText = @"Insert into [JOB_PORTAL_DB].[dbo].[Company_Locations]
                    ([Id],[Company],[Country_Code],[State_Province_Code],[Street_Address],[City_Town],[Zip_Postal_Code])
                    values(@Id,@Company,@Country_Code,@State_Province_Code,@Street_Address,@City_Town,@Zip_Postal_Code)";
                    cmd.Parameters.AddWithValue("@Id",pocoItem.Id);
                    cmd.Parameters.AddWithValue("@Company",pocoItem.Company);
                    cmd.Parameters.AddWithValue("@Country_Code",pocoItem.CountryCode);
                    cmd.Parameters.AddWithValue("@State_Province_Code",pocoItem.Province);
                    cmd.Parameters.AddWithValue("@Street_Address",pocoItem.Street);
                    cmd.Parameters.AddWithValue("@City_Town",pocoItem.City);
                    cmd.Parameters.AddWithValue("@Zip_Postal_Code",pocoItem.PostalCode);
                  

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

        public IList<CompanyLocationPoco> GetAll(params System.Linq.Expressions.Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            CompanyLocationPoco[] pocos = new CompanyLocationPoco[500];
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("Select * from [JOB_PORTAL_DB].[dbo].[Company_Locations]", conn);
                conn.Open();
                int position = 0;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CompanyLocationPoco poco = new CompanyLocationPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Company = reader.GetGuid(1);
                    poco.CountryCode = reader.GetString(2);
                    if (!reader.IsDBNull(3))
                    {
                        poco.Province = reader.GetString(3);
                    }
                    else
                    {
                        poco.Province = null;
                    }
                    if (!reader.IsDBNull(4))
                    {
                        poco.Street = reader.GetString(4);
                    }
                    else
                    {
                        poco.Street = null;
                    }
                    if (!reader.IsDBNull(5))
                    {
                        poco.City = reader.GetString(5);
                    }
                    else
                    {
                        poco.City = null;
                    }
                    if (!reader.IsDBNull(6))
                    {
                        poco.PostalCode = reader.GetString(6);
                    }
                    else
                    {
                        poco.PostalCode = null;
                    }
                    poco.TimeStamp = (byte[])reader[7];
                    pocos[position++] = poco;
                }
                conn.Close();
            }
            return pocos.Where(a => a != null).ToList();
        }

        public IList<CompanyLocationPoco> GetList(System.Linq.Expressions.Expression<Func<CompanyLocationPoco, bool>> where, params System.Linq.Expressions.Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyLocationPoco GetSingle(System.Linq.Expressions.Expression<Func<CompanyLocationPoco, bool>> where, params System.Linq.Expressions.Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyLocationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyLocationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (CompanyLocationPoco pocoItem in items)
                {
                    cmd.CommandText = @"Delete from [JOB_PORTAL_DB].[dbo].[Company_Locations]
                     where Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", pocoItem.Id);
                    
                    conn.Open();
                    int noOfRows = cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }

        public void Update(params CompanyLocationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (CompanyLocationPoco pocoItem in items)
                {
                    cmd.CommandText = @"Update  [JOB_PORTAL_DB].[dbo].[Company_Locations]
                        set Company = @Company,
                            Country_Code = @Country_Code,
                            State_Province_Code = @State_Province_Code,
                            Street_Address = @Street_Address,
                            City_Town = @City_Town,
                            Zip_Postal_Code = @Zip_Postal_Code
                            where Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", pocoItem.Id);
                    cmd.Parameters.AddWithValue("@Company", pocoItem.Company);
                    cmd.Parameters.AddWithValue("@Country_Code", pocoItem.CountryCode);
                    cmd.Parameters.AddWithValue("@State_Province_Code", pocoItem.Province);
                    cmd.Parameters.AddWithValue("@Street_Address", pocoItem.Street);
                    cmd.Parameters.AddWithValue("@City_Town", pocoItem.City);
                    cmd.Parameters.AddWithValue("@Zip_Postal_Code", pocoItem.PostalCode);
                   
                    conn.Open();
                    int noOfRows = cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }
    }
}

