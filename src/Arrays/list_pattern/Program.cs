/*
* Discard Pattern
*/
var scores = new[] { 10, 20, 30, 40, 500 };
if (scores is [10, _, _, _, _])
{
    Console.WriteLine("Matched");
}
else
{
    Console.WriteLine("Not Matched");
}

/*
* Range Pattern
*/
if (scores is [10, _, 30, ..])
{
    Console.WriteLine("Matched");
}
else
{
    Console.WriteLine("Not Matched");
}

if (scores is [> 9, .., < 100])
{
    Console.WriteLine("Matched");
}
else
{
    Console.WriteLine("Not Matched");
}

/*
* Var Pattern
*/
if (scores is [var x, _, var z, var w, var v])
{
    Console.WriteLine($"Matched {x} {z} {w} {v}");
}
else
{
    Console.WriteLine("Not Matched");
}
