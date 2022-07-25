using MySql.Data.MySqlClient;
using System.Data;

MySqlConnection conn;
string myConnectionString;

myConnectionString = "server=localhost; port=3307; uid=root; pwd=password; database=jdbc_demo";

try
{
    conn = new MySqlConnection(myConnectionString);
    conn.Open();
    Console.WriteLine($"MySQL version : {conn.ServerVersion}");

    MySqlCommand cmd = new MySqlCommand();
    cmd.CommandText = "title";
    cmd.Connection = conn;
    cmd.CommandType = CommandType.TableDirect;
    MySqlDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine(reader[0] + "\t" + reader[1] + "\t" + reader[2]);
    }
    Console.WriteLine();
    reader.Close();

    string readQueryString = "SELECT * FROM title WHERE worker_title='EXECUTIVE'";
    MySqlCommand cmd2 = new MySqlCommand(readQueryString, conn);
    MySqlDataReader reader2 = cmd2.ExecuteReader();
    while (reader2.Read())
    {
        Console.WriteLine(reader2[0] + "\t" + reader2[1] + "\t" + reader2[2]);
    }
}
catch (MySqlException ex)
{
    Console.WriteLine(ex.Message);
}