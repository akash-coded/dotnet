using static System.Console;

var person1 = new Person("u001", "John Doe", 32);
WriteLine(person1);

person1.Age = 25;
WriteLine(person1.Age);

// Deconstructing the record properties
var (Id, Name, Age) = person1;
WriteLine(Id);

// Nondestructive mutation
var person2 = person1 with
{
    Id = "u002",
    Name = "Jane Smith"
};
WriteLine(person2);

// Value-based equality checking
WriteLine(person1 == person2);

// public record Person(string Id, string Name, int Age);

// Mutable record
public record Person
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}