using ClubMembershipApplication.FieldValidators;

namespace ClubMembershipApplication.Views;

public interface IView
{
    void RunView();
    IFieldValidator FieldValidator { get; }
}