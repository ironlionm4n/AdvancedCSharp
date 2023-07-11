

namespace ClubMembershipApplication;

public enum FontTheme
{
    Default,
    Danger,
    Success
}

public static class CommonOutputFormat
{
    public static void ChangeFontColor(FontTheme fontTheme)
    {
        switch (fontTheme)
        {
            case FontTheme.Default:
            {
                Console.ResetColor();
                break;
            }
            case FontTheme.Danger:
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                break;
            }
            case FontTheme.Success:
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
                break;
            }
            default: Console.ResetColor();
                break;
        }
    }
}