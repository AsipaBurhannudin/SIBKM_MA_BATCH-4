using System.Data.SqlClient;

namespace connection;

public class Program
{
    private static SqlConnection connection;

    private static string connectionString = "Data Source=DESKTOP-K0PBB23; Initial Catalog = db_hr_sibkm; Integrated Security=True;Connect Timeout=30;Encrypt=False;";

    public static void Main()
    {
        /*connection = new SqlConnection(connectionString);
        try
        {
            connection.Open();
            Console.WriteLine("Connection Open");
            connection.Close();
        } catch (Exception e) {
            Console.WriteLine("Connection Failed : " + e);
        }*/

        GetAllRegion();
    }

    //GET ALL
    public static void GetAllRegion()
    {
        //Membuat Instance SQL Server Connection
        connection = new SqlConnection(connectionString);

        //membuat instance sql command
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Select * From regions;";

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Console.WriteLine("Id : " + reader[0]);
                Console.WriteLine("Name : " + reader[1]);
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Region is Empty");
        }
        reader.Close();
        connection.Close();
    }

    //Get BY ID : Regions
    public static void GetById()
    {
        connection = new SqlConnection(connectionString);

        //membuat instance sql command
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Select * From regions where id = @id;";

        //membuat instance sql parameter
        SqlParameter pId = new SqlParameter();
        pId.ParameterName = "@id";
        pId.SqlDbType = System.Data.SqlDbType.Int;
        pId.Value = id;
        command.Parameters.Add(pId);

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            reader.Read();
            {
                Console.WriteLine("Id : " + reader[0]);
                Console.WriteLine("Name : " + reader[1]);
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Region is Empty");
        }
        reader.Close();
        connection.Close();
    }
}