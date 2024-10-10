namespace Assignment_Day2;

public abstract class Person
{
    public string Name { get; set; }
    private int age;

    public int Age
    {
        get
        {
            return age;
        }
        private set
        {
            age = value;
        }
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public abstract void acting();
}

public class Student : Person
{
    public string Grade { get; set; }

    public Student(string name, int age, string grade) : base(name, age)
    {
        Grade = grade;
    }

    public override void acting()
    {
        Console.WriteLine("The student is studying.");
    }
}

public class Instructor : Person
{
    private double salary;

    public double Salary
    {
        get
        {
            return salary;
        }
        set
        {
            salary = value;
        }
    }

    public Instructor(string name, int age, double salary) : base(name,age)
    {
        Salary = salary;
    }

    public override void acting()
    {
        Console.WriteLine("The instructor is working.");
    }
}