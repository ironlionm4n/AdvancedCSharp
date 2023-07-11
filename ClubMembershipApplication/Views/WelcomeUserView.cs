using ClubMembershipApplication.FieldValidators;
using ClubMembershipApplication.Models;

namespace ClubMembershipApplication.Views;

public class WelcomeUserView : IView
{
    private User _user = null;

    public WelcomeUserView(User user)
    {
        _user = user;
    }
    
    public void RunView()
    {
        CommonOutputFormat.ChangeFontColor(FontTheme.Success);
        Console.WriteLine($"Hello {_user.FirstName}!{Environment.NewLine}Welcome to the Cycling Club");
        CommonOutputFormat.ChangeFontColor(FontTheme.Default);
        Console.ReadKey();
    }

    public IFieldValidator FieldValidator => null;
}