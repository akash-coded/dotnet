using MySql.Data.MySqlClient;

MySqlConnection conn;
string myConnectionString;

myConnectionString = "server=localhost; port=3307; uid=root; pwd=password; database=adodotnet_demo";

try
{
    conn = new MySqlConnection(myConnectionString);
    conn.Open();
    Console.WriteLine($"MySQL version : {conn.ServerVersion}\n");

    using var cmd = new MySqlCommand();
    cmd.Connection = conn;

    cmd.CommandText = "DROP TABLE IF EXISTS cars";
    cmd.ExecuteNonQuery();

    cmd.CommandText = @"CREATE TABLE cars(id INTEGER PRIMARY KEY AUTO_INCREMENT,
        name TEXT, price INT)";
    cmd.ExecuteNonQuery();

    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Audi',52642)";
    cmd.ExecuteNonQuery();

    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Mercedes',57127)";
    cmd.ExecuteNonQuery();

    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Skoda',9000)";
    cmd.ExecuteNonQuery();

    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Volvo',29000)";
    cmd.ExecuteNonQuery();

    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Bentley',350000)";
    cmd.ExecuteNonQuery();

    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Citroen',21000)";
    cmd.ExecuteNonQuery();

    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Hummer',41400)";
    cmd.ExecuteNonQuery();

    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Volkswagen',21600)";
    cmd.ExecuteNonQuery();

    Console.WriteLine("Table cars created");
}
catch (MySqlException ex)
{
    Console.WriteLine(ex.Message);
}