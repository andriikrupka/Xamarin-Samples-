using System.Collections.Generic;
using ForceTouchNavigationSample.Models;
using Newtonsoft.Json;

namespace ForceTouchNavigationSample.DataAccess
{
    public class EmployeesProvider : IEmployeesProvider
    {
        private const string FilePath = "mock_data.json";

        public List<Employee> GetEmployees()
        {
            var data = System.IO.File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<Employee>>(data);
        }
    }
}
