namespace ClubMembershipApplication;

public class CommonOutputText
{
    private static string MainHeading
    {
        get
        {
            var heading = "Cycling Club";
            return $"{heading}{Environment.NewLine}{new string('-', heading.Length)}";
        }
    }

    private static string RegistrationHeading
    {
        get
        {
            var heading = "Register";
            return $"{heading}{Environment.NewLine}{new string('-', heading.Length)}";
        }
    }
    
    private static string LoginHeading
    {
        get
        {
            var heading = "Login";
            return $"{heading}{Environment.NewLine}{new string('-', heading.Length)}";
        }
    }
    
    public static void WriteMainHeading()
    {
        Console.Clear();
        Console.WriteLine(MainHeading);
        Console.WriteLine();
        Console.WriteLine();
    }
    
    public static void WriteLoginHeading()
    {
        Console.Clear();
        Console.WriteLine(LoginHeading);
        Console.WriteLine();
        Console.WriteLine();
    }
    
    public static void WriteRegistrationHeading()
    {
        Console.Clear();
        Console.WriteLine(RegistrationHeading);
        Console.WriteLine();
        Console.WriteLine();
    }
}