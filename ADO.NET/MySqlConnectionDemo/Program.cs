using MySql.Data.MySqlClient;

MySqlConnection conn;
string myConnectionString;

myConnectionString = "server=localhost; port=3307; uid=root; pwd=password; database=jdbc_demo";

try
{
    conn = new MySqlConnection(myConnectionString);
    conn.Open();
    Console.WriteLine($"MySQL version : {conn.ServerVersion}");
}
catch (MySqlException ex)
{
    Console.WriteLine(ex.Message);
}