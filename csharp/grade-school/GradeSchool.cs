using System;
using System.Linq;
using System.Collections.Generic;

public class GradeSchool
{
    Dictionary<int, List<string>> school = new Dictionary<int, List<string>>();

    public void Add(string student, int grade)
    {
        if(!school.ContainsKey(grade))
        {
            school.Add(grade, new List<string>());
        }
        school[grade].Add(student);
    }

    public IEnumerable<string> Roster()
    {
        return school
        .OrderBy(gradeToClassroom => gradeToClassroom.Key)
        .SelectMany( (gradeToClassroom)=> gradeToClassroom.Value.OrderBy(student => student));
    }

    public IEnumerable<string> Grade(int grade)
    {
        return school.ContainsKey(grade) ?  school[grade].OrderBy( student => student) :  Enumerable.Empty<string>();
    }
}