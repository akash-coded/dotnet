using static System.Console;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public override string ToString() => Name;
}

public class Program
{
    static Person CreatePerson(string name, int age)
    {
        if (age < 0)
        {
            return null;
        }
        return new Person { Name = name, Age = age };
    }

    public static void Main()
    {
        var person = CreatePerson("John", 20);

        WriteLine(person?.Name?.ToUpper());

        // try
        // {
        //     WriteLine(person.Name);
        // }
        // catch (Exception ex)
        // {
        //     WriteLine($"Exception: {ex.Message}");
        // }
        // finally
        // {
        //     WriteLine("Finally block");
        // }

        string s1 = "My string";
        string s2 = s1 ?? "default";

        WriteLine(s2);
    }
}