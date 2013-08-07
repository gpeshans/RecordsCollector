using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace RecordsCollectorApp
{
    [ServiceContract(Namespace = "NamesService")]
    [SilverlightFaultBehavior]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class DataBaseAccessService
    {
        DataBase db = new DataBase();        

        [OperationContract]
        public NameClass LoadData(string Sex)
        {
            SqlConnection connection = db.Connection();
            SqlCommand command = db.GetCommand(connection, "dbo.SelectAllNames");           

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                da.Fill(ds, "Names");
            }
            catch (Exception err)
            {
                Debug.WriteLine(err);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }

            int OrderNo = 0;
            if (Sex == "Male")
            {
                while (Convert.ToInt16(ds.Tables["Names"].Rows[OrderNo][2].ToString()) >= 50)
                {
                    OrderNo++;
                }
            }
            else
            {
                while (Convert.ToInt16(ds.Tables["Names"].Rows[OrderNo][3].ToString()) >= 50)
                {
                    OrderNo++;
                }
            }

            NameClass NameObject = new NameClass();
            NameObject.FirstName = ds.Tables["Names"].Rows[OrderNo][0].ToString();
            NameObject.Male = Convert.ToInt16(ds.Tables["Names"].Rows[OrderNo][2].ToString());
            NameObject.Female = Convert.ToInt16(ds.Tables["Names"].Rows[OrderNo][3].ToString());
            return NameObject;
        }

        [OperationContract]
        public void Update(NameClass NameObject)
        {
            string FirstName = NameObject.FirstName;
            int Male = NameObject.Male;
            int Female = NameObject.Female;

            SqlConnection connection = db.Connection();
            SqlCommand command = db.GetCommand(connection, "dbo.UpdateNames"); 
  
            command.Parameters.AddWithValue("@Name", FirstName);
            command.Parameters.AddWithValue("@NumOfItems", Male + Female);
            command.Parameters.AddWithValue("@Male", Male);
            command.Parameters.AddWithValue("@Female", Female);
            
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Debug.WriteLine(err);
            }

            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        // Add more operations here and mark them with [OperationContract]
        [OperationContract]
        public int Count()
        {
            return 2;
        }
    }

    public class NameClass
    {
        public string FirstName { get; set; }
        public int Male { get; set; }
        public int Female { get; set; }
    }
    
}
