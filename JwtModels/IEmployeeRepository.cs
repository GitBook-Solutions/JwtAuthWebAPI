using System;
using System.Collections.Generic;
namespace JwtModels
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployeeList();
        Employee GetEmployeebyId(int Id);
    }
}