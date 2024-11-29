namespace MyApp
{
    class Exec
    {

        static void Main(string[] args)
        {
            int choice;
            List<string> subjects = new List<string>() { "Math", "Biology", "History", "English", "Sport", "Physics" };
            Dictionary<string, List<Dictionary<string, double>>> students = new Dictionary<string, List<Dictionary<string, double>>>();

            do
            {
                Console.WriteLine("Choose an option:\n" +
                    "1. Add a new student\n" +
                    "2. Remove a student\n" +
                    "3. Assign student to subject\n" +
                    "4. Update a student's grades\n" +
                    "5. Display all students\n" +
                    "6. Exit\n");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Incorrect input!");
                    continue;
                }
                else if (choice <= 0 || choice > 6)
                {
                    Console.WriteLine("Incorrect input!");
                    continue;
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            {
                                Console.WriteLine("Enter student name: ");
                                string studentName = Console.ReadLine();

                                if (!IsTheStudentNameFormatValid(studentName))
                                {
                                    Console.WriteLine("Incorrect student's name format!");
                                    break;
                                }

                                if (!IsTheStudentNameValid(studentName))
                                {
                                    Console.WriteLine("Incorrect student's name!");
                                    break;
                                }

                                AddStudent(students, studentName);
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Enter student name: ");
                                string studentName = Console.ReadLine();

                                if (!IsTheStudentNameFormatValid(studentName))
                                {
                                    Console.WriteLine("Incorrect student's name format!");
                                    break;
                                }

                                if (!IsTheStudentNameValid(studentName))
                                {
                                    Console.WriteLine("Incorrect student's name!");
                                    break;
                                }

                                DeleteStudent(students, studentName);
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Enter student name and subject: ");
                                string[] userInput = Console.ReadLine().Split("-");
                                string studentName = userInput[0];
                                string subject = userInput[1];

                                if (!IsTheStudentNameFormatValid(studentName))
                                {
                                    Console.WriteLine("Incorrect student's name format!");
                                    break;
                                }

                                if (!IsTheStudentNameValid(studentName))
                                {
                                    Console.WriteLine("Incorrect student's name!");
                                    break;
                                }

                                if (!IsTheSubjectValid(subjects, subject))
                                {
                                    Console.WriteLine("Incorrect subject's name!");
                                    break;
                                }

                                AssignStudentToSubject(students, studentName, subject);
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine("Enter student name: ");
                                string studentName = Console.ReadLine();

                                if (!IsTheStudentNameFormatValid(studentName))
                                {
                                    Console.WriteLine("Incorrect student's name format!");
                                    break;
                                }

                                if (!IsTheStudentNameValid(studentName))
                                {
                                    Console.WriteLine("Incorrect student's name!");
                                    break;
                                }

                                if (!IsExistingStudent(students, studentName))
                                {
                                    Console.WriteLine($"Student with name {FormatStudentName(studentName)} does not exists.");
                                    break;
                                }

                                Console.WriteLine("Enter subject and grade: ");
                                string[] userInput = Console.ReadLine().Split("-");
                                string subject = userInput[0];
                                double grade;
                                bool isValidGredInput = double.TryParse(userInput[1], out grade);

                                if (!IsTheSubjectValid(subjects, subject))
                                {
                                    Console.WriteLine("Incorrect subject's name!");
                                    break;
                                }
                                if (!IsValidGrade(grade) || !isValidGredInput)
                                {
                                    Console.WriteLine("Incorrect grade!");
                                    break;
                                }

                                UpdateStudentGrade(students, studentName, subject, grade);
                                break;
                            }
                        case 5:
                            {
                                DisplayAllStudents(students);
                                break;
                            }
                        case 6:
                            {
                                Console.WriteLine("Exiting the system. Goodbay");
                                break;
                            }
                    }
                    Console.WriteLine();
                }
            }
            while (choice != 6);
        }

        public static void AddStudent(Dictionary<string, List<Dictionary<string, double>>> students, string studentName)
        {
            string formatedStudentName = FormatStudentName(studentName);

            if (!IsExistingStudent(students, studentName))
            {
                students[formatedStudentName] = new List<Dictionary<string, double>>();
                Console.WriteLine($"Student with name {formatedStudentName} succesfully added!");
            }
            else
                Console.WriteLine($"Student '{formatedStudentName}' already exists.");
        }
        public static void DeleteStudent(Dictionary<string, List<Dictionary<string, double>>> students, string studentName)
        {
            string formatedStudentName = FormatStudentName(studentName);

            if (students.Count() == 0)
                Console.WriteLine("The list of students is empty!");
            else if (!IsExistingStudent(students, studentName))
                Console.WriteLine($"Student with name {formatedStudentName} does not exists.");
            else
            {
                students.Remove(formatedStudentName);
                Console.WriteLine($"Student with name {formatedStudentName} sucessfully deleted");
            }
        }

        public static void AssignStudentToSubject(Dictionary<string, List<Dictionary<string, double>>> students, string studentName, string subject)
        {
            string formatedStudentName = FormatStudentName(studentName);

            if (IsExistingStudent(students, studentName))
            {
                string formatedSubject = FirstCharToUpper(subject);
                students[formatedStudentName].Add(new Dictionary<string, double>() { { formatedSubject, 0 } });
                Console.WriteLine($"Student succesfully enroled in the {subject} class");
            }
            else
                Console.WriteLine($"Student with name {formatedStudentName} does not exists.");
        }

        public static void UpdateStudentGrade(Dictionary<string, List<Dictionary<string, double>>> students, string studentName, string subject, double grade)
        {
            string formatedStudentName = FormatStudentName(studentName);

            if (IsExistingStudent(students, studentName))
            {
                string formatedSubject = FirstCharToUpper(subject);
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

                        if (grades.Count()!=0)
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

        public static bool IsTheInputAlphabeticOnly(string userInput)
        {
            foreach (char ch in userInput)
            {
                if (!char.IsLetter(ch))
                    return false;
            }

            return true;
        }

        public static bool IsExistingStudent(Dictionary<string, List<Dictionary<string, double>>> students, string studentName)
        {
            foreach (var student in students)
            {
                if (student.Key.ToLower().Replace(" ", "").Equals(studentName.ToLower().Replace(" ", "")))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsTheStudentNameValid(string studentName)
        {
            studentName = studentName.ToLower().Replace(" ", "");

            if (string.IsNullOrEmpty(studentName) || !IsTheInputAlphabeticOnly(studentName))
            {
                return false;
            }
            return true;
        }

        public static bool IsTheSubjectValid(List<string> subjects, string subject)
        {
            subject = subject.ToLower().Replace(" ", "");

            if (string.IsNullOrEmpty(subject) || !IsTheInputAlphabeticOnly(subject) || !subjects.ConvertAll(low => low.ToLower()).Contains(subject))
            {
                return false;
            }
            return true;
        }

        public static bool IsValidGrade(double grade)
        {
            if (grade <= 0)
                return false;
            if (grade < 2 || grade > 6)
                return false;
            return true;
        }

        public static bool IsTheStudentNameFormatValid(string userInput)
        {
            if (!userInput.Contains(" ") || userInput.Split(" ").Length > 2)
                return false;
            return true;
        }

        public static string FirstCharToUpper(string text)
        {
            char firstLetter = text[0];

            if (char.IsLower(firstLetter))
            {
                string replacedText = string.Concat(char.ToUpper(firstLetter), text.Substring(1));
                return replacedText;
            }
            else
                return text;
        }

        public static string FormatStudentName(string studentName)
        {
            string studentFirstName = studentName.Split(" ")[0];
            string studentLastName = studentName.Split(" ")[1];
            string formatedStudentName = $"{FirstCharToUpper(studentFirstName)} {FirstCharToUpper(studentLastName)}";

            return formatedStudentName;
        }
    }
}
