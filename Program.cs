namespace Projet1;

public class Student
{
    private static int nextId = 1;
    public int Id { get; private set; }
    public string Name { get; set; }
    public double Average { get; set; }
    public bool IsScholarshipHolder { get; set; }

    public Student()
    {
        Id = nextId++;
        Name = "Inconnu";
    }

    public Student(string name, double average, bool isScholarshipHolder)
    {
        Id = nextId++;
        Name = name;
        Average = average;
        IsScholarshipHolder = isScholarshipHolder;
    }

    public Student(string name, double average)
    {
        Id = nextId++;
        Name = name;
        Average = average;
    }
}