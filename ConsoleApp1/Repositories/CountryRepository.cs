using Connection.Contexts;
using Connection.Models;
using Connection.Repositories.Interfaces;
using Connection.Views;
using System.Data;
using System.Data.SqlClient;

namespace Connection.Repositories;
public class CountryRepository : ICountryRepository
{
    public List<Country> GetAll()
    {
        List<Country> countries = new List<Country>();

        // Membuat instance SQL Server Connection
        var connection = MyContext.GetConnection();

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
                countries.Add(new Country
                {
                    Id = reader.GetString(0),
                    Name = reader.GetString(1),
                    Region = reader.GetInt32(2)
                });
            }
        }
        else
        {
            return null;
        }
        reader.Close();
        connection.Close();

        return countries;
    }

    public Country GetById(string id)
    {
        var connection = MyContext.GetConnection();

        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Select * From country where id = @Id";
        command.Parameters.AddWithValue("@Id", id);

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            reader.Read();
            Country country = new Country
            {
                Id = reader.GetString(0),
                Name = reader.GetString(1),
                Region = reader.GetInt32(2)
            };
            reader.Close();
            connection.Close();
            return country;
        }
        else
        {
            reader.Close();
            connection.Close();
            return null;
        }
    }

    public int Insert(Country country)
    {
        var result = 0;
        var connection = MyContext.GetConnection();
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
            command.Parameters.AddWithValue("@id", country.Id);

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = System.Data.SqlDbType.VarChar;
            command.Parameters.AddWithValue("@name", country.Name);

            SqlParameter pRegion = new SqlParameter();
            pRegion.ParameterName = "@region";
            pRegion.SqlDbType = System.Data.SqlDbType.Int;
            command.Parameters.AddWithValue("@region", country.Region);

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

    public int Update(Country country)
    {
        var connection = MyContext.GetConnection();

        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Update country Set name = @Name Where id = @Id;";
        command.Parameters.AddWithValue("@Name", country.Name);
        command.Parameters.AddWithValue("@Id", country.Id);

        connection.Open();
        int result = command.ExecuteNonQuery();
        connection.Close();

        return result;
    }

    public int Delete(string id)
    {
        var connection = MyContext.GetConnection();

        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Delete From country Where id = @Id;";
        command.Parameters.AddWithValue("Id", id);

        connection.Open();
        int result = command.ExecuteNonQuery();
        connection.Close();

        return result;
    }
}