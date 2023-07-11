using ClubMembershipApplication.Data;
using ClubMembershipApplication.FieldValidators;

namespace ClubMembershipApplication.Views;

public class UserRegistrationView : IView
{
    private IFieldValidator _fieldValidator;
    public IFieldValidator FieldValidator => _fieldValidator;
    
    private IRegister _iRegister;

    public UserRegistrationView(IRegister iRegister, IFieldValidator iFieldValidator)
    {
        _iRegister = iRegister;
        _fieldValidator = iFieldValidator;
    }

    public void RunView()
    {
        CommonOutputText.WriteRegistrationHeading();

        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.EmailAddress] =
            GetInputFromUser(FieldConstants.UserRegistrationField.EmailAddress, "Please Enter Email Address:");
        
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.FirstName] =
            GetInputFromUser(FieldConstants.UserRegistrationField.EmailAddress, "Please Enter First Name:");
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.LastName] =
            GetInputFromUser(FieldConstants.UserRegistrationField.EmailAddress, "Please Enter Last Name:");
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.Password] =
            GetInputFromUser(FieldConstants.UserRegistrationField.EmailAddress, "Please Enter Valid Password - must contain at least 1 small-case letter, 1 capital letter, 1 digit, 1 special character:");
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.PasswordCompare] =
            GetInputFromUser(FieldConstants.UserRegistrationField.EmailAddress, "Please re-enter exact Password:");
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.PhoneNumber] =
            GetInputFromUser(FieldConstants.UserRegistrationField.EmailAddress, "Please Enter Phone Number:");
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.AddressFirstLine] =
            GetInputFromUser(FieldConstants.UserRegistrationField.EmailAddress, "Please Enter Address First Line:");
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.AddressSecondLine] =
            GetInputFromUser(FieldConstants.UserRegistrationField.EmailAddress, "Please Enter Address Second Line:");
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.AddressCity] =
            GetInputFromUser(FieldConstants.UserRegistrationField.EmailAddress, "Please Enter Address City:");
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.DateOfBirth] =
            GetInputFromUser(FieldConstants.UserRegistrationField.EmailAddress, "Please Enter Date of Birth:");

        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.PostCode] =
            GetInputFromUser(FieldConstants.UserRegistrationField.EmailAddress, "Please Enter Post Code:");
        
        RegisterUser();
    }

    private string GetInputFromUser(FieldConstants.UserRegistrationField field, string promptText)
    {
        var fieldVal = "";

        do
        {
            Console.WriteLine(promptText);
            fieldVal = Console.ReadLine();
        } while (!FieldValid(field, fieldVal));

        return fieldVal;
    }

    private bool FieldValid(FieldConstants.UserRegistrationField field, string fieldValue)
    {
        if (_fieldValidator.ValidatorDel((int) field, fieldValue, _fieldValidator.FieldArray, out string invalidMessage))
        {
            CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
            
            Console.WriteLine(invalidMessage);
            
            CommonOutputFormat.ChangeFontColor(FontTheme.Default);
            return false;
        }
        return true;
    }

    private void RegisterUser()
    {
        _iRegister.Register(_fieldValidator.FieldArray);
        
        CommonOutputFormat.ChangeFontColor(FontTheme.Success);
        Console.WriteLine("Successfully added");
        CommonOutputFormat.ChangeFontColor(FontTheme.Default);
    }
}