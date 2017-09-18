using System.Collections.Generic;
using ForceTouchNavigationSample.Models;

namespace ForceTouchNavigationSample.DataAccess
{
    public interface IEmployeesProvider
    {
        List<Employee> GetEmployees();
    }
}
