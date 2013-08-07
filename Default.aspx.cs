using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    /// <summary>
    /// Only for initial insert of the names in the database
    /// </summary>
    protected void InsertNamesIntoDatabase()
    {
        DataBase db = new DataBase();
        SqlConnection conn = db.Connection();

        string line;
        string name = "";
        int number = 0;

        StreamReader file = new StreamReader("C:\\Users\\Pesanski\\Documents\\Visual Studio 2010\\Projects\\RecordsCollectorApp\\RecordsCollectorApp\\data\\names_num.txt");
        while ((line = file.ReadLine()) != null)
        {
            string[] pom = line.Split(' ');
            name = pom[0];
            number = Convert.ToInt32(pom[1]);

            conn = db.Connection();

            SqlCommand cmd = db.GetCommand(conn, "dbo.InitialNamesInsert");

            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@NumOfItems", number);

            try
            {
                conn.Open();
                int k = cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                string error = err.Message;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }

        file.Close();
    }

    protected DataSet GetAllNames()
    {
        DataBase db = new DataBase();
        SqlConnection conn = db.Connection();
        SqlCommand cmd = db.GetCommand(conn, "dbo.SelectAllNames");
        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        try
        {
            conn.Open();
            da.Fill(ds, "NamesOrdered");
        }
        catch (Exception err)
        {
            string error = err.Message;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }

        return ds;

    }    
}