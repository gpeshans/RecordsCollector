using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for DataBase
/// </summary>
public class DataBase
{    
	public DataBase()
	{
		
	}
   	
    /// <summary>
    /// Funkcija za vospostavuvanje konekcija do bazata na podatoci.
    /// </summary>
    /// <returns>Konekcija do bazata na podatoci.</returns>
    public SqlConnection Connection()
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        return conn;
    }

    public SqlCommand GetCommand(SqlConnection conn, string procedureName)
    {        
        SqlCommand cmd = new SqlCommand(procedureName, conn);        
        cmd.CommandType = CommandType.StoredProcedure;
        
        return cmd;
    }
    
}