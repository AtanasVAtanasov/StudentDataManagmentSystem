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

                                if (!Validations.IsTheStudentNameFormatValid(studentName))
                                {
                                    Console.WriteLine("Incorrect student's name format!");
                                    break;
                                }

                                if (!Validations.IsTheStudentNameValid(studentName))
                                {
                                    Console.WriteLine("Incorrect student's name!");
                                    break;
                                }

                                Functions.AddStudent(students, studentName);
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Enter student name: ");
                                string studentName = Console.ReadLine();

                                if (!Validations.IsTheStudentNameFormatValid(studentName))
                                {
                                    Console.WriteLine("Incorrect student's name format!");
                                    break;
                                }

                                if (!Validations.IsTheStudentNameValid(studentName))
                                {
                                    Console.WriteLine("Incorrect student's name!");
                                    break;
                                }

                                Functions.DeleteStudent(students, studentName);
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Enter student name and subject: ");
                                string[] userInput = Console.ReadLine().Split("-");
                                string studentName = userInput[0];
                                string subject = userInput[1];

                                if (!Validations.IsTheStudentNameFormatValid(studentName))
                                {
                                    Console.WriteLine("Incorrect student's name format!");
                                    break;
                                }

                                if (!Validations.IsTheStudentNameValid(studentName))
                                {
                                    Console.WriteLine("Incorrect student's name!");
                                    break;
                                }

                                if (!Validations.IsTheSubjectValid(subjects, subject))
                                {
                                    Console.WriteLine("Incorrect subject's name!");
                                    break;
                                }

                                Functions.AssignStudentToSubject(students, studentName, subject);
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine("Enter student name: ");
                                string studentName = Console.ReadLine();

                                if (!Validations.IsTheStudentNameFormatValid(studentName))
                                {
                                    Console.WriteLine("Incorrect student's name format!");
                                    break;
                                }

                                if (!Validations.IsTheStudentNameValid(studentName))
                                {
                                    Console.WriteLine("Incorrect student's name!");
                                    break;
                                }

                                if (!Validations.IsExistingStudent(students, studentName))
                                {
                                    Console.WriteLine($"Student with name {Util.FormatStudentName(studentName)} does not exists.");
                                    break;
                                }

                                Console.WriteLine("Enter subject and grade: ");
                                string[] userInput = Console.ReadLine().Split("-");
                                string subject = userInput[0];
                                double grade;
                                bool isValidGredInput = double.TryParse(userInput[1], out grade);

                                if (!Validations.IsTheSubjectValid(subjects, subject))
                                {
                                    Console.WriteLine("Incorrect subject's name!");
                                    break;
                                }
                                if (!Validations.IsValidGrade(grade) || !isValidGredInput)
                                {
                                    Console.WriteLine("Incorrect grade!");
                                    break;
                                }

                                Functions.UpdateStudentGrade(students, studentName, subject, grade);
                                break;
                            }
                        case 5:
                            {
                                Functions.DisplayAllStudents(students);
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
    }
}
