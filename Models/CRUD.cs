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
        public static string connectionString = "data source=localhost; Initial Catalog=dbprojectnewaf; Integrated Security=true";

        public static int Login(string emailid, string password)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("signin", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@emailid", SqlDbType.NVarChar, 20).Value = emailid;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar, 20).Value = password;

                cmd.Parameters.Add("@email", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();


                result = Convert.ToInt32(cmd.Parameters["@email"].Value);
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


        public static int signup(string fname, string lname, char gender, string email, string pass, string phone, string date, int seq, string qans)
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
                cmd.Parameters.Add("@num", SqlDbType.Int).Value = phone;
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
                result = -1;
            }
            finally
            {
                con.Close();
            }
            return result;
        }

    }
}