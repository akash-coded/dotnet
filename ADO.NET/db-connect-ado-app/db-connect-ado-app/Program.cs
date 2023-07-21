using Microsoft.Extensions.Configuration;

namespace db_connect_ado_app;

class Program
{
    static void Main(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
                                           .SetBasePath(Directory.GetCurrentDirectory())
                                           .AddJsonFile("appsettings.json", false, true)
                                           .Build();

        string? connectionString = configuration.GetConnectionString("DefaultConnection");

        UserRepository userRepository = new UserRepository(connectionString);

        var users = new User[]
        {
            new User
            {
                Id = 2,
                Username = "u002",
                Password = "DEF456",
                Email = "def@xyz.com"
            },
            new User
            {
                Id = 3,
                Username = "u003",
                Password = "GHI789",
                Email = "ghi@xyz.com"
            },

        };

        //foreach (var user in users)
        //{
        //    bool userAdded = userRepository.AddUser(user);
        //    Console.WriteLine("User adding status: " + userAdded);
        //}
        Console.WriteLine();

        var fetchedUsers = userRepository.GetAllUsers();
        foreach (var user in fetchedUsers)
        {
            Console.WriteLine(user);
        }
        Console.WriteLine();

        Console.WriteLine(userRepository.GetUser(2));
        Console.WriteLine();
    }
}

