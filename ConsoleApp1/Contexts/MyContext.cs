using System.Data.SqlClient;

namespace Connection.Contexts;

    public class MyContext
    {
        private static SqlConnection? connection;

        private static string connectionString = "Data Source=DESKTOP-K0PBB23; Initial Catalog = db_hr_sibkm; Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public static SqlConnection GetConnection()
        {
            try{
                connection = new SqlConnection(connectionString);

            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            return connection;
        }
    }
