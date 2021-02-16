using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            String connectionString = ConfigurationManager.ConnectionStrings["ADO1"].ConnectionString;
            var connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                Console.WriteLine("Connected successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            Console.OutputEncoding = Encoding.UTF8;
            Random rand = new Random(DateTime.Now.Millisecond);

            /*
            string com = "INSERT Nums ([num]) VALUES( @val )";

            var command = new SqlCommand(com, connection);

            command.Parameters.Add("@val", SqlDbType.Int);
            
            command.Prepare();

            for (int i = 0; i < 2000; i++)
            {

                command.Parameters["@val"].Value = rand.Next(0, 1000);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Command failed");
                    Console.WriteLine(e.Message);
                }
            }
            */

            string com = "SELECT COUNT(num) FROM Nums WHERE num = @val";

            var command = new SqlCommand(com, connection);

            command.Parameters.Add("@val", SqlDbType.Int);

            command.Prepare();

            for (int i = 0; i <= 100; i++)
            {

                command.Parameters["@val"].Value = i;

                try
                {
                    var a = command.ExecuteScalar();
                    Console.WriteLine($"Amount of {i} = {a}");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Command failed");
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("Command completed successfully");


            Console.WriteLine("Done. Press a key");
            
            connection.Close();
            connection.Dispose();
            
            Console.ReadKey();
        }
        static void Main3(string[] args)
        {
            String connectionString = ConfigurationManager.ConnectionStrings["ADO1"].ConnectionString;
            var connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                
                Console.WriteLine("Connected successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            Console.OutputEncoding = Encoding.UTF8;

            //var command = new SqlCommand("CREATE TABLE Nums ( id INT PRIMARY KEY IDENTITY, num INT )", connection);
            //var command = new SqlCommand("CREATE TABLE Nums ( id INT PRIMARY KEY IDENTITY, num INT, [time] DATETIME DEFAULT CURRENT_TIMESTAMP )", connection);
            //var command = new SqlCommand("ALTER TABLE Nums ADD [time] DATETIME DEFAULT CURRENT_TIMESTAMP", connection);

            Random rand = new Random(DateTime.Now.Millisecond);

            /*string com = $"INSERT INTO Nums (num) VALUES ";
            com += $"({rand.Next()})";
            for (int i = 0; i < 9; i++)
            {
                com += $",({rand.Next()})";
            }*/

            /*
            var sb = new System.Text.StringBuilder();
            sb.Append($"INSERT INTO Nums (num) VALUES ");
            sb.Append($"({rand.Next(0,100)})");
            for (int i = 0; i < 9; i++)
            {
                sb.Append($",({rand.Next(0,100)})");
            }

            string com = sb.ToString();*/

            //String.Join("),(", num_array);

            /*
            string com = "SELECT COUNT(num) FROM Nums";

            var command = new SqlCommand(com, connection);
            
            try
            {
                Console.WriteLine(command.ExecuteScalar());
                Console.WriteLine("Command completed successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Command failed");
            }
            */

            //string com = "SELECT COUNT(num), AVG(num), MAX(time) FROM Nums";

            //string com = @"CREATE TABLE Users ( id INT PRIMARY KEY IDENTITY, name NVARCHAR(32) NOT NULL, login NVARCHAR(32) NOT NULL )";

            //string com = "INSERT Users ([name],[login]) VALUES ( @name, @login)";
            //var command = new SqlCommand(com, connection);
            //command.Parameters.Add("@name", SqlDbType.NVarChar, 32);
            //command.Parameters.Add("@login", SqlDbType.NVarChar, 32);

            //command.Prepare();

            //command.Parameters["@name"].Value = "Півнь'як К. І.";
            //command.Parameters["@login"].Value = "Piv-nik";


            string com = "SELECT TOP 1 [name] FROM Users";
            
            var command = new SqlCommand(com, connection);

            
            try
            {
                
                Console.WriteLine(command.ExecuteScalar());
                Console.WriteLine("Command completed successfully");
                
                /*
                var reader = command.ExecuteReader();
                reader.Read();
                var a = reader.GetInt32(0);
                var b = reader.GetInt32(1);
                var c = reader.GetDateTime(2);
                Console.WriteLine($"Amount: {a}, Avg: {b}, Last: {c}");
                */
                //command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Command failed");
            }

            while (false)
            {
                Console.WriteLine("To insert:");
                string str = Console.ReadLine();
                str = str.Replace(" ", "");
                if (str == "")
                    break;
                command.CommandText = $"INSERT INTO Nums (num) VALUES ( {str} )";
                try
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Value Inserted");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error");
                }
            }

            Console.WriteLine("Done. Press a key");
            Console.ReadKey();
            connection.Close();
            connection.Dispose();
        }

        static void Main2(string[] args)
        {
            String connectionString = ConfigurationManager.ConnectionStrings[ "ADO1" ].ConnectionString;
            var connection = new SqlConnection(connectionString);
            
            connection.Open();

            SqlDataReader reader;

            var command = new SqlCommand("SELECT * FROM Test", connection);

            reader = command.ExecuteReader();

            reader.Read();
            
            Console.WriteLine("{0} {1}", reader.GetInt32(0), reader.GetString(1));
            Console.ReadKey();
        }

        static void Main1(string[] args)
        {
            SqlConnection connection;
            
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\ADO Console\ADO Console\Database1.mdf;Integrated Security=True";

            connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                Console.WriteLine("Connected successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "CREATE TABLE Test ( id INT PRIMARY KEY, str NVARCHAR(32) )";
            
            //  cmd.ExecuteNonQuery - DDL; CREATE, INSERT, UPDATE, DELETE
            //  cmd.ExecuteScalar   - Return 1 value; MIN, MAX, SUM, AVG
            //  cmd.ExecuteReader   - Return table

            try
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Table created");
            }
            catch (Exception e)
            {
                Console.WriteLine("Creation skipped");
            }

            command.CommandText = "INSERT INTO Test VALUES (1, 'String 1')";

            try
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Values inserted");
            }
            catch (Exception e)
            {
                Console.WriteLine("Insertion skipped");
            }

            while (true)
            {
                string str = Console.ReadLine();
                if (str.Replace(" ", "") == "")
                    break;
                command.CommandText = $"INSERT INTO Test VALUES ( (SELECT MAX(id) FROM Test) + 1 , N'{str.Replace("'", "''")}')";
                try
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Value Inserted");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error");
                }
            }


            Console.WriteLine("End");
            Console.ReadKey();
            connection.Close();
            connection.Dispose();

        }
    }
}
