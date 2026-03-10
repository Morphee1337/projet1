using System;
using System.Collections.Generic;

class Student
{
    private static int nextId = 1;
    private int id;
    private string name;
    private float average;
    private bool isScholarshipHolder;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public float Average
    {
        get { return average; }
        set { average = value; }
    }

    public bool IsScholarshipHolder
    {
        get { return isScholarshipHolder; }
        set { isScholarshipHolder = value; }
    }

    public Student()
    {
        id = nextId++;
        name = "";
        average = 0;
        isScholarshipHolder = false;
    }

    public Student(string name, float average)
    {
        id = nextId++;
        this.name = name;
        this.average = average;
        this.isScholarshipHolder = false;
    }

    public Student(string name, float average, bool isScholarshipHolder)
    {
        id = nextId++;
        this.name = name;
        this.average = average;
        this.isScholarshipHolder = isScholarshipHolder;
    }

    public void Display()
    {
        Console.WriteLine(name + " - moyenne : " + average + " - boursier : " + isScholarshipHolder);
    }
}

class Course
{
    private static int nextId = 1;
    private int id;
    private string name;
    private float credits;
    private bool isMandatory;
    private List<Student> students;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public float Credits
    {
        get { return credits; }
        set { credits = value; }
    }

    public bool IsMandatory
    {
        get { return isMandatory; }
        set { isMandatory = value; }
    }

    public List<Student> Students
    {
        get { return students; }
    }

    public Course(string name)
    {
        id = nextId++;
        this.name = name;
        credits = 0;
        isMandatory = false;
        students = new List<Student>();
    }

    public Course(string name, float credits, bool isMandatory)
    {
        id = nextId++;
        this.name = name;
        this.credits = credits;
        this.isMandatory = isMandatory;
        students = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        students.Remove(student);
    }

    public void Display()
    {
        Console.WriteLine(name + " - crédits : " + credits + " - obligatoire : " + isMandatory);
    }

    public void DisplayStudents()
    {
        foreach (Student s in students)
        {
            Console.WriteLine(s.Name);
        }
    }
}

class Program
{
    static void Main()
    {
        Student alice = new Student("Alice", 16, true);
        Student bernard = new Student("Bernard", 12, false);
        Student emma = new Student("Emma", 14);
        emma.IsScholarshipHolder = true;

        Student lucas = new Student();
        lucas.Name = "Lucas";
        lucas.Average = 10;
        lucas.IsScholarshipHolder = false;

        Student sarah = new Student("Sarah", 17, true);

        List<Student> students = new List<Student>()
        {
            alice, bernard, emma, lucas, sarah
        };

        Course math = new Course("Mathématiques", 5, true);
        Course info = new Course("Informatique", 6, true);
        Course english = new Course("Anglais");
        english.Credits = 3;
        english.IsMandatory = false;

        Course history = new Course("Histoire", 2, false);

        List<Course> courses = new List<Course>()
        {
            math, info, english, history
        };

        math.Students.Add(alice);
        math.Students.Add(bernard);
        math.Students.Add(emma);

        info.Students.Add(bernard);
        info.Students.Add(lucas);

        english.Students.Add(alice);
        english.Students.Add(sarah);

        history.Students.Add(lucas);

        Console.WriteLine("Liste des cours :");
        foreach (Course c in courses)
        {
            Console.WriteLine(c.Name + " - crédits : " + c.Credits +
                " - obligatoire : " + c.IsMandatory +
                " - étudiants : " + c.Students.Count);
        }

        Console.WriteLine();

        foreach (Course c in courses)
        {
            Console.WriteLine("Cours : " + c.Name);

            foreach (Student s in c.Students)
            {
                Console.WriteLine(" - " + s.Name + " (moyenne : " + s.Average + ")");
            }

            Console.WriteLine();
        }

        Console.WriteLine("Cours obligatoires :");
        foreach (Course c in courses)
        {
            if (c.IsMandatory)
            {
                Console.WriteLine(c.Name);
            }
        }

        Console.WriteLine();

        Console.WriteLine("Etudiants boursiers :");
        foreach (Student s in students)
        {
            if (s.IsScholarshipHolder)
            {
                Console.WriteLine(s.Name);
            }
        }

        Console.WriteLine();

        Console.WriteLine("Etudiants avec moyenne > 15 :");
        foreach (Student s in students)
        {
            if (s.Average > 15)
            {
                Console.WriteLine(s.Name);
            }
        }

        Console.WriteLine();

        math.Students.Remove(bernard);

        Console.WriteLine("Mathématiques après suppression :");
        foreach (Student s in math.Students)
        {
            Console.WriteLine(s.Name);
        }

        Console.ReadLine();
    }
}