namespace MyApp
{
    class Exec
    {
        List<string> subjects = new List<string>() { "Math", "Biology", "History", "English", "Sport", "Physics" };

        static void Main(string[] args)
        {
            int choice;
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
                else if (choice <= 0)
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
                                if (!isTheStudentNameValid(studentName))
                                    break;
                                addStudent(students, studentName);
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Enter student name: ");
                                string studentName = Console.ReadLine();
                                if (!isTheStudentNameValid(studentName))
                                    break;
                                deleteStudent(students, studentName);
                                break;
                            }
                        case 3:
                            {
                                assignStudentToSubject();
                                break;
                            }
                        case 4:
                            {
                                updateStudentGrade();
                                break;
                            }
                        case 5:
                            {
                                displayAllStudents(students);
                                break;
                            }
                        case 6:
                            {
                                Console.WriteLine("Exiting the system. Goodbay");
                                break;
                            }
                    }
                }
            }
            while (choice != 6);
        }
        public static void addStudent(Dictionary<string, List<Dictionary<string, double>>> students, string studentName)
        {
            if (!students.ContainsKey(studentName))
                students[studentName] = new List<Dictionary<string, double>>();
            else
                Console.WriteLine($"Student '{studentName}' already exists.");
        }
        public static void deleteStudent(Dictionary<string, List<Dictionary<string, double>>> students, string studentName)
        {
            if (students.Count() == 0)
                Console.WriteLine("The list of students is empty!");
            else if (isExistingStudent(students, studentName))
                students.Remove(studentName);

        }
        public static void assignStudentToSubject()
        {

        }
        public static void updateStudentGrade()
        {

        }
        public static void displayAllStudents(Dictionary<string, List<Dictionary<string, double>>> students)
        {
            if (students.Count() == 0)
                Console.WriteLine("The list of students is empty!");
            else
            {
                foreach (var student in students)
                {
                    Console.WriteLine($"Student: {student.Key}");
                    if (student.Value.Count == 0)
                    {
                        Console.WriteLine("No subjects added yet.");
                    }
                    else
                    {
                        foreach (var subjectGrade in student.Value)
                        {
                            foreach (var subjectGradePair in subjectGrade)
                            {
                                Console.WriteLine($"Subject: {subjectGradePair.Key}, Grade: {subjectGradePair.Value}");
                            }
                        }
                    }
                }
            }
            Console.WriteLine();
        }

        public static bool isTheInputAlphabeticOnly(string userInput)
        {
            foreach (char ch in userInput)
            {
                if (!char.IsLetter(ch))
                    return false;
            }

            return true;
        }

        public static bool isExistingStudent(Dictionary<string, List<Dictionary<string, double>>> students, string studentName)
        {
            foreach (var student in students)
            {
                if (student.Key.Contains(studentName))
                {
                    return true;
                }
            }
            Console.WriteLine($"Student '{studentName}' does not exists.");
            return false;
        }

        public static bool isTheStudentNameValid(string userInput)
        {
            userInput = userInput.ToLower().Replace(" ", "");
            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Incorrect student's name!");
                return false;
            }
            else if (!isTheInputAlphabeticOnly(userInput))
            {
                Console.WriteLine("Incorrect student's name!");
                return false;
            }
            return true;
        }
    }
}
