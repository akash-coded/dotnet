interface IMyInterface
{
    void MethodToImplement();

    // default method implementation
    void MethodToImplement2() => Console.WriteLine("MethodToImplement2() called.");
}

class MyClass : IMyInterface
{
    public void MethodToImplement()
    {
        Console.WriteLine("MethodToImplement() called.");
    }
}

interface IWritable
{
    void Write(string msg);
}

interface ISavable
{
    void Write(string msg);
}

class TextFile : IWritable, ISavable
{
    public string FileName { get; set; }

    public TextFile(string filename)
    {
        FileName = filename;
    }

    void IWritable.Write(string msg)
    {
        Console.WriteLine($"Writing to file {FileName} using IWritable: {msg}");
    }

    void ISavable.Write(string msg)
    {
        Console.WriteLine($"Writing to file {FileName} using ISavable: {msg}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        MyClass myClass = new MyClass();
        myClass.MethodToImplement();

        var textFile = new TextFile("test.txt");
        ISavable savable = textFile;
        savable.Write("Hello World!");

        IWritable writable = textFile;
        writable.Write("Hello World!");
    }
}