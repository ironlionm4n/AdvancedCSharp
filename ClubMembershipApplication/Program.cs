using ClubMembershipApplication.Views;

namespace ClubMembershipApplication;

public class Program
{
    public static void Main(string[] args)
    {
        IView mainView = Factory.GetMainViewObject();
        mainView.RunView();
        Console.ReadKey();
    }
}