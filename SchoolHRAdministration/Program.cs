using HRAdministrationAPI;

namespace SchoolHRAdministration;

public enum EmployeeType
{
    Teacher,
    HeadOfDepartment,
    DeputyHeadMaster,
    HeadMaster
}
public class Program
{
    public static void Main(string[] args)
    {
        var totalSalaries = 0m;
        var employees = new List<IEmployee>();
        SeedData(employees);
        
        Console.WriteLine($"Total Annual Salary (including bonus): {employees.Sum(employee => employee.Salary)}");
        Console.ReadKey();
    }
    
    public static void SeedData(List<IEmployee> employees)
    {
        var teacher1 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 1, "Tommy", "Eichenberg", 40000);
        var teacher2 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 2, "Donovan", "Jackson", 45000);
        var headOfDepartment =
            EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 3, "Kyle", "McCord", 60000);
        var deputyHeadMaster =
            EmployeeFactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster, 4, "Marvin", "Harrison", 80000);
        var headMaster =
            EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadMaster, 5, "Miyan", "Williams", 90000);
        employees.Add(teacher1);
        employees.Add(teacher2);
        employees.Add(headOfDepartment);
        employees.Add(deputyHeadMaster);
        employees.Add(headMaster);
    }
}



public class Teacher : EmployeeBase
{
    public override decimal Salary { get => base.Salary + (base.Salary * 0.02m); }
}

public class HeadOfDepartment : EmployeeBase
{
    public override decimal Salary { get => base.Salary + (base.Salary * 0.03m); }
}

public class DeputyHeadMaster : EmployeeBase
{
    public override decimal Salary { get => base.Salary + (base.Salary * 0.04m); }
}

public class HeadMaster : EmployeeBase
{
    public override decimal Salary { get => base.Salary + (base.Salary * 0.05m); }
}

public static class EmployeeFactory
{
    public static IEmployee GetEmployeeInstance(EmployeeType employeeType, int id, string firstName, string lastName,
        decimal salary)
    {
        IEmployee employee = null;

        switch (employeeType)
        {
            case EmployeeType.Teacher:
            {
                employee = FactoryPattern<IEmployee, Teacher>.GetInstance();
                break;
            }
            case EmployeeType.HeadMaster:
            {
                employee = FactoryPattern<IEmployee, HeadMaster>.GetInstance();
                break;
            }
            case EmployeeType.DeputyHeadMaster:
            {
                employee = FactoryPattern<IEmployee, DeputyHeadMaster>.GetInstance();
                break;
            }
            case EmployeeType.HeadOfDepartment:
            {
                employee = FactoryPattern<IEmployee, HeadOfDepartment>.GetInstance();
                break;
            }
            default: break;
        }

        if (employee != null)
        {
            employee.ID = id;
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.Salary = salary;
        }
        else
        {
            throw new NullReferenceException("Employee is null, check for correct employee type");
        }
        return employee;
    }
}