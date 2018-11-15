using System;
using System.Collections.Generic;
using System.Linq;

public enum Plant
{
    Violets = 'V',
    Radishes = 'R',
    Clover = 'C',
    Grass = 'G'
}

public class KindergartenGarden
{   
    private class Student
    {
        public string Name {get; private set;}
        public List<Plant> plants {get; private set;}
        
        public Student(string name)
        {
            Name = name;
            plants = new List<Plant>();
        }
    }

    private Dictionary<int, Student> studentsPlants = new Dictionary<int, Student>()
    {
        {0, new Student("Alice")},
        {2, new Student("Bob")},
        {4, new Student("Charlie")},
        {6, new Student("David")},
        {8, new Student("Eve")},
        {10, new Student("Fred")},
        {12, new Student("Ginny")},
        {14, new Student("Harriet")},
        {16, new Student("Ileana")},
        {18, new Student("Joseph")},
        {20, new Student("Kincaid")},
        {22, new Student("Larry")},
    };

    public KindergartenGarden(string diagram)
    {        
        string[] rows = diagram.Split("\n");
        char[] row1 = rows[0].ToCharArray();
        char[] row2 = rows[1].ToCharArray();
        for(int i = 0; i < row1.Length; i+=2)
        {
            Plant p1  = (Plant)row1[i];
            Plant p2  = (Plant)row1[i + 1];
            Plant p3  = (Plant)row2[i];
            Plant p4  = (Plant)row2[i + 1];
            if(studentsPlants.TryGetValue(i, out Student student))
            {
                student.plants.Add(p1);
                student.plants.Add(p2);
                student.plants.Add(p3);
                student.plants.Add(p4);
            }
        }
    }

    public IEnumerable<Plant> Plants(string student)
    {
        return studentsPlants.Values.First(s => s.Name == student).plants;
    }
}