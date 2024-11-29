class Functions
{
    public static void AddStudent(Dictionary<string, List<Dictionary<string, double>>> students, string studentName)
    {
        string formatedStudentName = Util.FormatStudentName(studentName);

        if (!Validations.IsExistingStudent(students, studentName))
        {
            students[formatedStudentName] = new List<Dictionary<string, double>>();
            Console.WriteLine($"Student with name {formatedStudentName} succesfully added!");
        }
        else
            Console.WriteLine($"Student '{formatedStudentName}' already exists.");
    }
    public static void DeleteStudent(Dictionary<string, List<Dictionary<string, double>>> students, string studentName)
    {
        string formatedStudentName = Util.FormatStudentName(studentName);

        if (students.Count() == 0)
            Console.WriteLine("The list of students is empty!");
        else if (!Validations.IsExistingStudent(students, studentName))
            Console.WriteLine($"Student with name {formatedStudentName} does not exists.");
        else
        {
            students.Remove(formatedStudentName);
            Console.WriteLine($"Student with name {formatedStudentName} sucessfully deleted");
        }
    }

    public static void AssignStudentToSubject(Dictionary<string, List<Dictionary<string, double>>> students, string studentName, string subject)
    {
        string formatedStudentName = Util.FormatStudentName(studentName);

        if (Validations.IsExistingStudent(students, studentName))
        {
            string formatedSubject = Util.FirstCharToUpper(subject);
            students[formatedStudentName].Add(new Dictionary<string, double>() { { formatedSubject, 0 } });
            Console.WriteLine($"Student succesfully enroled in the {subject} class");
        }
        else
            Console.WriteLine($"Student with name {formatedStudentName} does not exists.");
    }

    public static void UpdateStudentGrade(Dictionary<string, List<Dictionary<string, double>>> students, string studentName, string subject, double grade)
    {
        string formatedStudentName = Util.FormatStudentName(studentName);

        if (Validations.IsExistingStudent(students, studentName))
        {
            string formatedSubject = Util.FirstCharToUpper(subject);
            students[formatedStudentName].Add(new Dictionary<string, double>() { { formatedSubject, grade } });
            Console.WriteLine($"Student's {formatedSubject} grade succesfully updated!");
        }
        else
            Console.WriteLine($"Student with name {formatedStudentName} does not exists.");
    }

    public static void DisplayAllStudents(Dictionary<string, List<Dictionary<string, double>>> students)
    {
        if (students.Count() == 0)
            Console.WriteLine("The list of students is empty!");
        else
        {
            foreach (var student in students)
            {
                string studentName = student.Key;
                Console.Write(studentName);

                if (student.Value.Count == 0)
                {
                    Console.WriteLine(" No subjects added yet.");
                }
                else
                {
                    List<string> enroledSubjects = new List<string>();
                    List<double> grades = new List<double>();

                    foreach (var subjectGrade in student.Value)
                    {
                        foreach (var key in subjectGrade)
                        {
                            if (!enroledSubjects.Contains(key.Key))
                                enroledSubjects.Add(key.Key);
                            if (key.Value != 0)
                                grades.Add(key.Value);
                        }
                    }

                    if (grades.Count() != 0)
                    {
                        double gradesAverage = grades.Average();
                        Console.WriteLine($", Subjects: {string.Join(", ", enroledSubjects)}\nAverage grade: {gradesAverage.ToString("0.00")}");
                    }
                    else
                        Console.WriteLine($", Subjects: {string.Join(", ", enroledSubjects)}\nAverage grade: 0.00");
                }
            }
        }
    }
}
