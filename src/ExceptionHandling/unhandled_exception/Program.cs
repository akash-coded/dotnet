using static System.Console;

int Divide(int a, int b)
{
    return a / b;
}

AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(HandleException);

var result = Divide(10, 0);

WriteLine(result);

WriteLine("End of the program...Bye!");

static void HandleException(object sender, UnhandledExceptionEventArgs e)
{
    WriteLine($"Sorry, something went wrong. \n {e.ExceptionObject}");
}

