namespace Assignment_Day2;

public interface IPersonService
{
    int CalculateAge();
    decimal CalculateSalary();
    List<string> GetAddresses();
}

public interface IStudentService : IPersonService
{
    decimal CalculateGPA();
}

public interface IInstructorService : IPersonService
{
    void SetDepartment(string departmentName);
}

public interface ICourseService
{
    void EnrollStudent(Student student);
    void ShowEnrolledStudents();
}

public interface IDepartmentService
{
    void SetBudget(decimal budget);
}


public abstract class Person : IPersonService
{
    private string name;
    private int birthYear;
    private decimal salary;
    private List<string> addresses;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int BirthYear
    {
        get { return birthYear; }
        set { birthYear = value; }
    }

    public decimal Salary
    {
        get { return salary; }
        set 
        { 
            if (value < 0) 
                throw new ArgumentException("Salary cannot be negative.");
            salary = value; 
        }
    }

    public List<string> Addresses
    {
        get { return addresses ??= new List<string>(); }
    }

    public Person(string name, int birthYear)
    {
        this.name = name;
        this.birthYear = birthYear;
        this.addresses = new List<string>();
    }

    public void AddAddress(string address)
    {
        Addresses.Add(address);
    }

    public int CalculateAge()
    {
        return DateTime.Now.Year - birthYear;
    }

    public abstract decimal CalculateSalary();

    public List<string> GetAddresses()
    {
        return Addresses;
    }
}


public class Instructor : Person, IInstructorService
{
    private string departmentName;
    private DateTime joinDate;
    private decimal bonusSalary;

    public Instructor(string name, int birthYear, DateTime joinDate) : base(name, birthYear)
    {
        this.joinDate = joinDate;
    }

    public override decimal CalculateSalary()
    {
        return Salary + bonusSalary;
    }

    public void SetDepartment(string departmentName)
    {
        this.departmentName = departmentName;
    }

    public int GetYearsOfExperience()
    {
        return DateTime.Now.Year - joinDate.Year;
    }
}

public class Student : Person, IStudentService
{
    private List<Course> courses;

    public Student(string name, int birthYear) : base(name, birthYear)
    {
        courses = new List<Course>();
    }

    public void EnrollInCourse(Course course)
    {
        courses.Add(course);
        course.EnrollStudent(this);
    }

    public decimal CalculateGPA()
    {
        decimal totalPoints = 0;
        int totalCourses = courses.Count;

        foreach (var course in courses)
        {
            totalPoints += course.CalculateGradePoint(); 
        }

        return totalCourses > 0 ? totalPoints / totalCourses : 0;
    }

    public override decimal CalculateSalary()
    {
        return 0;
    }
}


public class Course : ICourseService
{
    private List<Student> enrolledStudents;
    public string CourseName { get; set; }

    public Course(string courseName)
    {
        CourseName = courseName;
        enrolledStudents = new List<Student>();
    }

    public void EnrollStudent(Student student)
    {
        enrolledStudents.Add(student);
    }

    public void ShowEnrolledStudents()
    {
        Console.WriteLine($"Students enrolled in {CourseName}:");
        foreach (var student in enrolledStudents)
        {
            Console.WriteLine(student.Name);
        }
    }

    public decimal CalculateGradePoint()
    {
   
        return 4.0m; 
    }
}


public class Department : IDepartmentService
{
    private decimal budget;
    private string headInstructor;

    public string HeadInstructor
    {
        get { return headInstructor; }
        set { headInstructor = value; }
    }

    public void SetBudget(decimal budget)
    {
        this.budget = budget;
    }
}