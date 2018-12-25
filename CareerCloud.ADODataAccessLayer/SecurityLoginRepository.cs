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
    public class SecurityLoginRepository : BaseADO, IDataRepository<SecurityLoginPoco>
    {
        public void Add(params SecurityLoginPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                foreach(SecurityLoginPoco pocoItem in items)
                {
                    cmd.CommandText = @"Insert into [JOB_PORTAL_DB].[dbo].[Security_Logins]
                        ([Id],[Login],[Password],[Created_Date],[Password_Update_Date],[Agreement_Accepted_Date],[Is_Locked],[Is_Inactive],[Email_Address],[Phone_Number],[Full_Name],[Force_Change_Password],[Prefferred_Language])
                        Values(@Id,@Login,@Psw,@createDt,@PassUpdateDt,@AcceptDt,@IsLock,@IsInactive,@EmailAddr,@PhNum,@FullName,@ChangePass,@PreferLang)";
                    cmd.Parameters.AddWithValue("@Id",pocoItem.Id);
                    cmd.Parameters.AddWithValue("@Login",pocoItem.Login);
                    cmd.Parameters.AddWithValue("@Psw", pocoItem.Password);
                    cmd.Parameters.AddWithValue("@createDt",pocoItem.Created);
                    cmd.Parameters.AddWithValue("@PassUpdateDt",pocoItem.PasswordUpdate);
                    cmd.Parameters.AddWithValue("@AcceptDt",pocoItem.AgreementAccepted);
                    cmd.Parameters.AddWithValue("@IsLock",pocoItem.IsLocked);
                    cmd.Parameters.AddWithValue("@IsInactive",pocoItem.IsInactive);
                    cmd.Parameters.AddWithValue("@EmailAddr",pocoItem.EmailAddress);
                    cmd.Parameters.AddWithValue("@PhNum",pocoItem.PhoneNumber);
                    cmd.Parameters.AddWithValue("@FullName",pocoItem.FullName);
                    cmd.Parameters.AddWithValue("@ChangePass",pocoItem.ForceChangePassword);
                    cmd.Parameters.AddWithValue("@PreferLang",pocoItem.PrefferredLanguage);
                    
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

        public IList<SecurityLoginPoco> GetAll(params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            SecurityLoginPoco[] pocos = new SecurityLoginPoco [500];
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("select * from [JOB_PORTAL_DB].[dbo].[Security_Logins]", conn);
                conn.Open();
                int position = 0;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SecurityLoginPoco poco = new SecurityLoginPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Login = reader.GetString(1);
                    poco.Password = reader.GetString(2);
                    poco.Created = reader.GetDateTime(3);
                    if (! reader.IsDBNull(4))
                    {
                        poco.PasswordUpdate = reader.GetDateTime(4);
                    }
                    else
                    {
                        poco.PasswordUpdate = null;
                    }
                    if (!reader.IsDBNull(5))
                    {
                        poco.AgreementAccepted = reader.GetDateTime(5);
                    }
                    else
                    {
                        poco.AgreementAccepted = null;
                    }
                    poco.IsLocked = reader.GetBoolean(6);
                    poco.IsInactive = reader.GetBoolean(7);
                    poco.EmailAddress = reader.GetString(8);
                    if (!reader.IsDBNull(9))
                    {
                        poco.PhoneNumber = reader.GetString(9);
                    }
                    else
                    {
                        poco.PhoneNumber = null;
                    }
                    if (!reader.IsDBNull(10))
                    {
                        poco.FullName = reader.GetString(10);
                    }
                    else
                    {
                        poco.FullName = null;
                    }
                    poco.ForceChangePassword = reader.GetBoolean(11);
                   
                    if (!reader.IsDBNull(12))
                    {
                        poco.PrefferredLanguage = reader.GetString(12);
                    }
                    else
                    {
                        poco.PrefferredLanguage = null;
                    }
                    poco.TimeStamp = (byte[] )reader[13];

                    pocos[position++] = poco;

                }
                conn.Close();
            }
            return pocos.Where(a => a!=null).ToList();
        }

        public IList<SecurityLoginPoco> GetList(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginPoco GetSingle(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SecurityLoginPoco pocoItem in items)
                {
                   
                    cmd.CommandText = @"Delete from [JOB_PORTAL_DB].[dbo].[Security_Logins] where Id =@Id";
                    cmd.Parameters.AddWithValue("@Id",pocoItem.Id);

                    conn.Open();
                    int noOfRows = cmd.ExecuteNonQuery();
                    conn.Close();

                }
            }
        }

        public void Update(params SecurityLoginPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SecurityLoginPoco pocoItem in items)
                {
                    
                    cmd.CommandText = @"Update  [JOB_PORTAL_DB].[dbo].[Security_Logins] 
                        set Login =@Login,
                            Password = @Psw,
                            Created_Date = @CreateDt,
                            Password_Update_Date = @PassUpdateDt,
                            Agreement_Accepted_Date = @AcceptDt,
                            Is_Locked = @IsLock,
                            IS_Inactive = @IsInactive,
                            Email_Address = @EmailAddr,
                            Phone_Number = @PhNum,
                            Full_Name = @FullName,
                            Force_Change_Password = @ChangePass,
                            Prefferred_Language = @PreferLang
                            where Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", pocoItem.Id);
                    cmd.Parameters.AddWithValue("@Login", pocoItem.Login);
                    cmd.Parameters.AddWithValue("@Psw", pocoItem.Password);
                    cmd.Parameters.AddWithValue("@createDt", pocoItem.Created);
                    cmd.Parameters.AddWithValue("@PassUpdateDt", pocoItem.PasswordUpdate);
                    cmd.Parameters.AddWithValue("@AcceptDt", pocoItem.AgreementAccepted);
                    cmd.Parameters.AddWithValue("@IsLock", pocoItem.IsLocked);
                    cmd.Parameters.AddWithValue("@IsInactive", pocoItem.IsInactive);
                    cmd.Parameters.AddWithValue("@EmailAddr", pocoItem.EmailAddress);
                    cmd.Parameters.AddWithValue("@PhNum", pocoItem.PhoneNumber);
                    cmd.Parameters.AddWithValue("@FullName", pocoItem.FullName);
                    cmd.Parameters.AddWithValue("@ChangePass", pocoItem.ForceChangePassword);
                    cmd.Parameters.AddWithValue("@PreferLang", pocoItem.PrefferredLanguage);

                    conn.Open();
                    int noOfRows = cmd.ExecuteNonQuery();
                    conn.Close();

                }
            }
        }
    }
}
