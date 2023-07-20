delegate void Greeting(string message);

class Program
{
    static void sayHi(string name)
    {
        Console.WriteLine($"Hi {name}!");
    }

    static void Main(string[] args)
    {
        Greeting greeting1 = new Greeting(sayHi);

        Greeting greeting2 = sayHi;

        Greeting greeting3 = delegate (string message)
        {
            Console.WriteLine(message);
        };

        greeting1("Hello World - 1!");
        greeting2("Hello World - 2!");
        greeting3("Hello World - anonymous!");
    }
}