
using MySql.Data.MySqlClient;

namespace db_connect_ado_app
{
	public class User
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }

		public override string ToString()
		{
			return $"User: [Id: {Id}, Username: {Username}, Password: {Password}, Email: {Email}]";
		}
	}

	public class UserRepository
	{
		private MySqlConnection connection;

		public UserRepository(string connectionString)
		{
			connection = new MySqlConnection(connectionString);
		}

		public User GetUser(int id)
		{
			User user = null;

			string query = "SELECT * FROM Users WHERE id = @Id";

			using (MySqlCommand command = new MySqlCommand(query, connection))
			{
				command.Parameters.AddWithValue("@Id", id);

				connection.Open();

				using (MySqlDataReader reader = command.ExecuteReader())
				{
					if (reader.Read())
					{
						user = new User
						{
							Id = Convert.ToInt32(reader["Id"]),
							Username = reader["Username"].ToString(),
							Password = reader["Password"].ToString(),
							Email = reader["Email"].ToString()
						};
					}   
				}

                connection.Close();

                return user;
            }
		}

		public List<User> GetAllUsers()
		{
			var users = new List<User>();

			var query = "SELECT * FROM Users";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                connection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var user = new User
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            Email = reader["Email"].ToString()
                        };

						users.Add(user);
                    }

                }

                connection.Close();

                return users;
            }

		}

		public bool AddUser(User user)
		{
			var query = "INSERT INTO Users (Id, Username, Password, Email) VALUES (@Id, @Username, @Password, @Email)";

			var command = new MySqlCommand(query, connection);
			command.Parameters.AddWithValue("@Id", user.Id);
            command.Parameters.AddWithValue("@Username", user.Username);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@Email", user.Email);

			connection.Open();

			var rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowsAffected > 0;

        }
	}
}

