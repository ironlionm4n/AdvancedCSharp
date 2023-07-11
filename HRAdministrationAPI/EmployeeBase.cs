namespace HRAdministrationAPI;

public abstract class EmployeeBase : IEmployee
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public virtual decimal Salary { get; set; }
}