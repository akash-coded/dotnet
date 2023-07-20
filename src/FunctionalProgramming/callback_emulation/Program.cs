delegate bool Callback(int value);

class Program
{
    static bool IsEven(int x) => x % 2 == 0;

    static bool IsOdd(int x) => x % 2 != 0;

    static bool IsMultipleOfThree(int x) => x % 3 == 0;

    static void PrintNumbers(int[] numbers, Callback callback)
    {
        foreach (var number in numbers)
        {
            if (callback.Invoke(number))
            {
                Console.Write(number + ", ");
            }
        }
        Console.WriteLine("\n");
    }

    static void Main(string[] args)
    {
        int[] numbers = { 1, 2, 3, 4, 5 };

        Callback callback = IsEven;
        callback += IsOdd;
        callback += IsMultipleOfThree;
        PrintNumbers(numbers, callback);

        callback -= IsMultipleOfThree;
        PrintNumbers(numbers, callback);
    }
}
