namespace GettersSetters
{
    class Student
    {
        private string _name;
        private int _age;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public override string ToString()
        {
            return base.ToString() + $" [_name: {_name}, _age: {_age}]";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            student.Name = "John";
            student.Age = 22;

            Console.WriteLine("Name: {0} \t Age: {1}", student.Name, student.Age);
            Console.WriteLine(student);
        }
    }
}
