﻿namespace FirstW.Models
{
    public class RepositoryEmployee
    {


        private NorthwindContext _context;
        public RepositoryEmployee(NorthwindContext context)
        {
            _context = context;
        }
        public List<Employee> AllEmployees()
        {
            return _context.Employees.ToList();
        }
        public Employee FindEmpoyeeById(int id)
        {
            var employeeId = _context.Employees.Find(id);
            return employeeId;
        }
        public int AddEmployee(Employee newEmployee)
        {
            _context.Employees.Add(newEmployee);
            return _context.SaveChanges();
        }
        
        public int DeleteEmployee(int id)
        {

            Employee emp = _context.Employees.Find(id);
            context.Employees.Remove(emp);
            return _context.SaveChanges();
        }
        public Employee UpdateEmployee(Employee updatedEmployee)
        {
            _context.Employees.Update(updatedEmployee);
            
            _context.SaveChanges();
            return updatedEmployee;
        }
    }

}