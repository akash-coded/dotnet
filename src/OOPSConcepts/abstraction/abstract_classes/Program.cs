abstract class MyClass
{
    public abstract string AbstractProperty { get; set; }

    public abstract void Method();
}

class MyDerivedClass : MyClass
{
    public override string AbstractProperty { get; set; }

    public override void Method()
    {
        Console.WriteLine("Method implementation");
    }
}