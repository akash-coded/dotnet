using System;

class MyClass
{
    public unsafe void Method()
    {
        int x = 10;
        int* ptr = &x;
        Console.WriteLine($"Value of x is {x}");
        Console.WriteLine($"Address of x is {(int)ptr}");
        Console.WriteLine($"Value of x is {*ptr}");
        Console.WriteLine($"Address of x is {(int)&x}");
    }
}

public class Program
{
    public static void Main()
    {
        var obj = new MyClass();
        obj.Method();
    }
}