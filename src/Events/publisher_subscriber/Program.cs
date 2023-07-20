class OrderEventArgs : EventArgs
{
    public string Email { get; set; }
    public string Phone { get; set; }
}

class Order
{
    public event EventHandler<OrderEventArgs> OnCreated;

    public void Create(string email, string phone)
    {
        Console.WriteLine("Order created!");

        if (OnCreated != null)
        {
            OnCreated(this, new OrderEventArgs { Email = email, Phone = phone }); // raising the event
        }
    }
}

class Email
{
    public static void Send(object sender, OrderEventArgs e)
    {
        Console.WriteLine($"Email sent to {e.Email}!");
    }
}

class SMS
{
    public static void Send(object sender, OrderEventArgs e)
    {
        Console.WriteLine($"SMS sent to {e.Phone}!");
    }
}

public class Program
{
    public static void Main()
    {
        var order = new Order();
        order.OnCreated += Email.Send;
        order.OnCreated += SMS.Send;
        order.Create("akash@xyz.com", "+911234567890");
    }
}