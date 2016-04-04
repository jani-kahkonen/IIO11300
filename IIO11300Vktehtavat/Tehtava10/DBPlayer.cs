using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava10
{
    class DBPlayer
    {
        public static DataTable GetBooks(string connStr)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connStr))
                {
                    OleDbCommand cmd = new OleDbCommand("SELECT etunimi, sukunimi, seura, arvo, id FROM Pelaajat", conn);

                    conn.Open();

                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable("Pelaajat");

                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateBook(string connStr, string fName, string lName, string price, string group, string id)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connStr))
                {
                    OleDbCommand cmd = new OleDbCommand(@"UPDATE Pelaajat SET [etunimi]=@FName, [sukunimi]=@LName, [arvo]=@Price, [seura]=@Group WHERE [ID]=@Id", conn);

                    conn.Open();

                    cmd.Parameters.AddWithValue("@FName", fName);
                    cmd.Parameters.AddWithValue("@LName", lName);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Group", group);
                    cmd.Parameters.AddWithValue("@Id", id);

                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public static DataTable GetBooks(string connStr)
        //{
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connStr))
        //        {
        //            SqlCommand cmd = new SqlCommand("SELECT id, name, author, country, year FROM books", conn);
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            DataTable dt = new DataTable("Books");
        //            da.Fill(dt);
        //            return dt;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}
