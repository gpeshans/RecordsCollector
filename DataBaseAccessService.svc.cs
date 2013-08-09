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
        public NameClass LoadNameData(string Sex)
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

            if (ds.Tables["Names"].Rows.Count == 0)
            {
                return null;
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
        public NameClass LoadNextName(NameClass CurrentName)
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

            if (ds.Tables["Names"].Rows.Count == 0)
            {
                return null;
            }

            int OrderNo = 0;

            for (int i = 0; i < ds.Tables["Names"].Rows.Count; i++)
            {
                if (ds.Tables["Names"].Rows[i][0].ToString() == CurrentName.FirstName)
                {
                    i++;
                    OrderNo = i;
                    break;
                }
            }

            NameClass NameObject = new NameClass();
            NameObject.FirstName = ds.Tables["Names"].Rows[OrderNo][0].ToString();
            NameObject.Male = Convert.ToInt16(ds.Tables["Names"].Rows[OrderNo][2].ToString());
            NameObject.Female = Convert.ToInt16(ds.Tables["Names"].Rows[OrderNo][3].ToString());

            return NameObject;
        }

        [OperationContract]
        public void UpdateNames(NameClass NameObject, string Sex)
        {
            string FirstName = NameObject.FirstName;
            int Male = NameObject.Male;
            int Female = NameObject.Female;

            if (Sex == "Male")
            {
                Male++;
            }
            else
            {
                Female++;
            }

            SqlConnection connection = db.Connection();
            SqlCommand command = db.GetCommand(connection, "dbo.UpdateNames");

            command.Parameters.AddWithValue("@Name", FirstName);
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

        [OperationContract]
        public int CountNamesRecords()
        {
            SqlConnection connection = db.Connection();
            SqlCommand command = db.GetCommand(connection, "dbo.CountNamesRecords");

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                da.Fill(ds, "NamesRecordsCount");
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

            if (ds.Tables["NamesRecordsCount"].Rows.Count == 0)
            {
                return 0;
            }

            return Convert.ToInt16(ds.Tables["NamesRecordsCount"].Rows[0][0].ToString()); ;
        }

        [OperationContract]
        public NumberClass LoadNumberData(string Sex)
        {
            SqlConnection connection = db.Connection();
            SqlCommand command = db.GetCommand(connection, "dbo.SelectAllNumbers");

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                da.Fill(ds, "Numbers");
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

            if (ds.Tables["Numbers"].Rows.Count == 0)
            {
                return null;
            }

            int OrderNo = 0;
            if (Sex == "Male")
            {
                while (Convert.ToInt16(ds.Tables["Numbers"].Rows[OrderNo][2].ToString()) >= 50)
                {
                    OrderNo++;
                }
            }
            else
            {
                while (Convert.ToInt16(ds.Tables["Numbers"].Rows[OrderNo][3].ToString()) >= 50)
                {
                    OrderNo++;
                }
            }

            NumberClass NumberObject = new NumberClass();
            NumberObject.Number = ds.Tables["Numbers"].Rows[OrderNo][0].ToString();
            NumberObject.Male = Convert.ToInt16(ds.Tables["Numbers"].Rows[OrderNo][1].ToString());
            NumberObject.Female = Convert.ToInt16(ds.Tables["Numbers"].Rows[OrderNo][2].ToString());

            return NumberObject;
        }

        [OperationContract]
        public NumberClass LoadNextNumber(NumberClass CurrentNumber)
        {
            SqlConnection connection = db.Connection();
            SqlCommand command = db.GetCommand(connection, "dbo.SelectAllNumbers");

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                da.Fill(ds, "Numbers");
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

            if (ds.Tables["Numbers"].Rows.Count == 0)
            {
                return null;
            }

            int OrderNo = 0;

            for (int i = 0; i < ds.Tables["Numbers"].Rows.Count; i++)
            {
                if (ds.Tables["Numbers"].Rows[i][0].ToString() == CurrentNumber.Number)
                {
                    i++;
                    OrderNo = i;
                    break;
                }
            }

            NumberClass NumberObject = new NumberClass();
            NumberObject.Number = ds.Tables["Numbers"].Rows[OrderNo][0].ToString();
            NumberObject.Male = Convert.ToInt16(ds.Tables["Numbers"].Rows[OrderNo][1].ToString());
            NumberObject.Female = Convert.ToInt16(ds.Tables["Numbers"].Rows[OrderNo][2].ToString());

            return NumberObject;
        }

        [OperationContract]
        public void UpdateNumbers(NumberClass NumberObject, string Sex)
        {
            string Number = NumberObject.Number;
            int Male = NumberObject.Male;
            int Female = NumberObject.Female;

            if (Sex == "Male")
            {
                Male++;
            }
            else
            {
                Female++;
            }

            SqlConnection connection = db.Connection();
            SqlCommand command = db.GetCommand(connection, "dbo.UpdateNumbers");

            command.Parameters.AddWithValue("@Number", Number);
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

        [OperationContract]
        public int CountNumbersRecords()
        {
            SqlConnection connection = db.Connection();
            SqlCommand command = db.GetCommand(connection, "dbo.CountNumbersRecords");

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                da.Fill(ds, "NumbersRecordsCount");
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

            if (ds.Tables["NumbersRecordsCount"].Rows.Count == 0)
            {
                return 0;
            }

            return Convert.ToInt16(ds.Tables["NumbersRecordsCount"].Rows[0][0].ToString()); ;
        }
    }

    public class NameClass
    {
        public string FirstName { get; set; }
        public int Male { get; set; }
        public int Female { get; set; }
    }

    public class NumberClass
    {
        public string Number { get; set; }
        public int Male { get; set; }
        public int Female { get; set; }
    }
}
