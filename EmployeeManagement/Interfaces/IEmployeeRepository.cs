using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Interfaces
{
    internal interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
        void SaveEmployee(Employee employee);
        void DeleteEmployee(int employeeId);
    }
}
