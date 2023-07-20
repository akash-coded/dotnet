// class Student
// {
//     public string Name { get; set; }
//     public int Age { get; set; }

//     public int ClassNo { get; set; }

//     public string ClassTeacher { get; set; }

//     public Student(string name, int age, int classNo, string classTeacher)
//     {
//         Name = name;
//         Age = age;
//         ClassNo = classNo;
//         ClassTeacher = classTeacher;
//     }

//     public override string ToString()
//     {
//         return $"Name: {Name}, Age: {Age}, ClassNo: {ClassNo}, ClassTeacher: {ClassTeacher}";
//     }
// }

class Program
{
    static void Main()
    {
        var student1 = new
        {
            Name = "John",
            Age = 18,
            ClassNo = 12,
            ClassTeacher = "Mr. Smith"
        };
        Console.WriteLine(student1.ToString());
        Console.WriteLine(student1.GetType());
        Console.WriteLine(student1.GetHashCode());
        Console.WriteLine();

        var student2 = student1 with
        {
            Name = "Jane",
        };
        Console.WriteLine(student2);
        Console.WriteLine(student2.GetType());
        Console.WriteLine();

        Console.WriteLine(student1 == student2);
        Console.WriteLine(student1.Equals(student2));
        Console.WriteLine();

        var students = new[]
        {
            new { Name = "John", Age = 18, ClassNo = 12, ClassTeacher = "Mr. Smith" },
            new { Name = "Jane", Age = 19, ClassNo = 12, ClassTeacher = "Mr. Smith" },
            new { Name = "Jack", Age = 18, ClassNo = 12, ClassTeacher = "Mr. Smith" },
            new { Name = "Jill", Age = 19, ClassNo = 12, ClassTeacher = "Mr. Smith" }
        };

    }
}

