using ClubMembershipApplication.FieldValidators;

namespace ClubMembershipApplication.Views;

public class MainView : IView
{
    public IFieldValidator FieldValidator => null;
    private IView _registerView, _loginView;
    public MainView(IView registerView, IView loginView)
    {
        _registerView = registerView;
        _loginView = loginView;
    }
    public void RunView()
    {
        CommonOutputText.WriteMainHeading();
        Console.WriteLine("Please press 'l' to login or if you are not yet registered please register");
        var keyPressed = Console.ReadKey().Key;
        if (keyPressed == ConsoleKey.R)
        {
            RunUserRegistrationView();
            RunUserLoginView();
        } else if (keyPressed == ConsoleKey.L)
        {
            RunUserLoginView();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Goodbye");
            Console.ReadKey();
        }
        
        
    }

    private void RunUserRegistrationView()
    {
        _registerView.RunView();
    }

    private void RunUserLoginView()
    {
        _loginView.RunView();
    }
}