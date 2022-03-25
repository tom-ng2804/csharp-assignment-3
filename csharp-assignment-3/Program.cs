///////////////////////////////////////////////////////////////////////////////////////////////////
// Test your knowledge
///////////////////////////////////////////////////////////////////////////////////////////////////
/*
1. What are the six combinations of access modifier keywords and what do they do?
- private: The caller can only be within the class itself.
- private internal: The caller can be within the class itself or in any derived class within the same assembly.
- protected: The caller can be within the class itself or in any derived class in any assembly.
- protected internal: The caller can be anywhere within the same assembly, but if the caller is outside of the assembly, then it must be within a derived class.
- internal: The caller can be anywhere within the same assembly.
- public: The caller can be anything in any assembly.

2. What is the difference between the static, const, and readonly keywords when applied to a type member?
- const means that member will be constant and can't be change throughout the entire program. It is also implicitly static which means the definition must be define at compile time.
- readonly is the same as const but it can be define at runtime through the constructor, once the value is define, it can't be change.
- static means that the member belong to the class rather than the instance, sp there can only be 1 copy of it throughout the entire program.

3. What does a constructor do?
To initialize the class when a new instance is created.

4. Why is the partial keyword useful?
It allows you to seperate the a class or method into seperate files for organizatin purposes. It is useful when you have a really large class/method.

5. What is a tuple?
A data structure that can store 2 values.

6. What does the C# record keyword do?
It will auto implement a value-based equality comparator to the class or struct.

7. What does overloading and overriding mean?
Overloading is the ability to have multiple methods with the same name but different parameters and return type. It is a compile time polymorphism. Whereas, overriding is the ability redefine the implementation of the method through a derived class, but the method must have the same paramaters, and return type. The return type can be a subtype of the base return type. It is a runtime polymorphism.

8. What is the difference between a field and a property?
A field is just a variable within a class. Whereas a property is syntax sugar for getter and setter methods.

9. How do you make a method parameter optional?
Method overloading or assign the paramater a value.

10. What is an interface and how is it different from abstract class?
An interface is just a contract for a class to implement, the interface can't be instantiated because it is not an actual object.
On the other hand, an abstract class is like an 'unfinished' base class that jsut happen to contain some 'unfinished' methods that the derived class must implement in order to instantiate it.

When a class inherit an interface, it represent a "is-able" relationship. While inheriting a class or an abstract class represent a "is a" relation.

11. What accessibility level are members of an interface?
public

12. True/False. Polymorphism allows derived classes to provide different implementations of the same method.
False

13. True/False. The override keyword is used to indicate that a method in a derived class is providing its own implementation of a method.
True

14. True/False. The new keyword is used to indicate that a method in a derived class is providing its own implementation of a method.
True

15. True/False. Abstract methods can be used in a normal (non-abstract) class.
False

16. True/False. Normal (non-abstract) methods can be used in an abstract class.
True

17. True/False. Derived classes can override methods that were virtual in the base class.
True

18. True/False. Derived classes can override methods that were abstract in the base class.
True

19. True/False. In a derived class, you can override a method that was neither virtual non abstract in the base class.
False, but you can use the 'new' keyword to hide the base class method.

20. True/False. A class that implements an interface does not have to provide an implementation for all of the members of the interface.
False

21. True/False. A class that implements an interface is allowed to have other members that aren’t defined in the interface.
True

22. True/False. A class can have more than one base class.
False

23. True/False. A class can implement more than one interface.
True
 */

///////////////////////////////////////////////////////////////////////////////////////////////////
// Working with methods
///////////////////////////////////////////////////////////////////////////////////////////////////
// 1
using System.Collections.Immutable;
using System.Diagnostics;

public class Program
{
    public static void Main(string[] args)
    {
        int[] numbers = GenerateNumbers();
        Reverse(numbers);
        PrintNumbers(numbers);

        for (int i = 1; i <= 10; ++i)
        {
            Console.Write($"{GetFibonacci(i)} ");
        }
        Console.WriteLine();

        Color color = new(1, 1, 1);
        Ball ball = new(5, color);

        int throwBallCount = 10;
        for (int i = 0; i < throwBallCount; ++i)
        {
            ball.Throw();
        }
        Debug.Assert(ball.ThrownCount == (nuint)throwBallCount);

        ball.Pop();
        Debug.Assert(ball.Size == 0);
    }

    private static int GetFibonacci(int index)
    {
        return GetFibonacci(1, 1, index);
    }

    private static int GetFibonacci(int a, int b, int index)
    {
        if (index == 1)
        {
            return a;
        }
        return GetFibonacci(b, a + b, --index);
    }

    private static int[] GenerateNumbers(int n)
    {
        return Enumerable.Range(1, n).ToArray();
    }

    private static int[] GenerateNumbers()
    {
        return GenerateNumbers(10);
    }

    private static void Reverse(int[] numbers)
    {
        for (int i = 0; i < numbers.Length / 2; ++i)
        {
            int temp = numbers[i];
            numbers[i] = numbers[numbers.Length - i - 1];
            numbers[numbers.Length - i - 1] = temp;
        }
    }

    private static void PrintNumbers(int[] numbers)
    {
        foreach (int number in numbers)
        {
            Console.Write($"{number} ");
        }
        Console.WriteLine();
    }
}

///////////////////////////////////////////////////////////////////////////////////////////////////
// Designing and Building Classes using object-oriented principles
///////////////////////////////////////////////////////////////////////////////////////////////////
// 1, 2, 3, 4, 5, 6
interface IPersonService
{
    int Age { get; }

    decimal Salary { get; }

    IReadOnlyList<string> Addresses { get; }
}

abstract class Person : IPersonService
{
    private DateTime DateOfBirth { get; }

    public int Age => (int)DateTime.Now.Subtract(DateOfBirth).TotalDays / 365;

    public virtual decimal Salary { get; }

    public IReadOnlyList<string> Addresses { get; }

    protected Person(string dateOfBirth, decimal baseSalary, IReadOnlyList<string> addresses)
    {
        if (baseSalary < 0) throw new ArgumentException("Salary can't be negative", nameof(baseSalary));
        DateOfBirth = DateTime.Parse(dateOfBirth);
        Salary = baseSalary;
        Addresses = addresses;
    }
}

interface IInstructor : IPersonService
{
    Department Department { get; }
}

class Instructor : Person, IInstructor
{
    private DateTime JoinDate { get; }

    private decimal SalaryBonus { get; }

    private int TotalWorkingYear => (int)DateTime.Now.Subtract(JoinDate).TotalDays / 365;

    public override decimal Salary => base.Salary * TotalWorkingYear * SalaryBonus;

    public Department Department { get; }

    public Instructor(string dateOfBirth, string joinDate, decimal baseSalary, decimal salaryBonus, IReadOnlyList<string> addresses, Department department)
        : base(dateOfBirth, baseSalary, addresses)
    {
        JoinDate = DateTime.Parse(joinDate);
        SalaryBonus = salaryBonus;
        Department = department;
    }
}

interface IStudentService : IPersonService
{
    IReadOnlyList<Course> Courses { get; }

    double GPA { get; }
}

class Student : Person, IStudentService
{
    public IReadOnlyList<Course> Courses { get; }

    public double GPA => Courses.Select(c => c.StudentToGpa[this]).Average();

    public Student(string dateOfBirth, decimal baseSalary, IReadOnlyList<string> addresses, IReadOnlyList<Course> courses)
    : base(dateOfBirth, baseSalary, addresses)
    {
        Courses = courses;
    }
}

interface IDepartmentService
{
    public Instructor Head { get; }

    public IList<Course> Courses { get; }

    public decimal Budget { get; }

    public DateTime StartDate { get; }

    public DateTime EndDate { get; }

    bool AddCourse(Course course);

    bool RemoveCourse(Course course);
}

class Department : IDepartmentService
{
    private HashSet<Course> _courses = new();

    public Instructor Head { get; }

    public IList<Course> Courses => _courses.ToList();

    public decimal Budget { get; }

    public DateTime StartDate { get; }

    public DateTime EndDate { get; }

    public Department(Instructor head, decimal budget, string startDate, string endDate)
    {
        Head = head;
        Budget = budget;
        StartDate = DateTime.Parse(startDate);
        EndDate = DateTime.Parse(endDate);
    }

    public bool AddCourse(Course course)
    {
        return _courses.Add(course);
    }

    public bool RemoveCourse(Course course)
    {
        return _courses.Remove(course);
    }
}

interface ICourseService
{
    IList<Student> Students { get; }

    void AddSudent(Student student, double gpa);

    void RemoveSudent(Student student);
}

class Course : ICourseService
{
    public ImmutableDictionary<Student, double> StudentToGpa { get; private set; } = ImmutableDictionary.Create<Student, double>();

    IList<Student> ICourseService.Students => StudentToGpa.Keys.ToList();

    public void AddSudent(Student student, double gpa)
    {
        StudentToGpa = StudentToGpa.Add(student, gpa);
    }

    public void RemoveSudent(Student student)
    {
        StudentToGpa = StudentToGpa.Remove(student);
    }
}

enum Grade
{
    A, B, C, D, E, F
}

// 7
class Color
{
    public byte Red { get; set; }
    public byte Green { get; set; }
    public byte Blue { get; set; }
    public byte Alpha { get; set; }
    public double GrayScale => (Red + Green + Blue) / 3;

    public Color(byte red, byte green, byte blue, byte alpha)
    {
        Red = red;
        Green = green;
        Blue = blue;
        Alpha = alpha;
    }

    public Color(byte red, byte green, byte blue)
        : this(red, green, blue, byte.MaxValue)
    {
    }
}

class Ball
{
    public Color Color { get; }

    public nuint Size { get; private set; }

    public nuint ThrownCount { get; private set; }

    public Ball(nuint size, Color color)
    {
        Size = size;
        Color = color;
    }

    public void Pop()
    {
        Size = 0;
    }

    public void Throw()
    {
        if (Size == 0) throw new InvalidOperationException("The ball is popped!");
        ++ThrownCount;
    }
}
