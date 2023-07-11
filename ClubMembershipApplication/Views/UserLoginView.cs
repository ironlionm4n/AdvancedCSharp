using ClubMembershipApplication.Data;
using ClubMembershipApplication.FieldValidators;

namespace ClubMembershipApplication.Views;

public class UserLoginView : IView
{
    private ILogin _loginUser = null;
    public UserLoginView(ILogin iLogin)
    {
        _loginUser = iLogin;
    }
    public void RunView()
    {
        CommonOutputText.WriteMainHeading();
        CommonOutputText.WriteLoginHeading();
        Console.WriteLine("Please enter your email address");
        var emailAddress = Console.ReadLine();
        Console.WriteLine("Please enter your password");
        var password = Console.ReadLine();

        var user = _loginUser.Login(emailAddress, password);
        if (user != null)
        {
            var welcomeUserView = new WelcomeUserView(user);
            welcomeUserView.RunView();
        }
        else
        {
            Console.Clear();
            CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
            Console.WriteLine("The user was not found");
            CommonOutputFormat.ChangeFontColor(FontTheme.Default);
        }
    }

    public IFieldValidator FieldValidator => null;
}