namespace Nullables
{
    class NullableDemo
    {
        static void Main(string[] args)
        {
            Nullable<int> i = null;
            if (i.HasValue)
                Console.WriteLine(i.Value); // or Console.WriteLine(i)
            else
                Console.WriteLine("null");

            Nullable<int> j = null;
            Console.WriteLine(j.GetValueOrDefault());

            int? p = null;
            int q = p ?? 3;
            Console.WriteLine(q);

            if (p < q)
                Console.WriteLine("p < q");
            else if (p > q)
                Console.WriteLine("p > q");
            else if (p == q)
                Console.WriteLine("p == q");
            else
                Console.WriteLine("Could not compare");

            if (Nullable.Compare<int>(p, q) < 0)
                Console.WriteLine("p < q");
            else if (Nullable.Compare<int>(p, q) > 0)
                Console.WriteLine("p > q");
            else
                Console.WriteLine("p == q");
        }
    }
}
