namespace Delegate
{
    public delegate void MyDelegate(string msg); //declaring a delegate
    public delegate T add<T>(T param1, T param2); // generic delegate

    class Program
    {
        static void Main(string[] args)
        {
            MyDelegate del = ClassA.MethodA;
            del("Hello World");

            del = ClassB.MethodB;
            del("Hello World");

            del = (string msg) => Console.WriteLine("Called lambda expression: " + msg);
            del("Hello World");
            Console.WriteLine("");

            /// <summary>
            /// multicast delegate
            /// </summary>
            MyDelegate del1 = ClassA.MethodA;
            MyDelegate del2 = ClassB.MethodB;

            del = del1 + del2; // combines del1 + del2
            del("Hello World");
            Console.WriteLine("");

            MyDelegate del3 = (string msg) => Console.WriteLine("Called lambda expression: " + msg);
            del += del3; // combines del1 + del2 + del3
            del("Hello World");
            Console.WriteLine("");

            del = del - del2; // removes del2
            del("Hello World");
            Console.WriteLine("");

            del -= del1; // removes del1
            del("Hello World");
            Console.WriteLine("");

            /// <summary>
            /// using generic delegate
            /// </summary>
            add<int> sum = Sum;
            Console.WriteLine(sum(10, 20));
            Console.WriteLine("");

            add<string> con = Concat;
            Console.WriteLine(con("Hello ", "World!!"));
            Console.WriteLine("");

            Func<int, int, int> funcDel = Sum;
            Console.WriteLine("Using built-in delegate Func: " + funcDel(30, 40));
            Console.WriteLine("");
        }

        public static int Sum(int val1, int val2)
        {
            return val1 + val2;
        }

        public static string Concat(string str1, string str2)
        {
            return str1 + str2;
        }
    }

    class ClassA
    {
        public static void MethodA(string message)
        {
            Console.WriteLine("Called ClassA.MethodA() with parameter: " + message);
        }
    }

    class ClassB
    {
        public static void MethodB(string message)
        {
            Console.WriteLine("Called ClassB.MethodB() with parameter: " + message);
        }
    }
}