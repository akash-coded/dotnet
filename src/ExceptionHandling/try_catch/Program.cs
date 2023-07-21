int amount = 100;
int noOfWithdrawals = 2;
bool flag = true;

int Method()
{
    int totalAmtToBeWithdrawn;
    try
    {
        totalAmtToBeWithdrawn = amount > 0 ? amount : throw new ArgumentException("Amount cannot be negative");
        int amtPerWithdrawal = totalAmtToBeWithdrawn / noOfWithdrawals;
        Console.WriteLine($"Amount per withdrawal: {amtPerWithdrawal}");
        return 1;
    }
    catch (DivideByZeroException ex) when (flag)
    {
        Console.WriteLine("Error: You don't have any remaining withdrawals today");
        Console.WriteLine($"Message: {ex.Message}");
        Console.WriteLine($"Source: {ex.Source}");
        Console.WriteLine($"Stack Trace: {ex.StackTrace}");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine("Error: Invalid amount");
        Console.WriteLine($"Message: {ex.Message}");
        Console.WriteLine($"Source: {ex.Source}");
        Console.WriteLine($"Stack Trace: {ex.StackTrace}");

        throw;
    }
    finally
    {
        Console.WriteLine("Finally block is always executed");
    }

    return 0;
}

void OuterMethod()
{
    try
    {
        int result = Method();
        Console.WriteLine($"Result: {result}");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: An unexpected error occurred in the invoked Method");
    }
}

OuterMethod();

class MyCustomException : Exception
{
    public MyCustomException() : base() { }

    public MyCustomException(string message) : base(message) { }

    public MyCustomException(string message, Exception innerException) : base(message, innerException) { }
}

