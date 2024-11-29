class Validations
{
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
}
