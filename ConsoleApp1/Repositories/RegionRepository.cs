using Connection.Contexts;
using Connection.Models;
using Connection.Repositories.Interfaces;
using System.Data.SqlClient;

namespace Connection.Repositories;
public class RegionRepository : IRegionRepository
{
    public List<Region> GetAll()
    {
        List<Region> regions = new List<Region>();

        // Membuat instance SQL Server Connection
        var connection = MyContext.GetConnection();

        // Membuat instance SQL Command
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Select * From region;";

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                // alt 1
                /*Region region = new Region();
                region.Id = reader.GetInt32(0);
                region.Name = reader.GetString(1);*/

                // alt 2
                /*Region region = new Region {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                };
                regions.Add(region);*/

                // alt 3
                regions.Add(new Region
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });
            }
        }
        else
        {
            return null;
        }
        reader.Close();
        connection.Close();

        return regions;
    }

    public Region GetById(int id)
    {
        var connection = MyContext.GetConnection();

        SqlCommand command = new SqlCommand(); 
        command.Connection = connection;
        command.CommandText = "Select * From region where id = @Id";
        command.Parameters.AddWithValue("@Id", id);

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            reader.Read();
            Region region = new Region
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1)
            };
            reader.Close();
            connection.Close();
            return region;
        }
        else
        {
            reader.Close() ;
            connection.Close();
            return null;
        }
    }

    public int Insert(Region region)
    {
        var result = 0;
        var connection = MyContext.GetConnection();
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
            pName.Value = region.Name;
            command.Parameters.Add(pName);

            result = command.ExecuteNonQuery();

            transaction.Commit();
            connection.Close();

        }
        catch
        {
            try
            {
                transaction.Rollback();
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        return result;
    }

    public int Update(Region region)
    {
        var connection = MyContext.GetConnection();

        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Update region Set name = @Name Where id = @Id;";
        command.Parameters.AddWithValue("@Name", region.Name);
        command.Parameters.AddWithValue("@Id", region.Id);

        connection.Open();
        int result = command.ExecuteNonQuery();
        connection.Close();

        return result;
    }

    public int Delete(int id)
    {
        var connection = MyContext.GetConnection();

        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Delete From region Where id = @Id;";
        command.Parameters.AddWithValue("Id", id);

        connection.Open();
        int result = command.ExecuteNonQuery();
        connection.Close();

        return result;
    }
}