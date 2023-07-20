class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public byte Age { get; set; }

    public string FullName => $"{FirstName} {LastName}";

    public Person()
    {
    }

    public Person(string firstName, string lastName, byte age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public string Introduce() => $"Base: Hi, I am {FullName}";

    public virtual string Introduce(string greeting) => $"Base: Hi, I am {FirstName} {LastName}. {greeting}";

    public override string ToString() => $"Base: {FullName} is {Age} years old";

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        var other = (Person)obj;

        return FirstName == other.FirstName && Age == other.Age;
    }
}

sealed class Employee : Person
{
    public string EmployeeCode { get; set; }
    public string Designation { get; set; }
    public decimal Salary { get; set; }

    public Employee()
    {
    }

    public Employee(string firstName, string lastName, byte age, string employeeCode, string designation, decimal salary)
        : base(firstName, lastName, age)
    {
        EmployeeCode = employeeCode;
        Designation = designation;
        Salary = salary;
    }

    public new string Introduce() => $"Derived: Hi, I am {FullName} and I am working as {Designation} with {Salary} salary";

    public sealed override string Introduce(string greeting) => $"Derived: Hi, I am {FullName} and I am working as {Designation} with {Salary} salary. {greeting}. Base method call: {base.Introduce(greeting)}";

    public override string ToString() => $"Derived: {FullName} is {Age} years old and working as {Designation} with {Salary} salary";
}

class Program
{
    static void Main(string[] args)
    {
        var employee = new Employee
        {
            FirstName = "John",
            LastName = "Doe",
            Age = 30,
            EmployeeCode = "JD001",
            Designation = "Developer",
            Salary = 10000
        };

        Console.WriteLine(employee.Introduce());
        Console.WriteLine(employee.Introduce("Have a nice day!"));
        Console.WriteLine();

        Person person = employee;
        Console.WriteLine(person.Introduce());
        Console.WriteLine(person.Introduce("Bye bye!"));
        Console.WriteLine();

        Employee employee1 = (Employee)person;
        Console.WriteLine("Downcasting: " + employee1.Introduce());

        Person person2 = new Person
        {
            FirstName = "Jane",
            LastName = "Doe",
            Age = 25
        };
        Employee employee2 = person2 as Employee;
        if (employee2 == null)
        {
            Console.WriteLine("Downcasting: person2 cannot be casted to Employee");
        }
        else
        {
            Console.WriteLine("Downcasting: " + employee2.Introduce());
        }
        Console.WriteLine();

        Console.WriteLine("Is employee equivalent to employee1? " + employee.Equals(employee1));
    }
}