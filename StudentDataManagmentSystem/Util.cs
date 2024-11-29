class Util
{
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
