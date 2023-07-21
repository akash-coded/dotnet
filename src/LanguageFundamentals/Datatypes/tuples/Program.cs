using static System.Console;

var person1 = ("u001", "John Doe");
WriteLine(person1);
WriteLine($"Id: {person1.Item1}, Name: {person1.Item2}");

var person2 = (Id: "u001", Name: "John Doe", Age: 32);
WriteLine(person2);
WriteLine($"Id: {person2.Id}, Name: {person2.Name}, Age: {person2.Age}");

// var comparisionResult = person1 == person2;
// WriteLine($"Comparision result: {comparisionResult}");

var (Id1, Name1, Age1) = person2; // deconstructing a tuple
WriteLine($"Id: {Id1}, Name: {Name1}, Age: {Age1}");
(string Id2, string Name2, int Age2) = person2; // deconstructing a tuple
WriteLine($"Id: {Id2}, Name: {Name2}, Age: {Age2}");

static (string name, int age) RemainingLifespan(string name, int age)
{
    return (name, 100 - age);
}
var (name, age) = RemainingLifespan(Name2, Age2);