using System;
using System.Collections.Generic;
using System.Linq;
namespace JwtModels
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public EmployeeRepository()
        {
            _employeeList= new List<Employee>
            {
                new Employee() { Id = 1, Name = "Mary", Department = "HR", Email = "mary@dmat.com" },
                new Employee() { Id = 2, Name = "John", Department = "IT", Email = "john@dmat.com" },
                new Employee() { Id = 3, Name = "Shyam", Department = "IT", Email = "shyam@dmat.com" },
                new Employee() { Id = 4, Name = "Anoop", Department = "IT", Email = "anoop@dmat.com" },
            };
        }
        public List<Employee> GetEmployeeList()
        {
            return this._employeeList;
        }
        public Employee GetEmployeebyId(int Id)
        {
            return this._employeeList.FirstOrDefault(e => e.Id == Id);
        }
    }
}