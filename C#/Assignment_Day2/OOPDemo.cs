namespace Assignment_Day2;

public class OOPDemo{ }

public abstract class Animal
{
    public Animal(string name)
    {
        Name = name;
    }
    private string name;
    public string Name
    {
        get
        {
            return name;
        } set
        {
            name = value;
        }
    }
    
    public int Age { get; set; }

    public abstract void Eating();
}

public class Dog : Animal
{
    public String Color { get; set; }
    public Dog(string name, int age) : base(name)
    {
        Name = name;
        Age = age;
    }

    public Dog(string name, int age, string color):base(name)
    {
        Name = name;
        Age = age;
        Color = color;
    }

    public override void Eating()
    {
        Console.WriteLine("Dog is eating");
    }
}