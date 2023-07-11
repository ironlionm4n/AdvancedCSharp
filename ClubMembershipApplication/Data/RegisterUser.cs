using ClubMembershipApplication.Models;
using ClubMembershipApplication.FieldValidators;

namespace ClubMembershipApplication.Data;

public class RegisterUser : IRegister
{
    public bool Register(string[] fields)
    {
        using (var dbContext = new ClubMembershipDbContext())
        {
            var user = new User()
            {
                EmailAddress = fields[(int)FieldConstants.UserRegistrationField.EmailAddress],
                FirstName = fields[(int)FieldConstants.UserRegistrationField.FirstName],
                LastName = fields[(int)FieldConstants.UserRegistrationField.LastName],
                PhoneNumber = fields[(int)FieldConstants.UserRegistrationField.PhoneNumber],
                DateOfBirth = DateTime.Parse(fields[(int)FieldConstants.UserRegistrationField.DateOfBirth]),
                AddressFirstLine = fields[(int)FieldConstants.UserRegistrationField.AddressFirstLine],
                AddressSecondLine = fields[(int)FieldConstants.UserRegistrationField.AddressSecondLine],
                AddressCity = fields[(int)FieldConstants.UserRegistrationField.AddressCity],
                PostCode = fields[(int)FieldConstants.UserRegistrationField.PostCode],
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }

        return true;
    }

    public bool EmailExists(string emailAddress)
    {
        var emailExists = false;
        using (var dbContext = new ClubMembershipDbContext())
        {
            emailExists = dbContext.Users.Any(user =>
                string.Equals(user.EmailAddress.ToLower().Trim(), emailAddress, StringComparison.Ordinal));
        }

        return emailExists;
    }
}