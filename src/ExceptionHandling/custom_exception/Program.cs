using static System.Console;

public class InsufficientFundsException : ArgumentOutOfRangeException
{
    public decimal Deficit { get; set; }

    public InsufficientFundsException() : base() { }

    public InsufficientFundsException(string message) : base(message) { }

    public InsufficientFundsException(string message, Exception innerException) : base(message, innerException) { }

    public InsufficientFundsException(decimal deficit)
    {
        Deficit = deficit;
    }

    public override string Message => $"{base.Message} Could not withdraw due to a deficit of {Deficit:C}";
}

public class Account
{
    private decimal balance;

    public decimal Balance => balance;

    public Account(decimal initialBalance = 0)
    {
        if (initialBalance < 0)
        {
            throw new ArgumentOutOfRangeException("Initial balance must be zero or positive");
        }

        balance = initialBalance;
    }

    public Account Withdraw(decimal amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException("Amount must be zero or positive");
        }

        if (amount > balance)
        {
            throw new InsufficientFundsException(amount - balance);
        }

        balance -= amount;
        return this;
    }

    public Account Deposit(decimal amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        balance += amount;
        return this;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var account = new Account(1000);
        try
        {
            WriteLine($"Balance after withdrawal: {account.Withdraw(100).Balance:C}");

            WriteLine($"Balance after deposit: {account.Deposit(1).Balance:C}");

            WriteLine($"Balance after withdrawal: {account.Withdraw(2000).Balance:C}");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            WriteLine(ex.Message);
        }

        ReadLine();
    }
}