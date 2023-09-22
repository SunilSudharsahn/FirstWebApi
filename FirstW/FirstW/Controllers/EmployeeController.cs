using FirstW.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private RepositoryEmployee _repositoryEmployee;
        public EmployeeController(RepositoryEmployee repository)
        {
            _repositoryEmployee = repository;
        }
        [HttpGet("/GetAllEmployees")]
        public IEnumerable<EmpViewModel> GetAllEmployee()
        {
            List<Employee> employees = _repositoryEmployee.AllEmployees();
            var  emplist=( from emp in employees
                           select new EmpViewModel()
                           {
                               EmpId=emp.EmployeeId,
                               FirstName=emp.FirstName,
                               LastName=emp.LastName,
                               BirthDate=emp.BirthDate,
                               HireDate=emp.HireDate,
                               Title=emp.Title,
                               City=emp.City,
                               ReportsTo=emp.ReportsTo,
                           }).ToList();
        return emplist;
        }
        [HttpGet("/ListAllEmployees")]
        public List<Employee> ListAllEmployees()
        {
            List<Employee> employeesList = _repositoryEmployee.AllEmployees();
            return employeesList;
        }
        [HttpGet("/FindAllEmployee")]
        public Employee FindEmployee(int id)
        {
            Employee employeeById = _repositoryEmployee.FindEmpoyeeById(id);
            return employeeById;
        }
        [HttpPost("/AddEmployee")]
        public string AddEmployee(Employee newEmployee)
        {
            int employeestatus = _repositoryEmployee.AddEmployee(newEmployee);
            if (employeestatus == 0)
            {
                return "Employee Not Added To Database Since it already exist";
            }
            else
            {
                return "Employee Added To Database";
            }
        }
        
        [HttpDelete("/DeleteEmployee")]
        public string DeleteEmployee(int id)
        {
            int employeestatus = _repositoryEmployee.DeleteEmployee(id);
            if (employeestatus == 0)
            {
                return "Employee does not exist in the Database";
            }
            else
            {
                return "Employee Successfully Deleted";
            }
        }
       
        [HttpPut]
        public Employee EditEmployee(int id, [FromBody] Employee updatedEmployee)
        {

            updatedEmployee.EmployeeId = id; 



            Employee savedEmployee = _repositoryEmployee.UpdateEmployee(updatedEmployee);
            return savedEmployee;
        }
    }
}
