namespace classes_and_objects;

class Person
{
    private string firstName;
    private byte? age;

    // parameterized constructor
    public Person(string firstName, string lastName, byte? age)
    {
        this.firstName = firstName;
        LastName = lastName;
        this.age = age;

        Count++;
    }

    // overloaded constructor
    public Person(string firstName, string? lastName): this(firstName, lastName, null)
    {
    }

    // overloaded constructor
    public Person(string firstName): this(firstName, null)
    {
    }

    // parameterless constructor
    public Person(): this("No name")
    {
        Console.WriteLine("Created a new Person object");
    }

    public static int Count { get; private set; }

    public string FirstName
    {
        get { return firstName; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("First name must not be empty or null");
            }

            firstName = value;
        }
    }

    public string LastName { get; set; } = "NA";

    public byte? Age
    {
        get
        {
            return age;
        }
        set
        {
            if (value < 0 || value > 150)
            {
                throw new ArgumentException("Age must be between 0 and 150");
            }

            age = value;
        }

    }

    public string Nationality { get; init; } = string.Empty;

    // computed property
    public string FullName
    {
        get
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }

    public string SayHi()
    {
        return $"Hi, i'm {this.FullName}";
    }

    public Person SetFirstName(string firstName)
    {
        this.FirstName = firstName;
        return this;
    }

    public Person SetLastName(string lastName)
    {
        this.LastName = lastName;
        return this;
    }

    public override string ToString()
    {
        dynamic userAge = (this.age < 0) ? "Did not set" : this.age;

        return $"Person[Name: {this.FullName}, Age: {userAge}, Nationality: {this.Nationality}]";
    }
}

class Sentence
{
    private string[] words;

    public Sentence(string s)
    {
        words = s.Split(' ');
    }

    public int Length
    {
        get
        {
            return words.Length;
        }
    }

    // indexer
    public string this[int index]
    {
        get
        {
            return words[index];
        }
    }
}

class Matrix
{
    private double[,] data;

    public Matrix(int row, int column)
    {
        data = new double[row, column];
    }

    public double this[int row, int column]
    {
        // expression-bodied syntax
        get => data[row, column];
        set => data[row, column] = value;
    }
}

static class LengthConverter
{
    static readonly double conversionFactor = 3.2;

    static LengthConverter()
    { 
        Console.WriteLine("Static constructor of LengthConverter invoked");
    }

    public static double FeetToMeters(double ft) => ft / conversionFactor;
    public static double MetersToFeet(double m) => m * conversionFactor;
}


class Program
{
    static void Main(string[] args)
    {
        Person p1 = new("Akash");

        string greeting1 = p1.SayHi();
        Console.WriteLine(greeting1);
        Console.WriteLine(p1);
        Console.WriteLine();

        Person p2 = new("Akash", "Das");
        Console.WriteLine(p2.SayHi());
        Console.WriteLine(p2);
        Console.WriteLine();

        string greeting2 = p1.SetFirstName("John")
            .SetLastName("Doe")
            .SayHi();
        Console.WriteLine(greeting2);
        Console.WriteLine(p1);
        Console.WriteLine();

        Person p3 = new()
        {
            Nationality = "Indian"
        };
        p3.FirstName = "Jane";
        p3.LastName = "Smith";
        p3.Age = 20;
        Console.WriteLine($"{p3.FirstName} {p3.LastName}");
        Console.WriteLine(p3);
        Console.WriteLine();

        Person p4 = new("Alex")
        {
            LastName = "Johanesburg",
            Age = 29,
            Nationality = "Australia"
        };
        Console.WriteLine(p4);
        Console.WriteLine();

        var sentence = new Sentence("My name is Akash");
        Console.WriteLine(sentence[3]);
        for (int i = 0; i < sentence.Length; i++)
        {
            Console.WriteLine(sentence[i]);
        }
        Console.WriteLine();

        // object initializer with indexer
        var matrix = new Matrix(3, 3)
        {
            [0, 0] = 101,
            [0, 1] = 102,
            [0, 2] = 103,
            [1, 0] = 104,
            [1, 1] = 105,
            [1, 2] = 106,
            [2, 0] = 107,
            [2, 1] = 108,
            [2, 2] = 109,
        };

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                Console.Write($"{matrix[row, col]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        // feet to meters
        var meters = LengthConverter.FeetToMeters(100);
        Console.WriteLine("100ft = " + meters + "m");

        // meters to feet
        var feet = LengthConverter.MetersToFeet(10);
        Console.WriteLine("10m = " + feet + "ft");
    }
}

