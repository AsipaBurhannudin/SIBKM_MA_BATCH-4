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

        //GetAllRegion();
        //GetByIdRegion(2);
        //InsertRegion("South East");
        //UpdateRegion(6, "South East Asia");
        //DeleteRegion(6);       

        //GetAllCountry();
        //GetByIdCountry("AM");
        //InsertCountry("AM" , "Armenia" , 1);
        //UpdateCountry("AM", "Alabama");
        //DeleteCountry("AM");


    }

    //GET ALL REGION
    public static void GetAllRegion()
    {
        //Membuat Instance SQL Server Connection
        connection = new SqlConnection(connectionString);

        //membuat instance sql command
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Select * From region;";

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

    //GET BY ID : Region
    public static void GetByIdRegion(int id)
    {
        connection = new SqlConnection(connectionString);

        //membuat instance sql command
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Select * From region where id = @id;";

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
            
                Console.WriteLine("Id : " + reader[0]);
                Console.WriteLine("Name : " + reader[1]);
            
        } else
        {
            Console.WriteLine($"id = {id} is not found!");
        }
        reader.Close();
        connection.Close();
    }

    // INSERT : Region
    public static void InsertRegion(string name)
    {
        connection = new SqlConnection(connectionString);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Insert Into region (name) Values (@name);";
            command.Transaction = transaction;

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = System.Data.SqlDbType.VarChar;
            pName.Value = name;
            command.Parameters.Add(pName);

            command.ExecuteNonQuery();

            transaction.Commit();
            Console.WriteLine("Insert Success!");
            connection.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine("Something Wrong! : " + e.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }

    // UPDATE : Region
    public static void UpdateRegion(int id, string name)
    {
        connection = new SqlConnection(connectionString);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Update region Set name = @name Where id = @id;";
            command.Transaction = transaction;

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = System.Data.SqlDbType.VarChar;
            pName.Value = name;
            command.Parameters.Add(pName);

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.Int;
            pId.Value = id;
            command.Parameters.Add(pId);

            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Update Success!");
            }
            else
            {
                Console.WriteLine($"id = {id} is not found!");
            }

            transaction.Commit();
            connection.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine("Something Wrong! : " + e.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }

    // DELETE : Region
    public static void DeleteRegion(int id)
    {
        connection = new SqlConnection(connectionString);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Delete From region Where id = @id;";
            command.Transaction = transaction;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.Int;
            pId.Value = id;
            command.Parameters.Add(pId);

            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Delete Success!");
            }
            else
            {
                Console.WriteLine($"id = {id} is not found!");
            }

            transaction.Commit();
            connection.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine("Something Wrong! : " + e.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }

 //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//

    // GET ALL : Country
    public static void GetAllCountry()
    {
        // Membuat instance SQL Server Connection
        connection = new SqlConnection(connectionString);

        // Membuat instance SQL Command
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Select * From country;";

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Console.WriteLine("Id : " + reader[0]);
                Console.WriteLine("Name : " + reader[1]);
                Console.WriteLine("Region : " + reader[2]);
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Country is Empty!");
        }
        reader.Close();
        connection.Close();
    }

    // GET BY ID : Country
    public static void GetByIdCountry(string id)
    {
        // Membuat instance SQL Server Connection
        connection = new SqlConnection(connectionString);

        // Membuat instance SQL Command
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Select * From country Where id = @id;";

        // Membuat instance SQL Parameter
        SqlParameter pId = new SqlParameter();
        pId.ParameterName = "@id";
        pId.SqlDbType = System.Data.SqlDbType.VarChar;
        pId.Value = id;
        command.Parameters.Add(pId);

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            reader.Read();

            Console.WriteLine("Id : " + reader[0]);
            Console.WriteLine("Name : " + reader[1]);
            Console.WriteLine("Region : " + reader[2]);
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine($"id = {id} is not found!");
        }
        reader.Close();
        connection.Close();
    }

    // INSERT : Country
    public static void InsertCountry(string id, string name, int region)
    {
        connection = new SqlConnection(connectionString);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Insert Into country (id,name,region) Values (@id,@name,@region);";
            command.Transaction = transaction;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.VarChar;
            pId.Value = id;
            command.Parameters.Add(pId);

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = System.Data.SqlDbType.VarChar;
            pName.Value = name;
            command.Parameters.Add(pName);

            SqlParameter pRegion = new SqlParameter();
            pRegion.ParameterName = "@region";
            pRegion.SqlDbType = System.Data.SqlDbType.Int;
            pRegion.Value = region;
            command.Parameters.Add(pRegion);

            command.ExecuteNonQuery();

            transaction.Commit();
            Console.WriteLine("Insert Success!");
            connection.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine("Something Wrong! : " + e.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }

    // UPDATE : Country
    public static void UpdateCountry(string id, string name)
    {
        connection = new SqlConnection(connectionString);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Update country Set name = @name Where id = @id;";
            command.Transaction = transaction;

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = System.Data.SqlDbType.VarChar;
            pName.Value = name;
            command.Parameters.Add(pName);

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.VarChar;
            pId.Value = id;
            command.Parameters.Add(pId);

            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Update Success!");
            }
            else
            {
                Console.WriteLine($"id = {id} is not found!");
            }

            transaction.Commit();
            connection.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine("Something Wrong! : " + e.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }

    // DELETE : Country
    public static void DeleteCountry(string id)
    {
        connection = new SqlConnection(connectionString);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Delete From country Where id = @id;";
            command.Transaction = transaction;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.VarChar;
            pId.Value = id;
            command.Parameters.Add(pId);

            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Delete Success!");
            }
            else
            {
                Console.WriteLine($"id = {id} is not found!");
            }

            transaction.Commit();
            connection.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine("Something Wrong! : " + e.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}