using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace projectdeliverable.Models
{
    public class CRUD
    {
        public static string connectionString = "data source=localhost; Initial Catalog=finaldb; Integrated Security=true";

        public static int Login(string emailid, string password)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("login", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@emailid", SqlDbType.VarChar, 20).Value = emailid;
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 20).Value = password;

                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();


                result = Convert.ToInt32(cmd.Parameters["@result"].Value);
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1;
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public static List<emailitem> showinbox(string id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;


            try
            {
                cmd = new SqlCommand("displayinbox", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@eid", SqlDbType.VarChar, 20).Value = id;
                List<emailitem> l = new List<emailitem>();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    emailitem adder = new emailitem();
                    adder.sender = rdr["sender"].ToString();
                    adder.time = rdr["timeofmail"].ToString();
                    adder.esubject = rdr["esubject"].ToString();
                    adder.content = rdr["content"].ToString();
                    adder.id = rdr["mailid"].ToString();

                    l.Add(adder);
                }

                rdr.Close();
                con.Close();

                return l;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }

        }

        public static List<emailitem> showblock(string id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;


            try
            {
                cmd = new SqlCommand("displayblock", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@eid", SqlDbType.VarChar, 20).Value = id;
                List<emailitem> l = new List<emailitem>();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    emailitem adder = new emailitem();
                    adder.sender = rdr["sender"].ToString();
                    adder.time = rdr["timeofmail"].ToString();
                    adder.esubject = rdr["esubject"].ToString();
                    adder.content = rdr["content"].ToString();
                    adder.id = rdr["mailid"].ToString();

                    l.Add(adder);
                }

                rdr.Close();
                con.Close();

                return l;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }

        }

        public static int forgotpassword(string email, string answer, string newpass)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = -5;

            try
            {
                cmd = new SqlCommand("forgotpassword", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@eid", SqlDbType.NVarChar, 20).Value = email;
                cmd.Parameters.Add("@answer", SqlDbType.NVarChar, 20).Value = answer;
                cmd.Parameters.Add("@newpass", SqlDbType.NVarChar, 20).Value = newpass;
                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);

                con.Close();
                return result;
            }
            catch(SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return -3;
            }
        }

        public static List<emailitem> showsent(string id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;


            try
            {
                cmd = new SqlCommand("displaysent", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@eid", SqlDbType.VarChar, 20).Value = id;
                List<emailitem> l = new List<emailitem>();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    emailitem adder = new emailitem();
                    adder.receiver = rdr["receiver"].ToString();
                    adder.time = rdr["timeofmail"].ToString();
                    adder.esubject = rdr["esubject"].ToString();
                    adder.content = rdr["content"].ToString();
                    adder.id = rdr["mailid"].ToString();

                    l.Add(adder);
                }

                rdr.Close();
                con.Close();

                return l;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }

        }

        public static void delmail(string user, string mail)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("deletemail", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@eid", SqlDbType.VarChar, 20).Value = user;
                cmd.Parameters.Add("@mailid", SqlDbType.Int).Value = mail;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public static List<emailitem> showspam(string id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;


            try
            {
                cmd = new SqlCommand("displayspamemails", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@eid", SqlDbType.VarChar, 20).Value = id;
                List<emailitem> l = new List<emailitem>();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    emailitem adder = new emailitem();
                    adder.sender = rdr["sender"].ToString();
                    adder.id = rdr["mailid"].ToString();
                    adder.time = rdr["timeofmail"].ToString();
                    adder.esubject = rdr["esubject"].ToString();
                    adder.content = rdr["content"].ToString();

                    l.Add(adder);
                }

                rdr.Close();
                con.Close();

                return l;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }

        }

        public static List<emailitem> showtrash(string id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;


            try
            {
                cmd = new SqlCommand("displaytrash", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@eid", SqlDbType.VarChar, 20).Value = id;
                List<emailitem> l = new List<emailitem>();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    emailitem adder = new emailitem();
                    adder.sender = rdr["sender"].ToString();
                    adder.id = rdr["mailid"].ToString();
                    adder.time = rdr["timeofmail"].ToString();
                    adder.esubject = rdr["esubject"].ToString();
                    adder.content = rdr["content"].ToString();

                    l.Add(adder);
                }

                rdr.Close();
                con.Close();

                return l;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }

        }


        public static int signup(string fname, string lname, char gender, string email, string pass, string phone, DateTime date, int seq, string qans)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("signup", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@firstn", SqlDbType.VarChar, 20).Value = fname;
                cmd.Parameters.Add("@lastn", SqlDbType.VarChar, 20).Value = lname;
                cmd.Parameters.Add("@dob", SqlDbType.Date).Value = date;
                cmd.Parameters.Add("@gender", SqlDbType.Char, 1).Value = gender;
                cmd.Parameters.Add("@num", SqlDbType.NVarChar, 11).Value = phone;
                cmd.Parameters.Add("@emailid", SqlDbType.VarChar, 20).Value = email;
                cmd.Parameters.Add("@pass", SqlDbType.VarChar, 20).Value = pass;
                cmd.Parameters.Add("@quesno", SqlDbType.Int).Value = seq;
                cmd.Parameters.Add("@ans", SqlDbType.VarChar, 20).Value = qans;

                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                result = Convert.ToInt32(cmd.Parameters["@result"].Value);
            }
            catch(SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -2;
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public static void sendmail(string sender, string receiver, string subject, string content)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("send_email", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@sen", SqlDbType.VarChar,20).Value = sender;
                cmd.Parameters.Add("@rec", SqlDbType.VarChar, 20).Value = receiver;
                cmd.Parameters.Add("@esub", SqlDbType.NVarChar,1000).Value = subject;
                cmd.Parameters.Add("@content", SqlDbType.NVarChar, 4000).Value = content;

                cmd.Parameters.Add("@output", SqlDbType.VarChar,20).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

            }
            catch(SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public static void savedraft(string sender, string receiver, string subject, string content)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("savedraft", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@sen", SqlDbType.VarChar, 20).Value = sender;
                cmd.Parameters.Add("@rec", SqlDbType.VarChar, 20).Value = receiver;
                cmd.Parameters.Add("@esub", SqlDbType.NVarChar, 1000).Value = subject;
                cmd.Parameters.Add("@content", SqlDbType.NVarChar, 4000).Value = content;

                cmd.Parameters.Add("@output", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public static List<emailitem> showdrafts(string id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;


            try
            {
                cmd = new SqlCommand("displaydrafts", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@eid", SqlDbType.VarChar, 20).Value = id;
                List<emailitem> l = new List<emailitem>();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    emailitem adder = new emailitem();
                    adder.receiver = rdr["receiver"].ToString();
                    adder.id = rdr["mailid"].ToString();
                    adder.time = rdr["timeofmail"].ToString();
                    adder.esubject = rdr["esubject"].ToString();
                    adder.content = rdr["content"].ToString();

                    l.Add(adder);
                }

                rdr.Close();
                con.Close();

                return l;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }

        }

        public static List<string> showblockedusers(string id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;


            try
            {
                cmd = new SqlCommand("displayblockedusers", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@eid", SqlDbType.VarChar, 20).Value = id;
                List<string> l = new List<string>();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string adder;
                    adder = rdr["blockedad"].ToString();
                    l.Add(adder);
                }

                rdr.Close();
                con.Close();

                return l;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }

        }

        public static List<string> showspammers(string id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;


            try
            {
                cmd = new SqlCommand("displayspammers", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@eid", SqlDbType.VarChar, 20).Value = id;
                List<string> l = new List<string>();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string adder;
                    adder = rdr["spammer"].ToString();
                    l.Add(adder);
                }

                rdr.Close();
                con.Close();

                return l;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }

        }

        public static void blockid(string blocker, string blocked)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("blockid", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@eid", SqlDbType.VarChar, 20).Value = blocker;
                cmd.Parameters.Add("@block", SqlDbType.VarChar, 20).Value = blocked;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }

        }


        public static void spamid(string user, string spammer)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("addspam", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@rec", SqlDbType.VarChar, 20).Value = user;
                cmd.Parameters.Add("@sp", SqlDbType.VarChar, 20).Value = spammer;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }

        }

        public static List<user> showuser(string id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;


            try
            {
                cmd = new SqlCommand("showuser", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@eid", SqlDbType.VarChar, 20).Value = id;
                user adder = new user();
                List <user> l = new List<user>();

                cmd.Parameters.Add("@userid", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@fname", SqlDbType.NVarChar,50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@lname", SqlDbType.NVarChar,50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@dob", SqlDbType.Date).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@doj", SqlDbType.Date).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@gender", SqlDbType.Char,1).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@phoneno", SqlDbType.NVarChar,11).Direction = ParameterDirection.Output;


                cmd.ExecuteNonQuery();

                adder.userid = Convert.ToString(cmd.Parameters["@userid"].Value);
                adder.fname = Convert.ToString(cmd.Parameters["@fname"].Value);
                adder.lname = Convert.ToString(cmd.Parameters["@lname"].Value);
                adder.dob = Convert.ToString(cmd.Parameters["@dob"].Value);
                adder.doj = Convert.ToString(cmd.Parameters["@doj"].Value);
                adder.gender = Convert.ToString(cmd.Parameters["@gender"].Value);
                adder.phone = Convert.ToString(cmd.Parameters["@phoneno"].Value);

                l.Add(adder);
                con.Close();

                return l;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }

        }



        public static int editp(string email, string fname, string lname, string phone1, DateTime dob, string pass)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;
            try
            {
                cmd = new SqlCommand("editprofile", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@eid", SqlDbType.NVarChar, 20).Value = email;
                cmd.Parameters.Add("@newdob", SqlDbType.DateTime).Value = dob;
                cmd.Parameters.Add("@newphone", SqlDbType.NVarChar,11).Value = phone1;
                cmd.Parameters.Add("@newfname", SqlDbType.NVarChar, 50).Value = fname;
                cmd.Parameters.Add("@newlname", SqlDbType.NVarChar, 50).Value = lname;
                cmd.Parameters.Add("@pass", SqlDbType.NVarChar, 20).Value = pass;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                result = Convert.ToInt32(cmd.Parameters["@output"].Value);
                return result;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return -1;
            }
            finally
            {
                con.Close();
            }
        }


        public static int delblocked(string user, string id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("delblocked", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@eid", SqlDbType.NVarChar, 20).Value = user;
                cmd.Parameters.Add("@blocked", SqlDbType.NVarChar, 20).Value = id;
               
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return -1;
            }
            finally
            {
                con.Close();
            }
        }

        public static int delspammer(string user, string id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("delspammer", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@eid", SqlDbType.NVarChar, 20).Value = user;
                cmd.Parameters.Add("@spammer", SqlDbType.NVarChar, 20).Value = id;

                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return -1;
            }
            finally
            {
                con.Close();
            }
        }
    }
}