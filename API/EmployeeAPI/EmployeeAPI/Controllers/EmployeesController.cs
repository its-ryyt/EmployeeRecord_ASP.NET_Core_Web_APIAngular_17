using EmployeeAPI.Data;
using EmployeeAPI.Models;
using EmployeeAPI.Models.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeDbContext dbContext;

        public EmployeesController(EmployeeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employeeContext = dbContext.Employees.ToList();
            var employeesList = new List<Employee>();


            if (employeeContext.Any())
            {
                foreach (var items in employeeContext)
                {
                    var newEmplpoyeeList = new Employee
                    {
                        Id = items.Id,
                        Fullname = items.Lastname + ", " + items.Firstname + " " + items.Middlename,
                        Firstname = items.Firstname,
                        Lastname = items.Lastname,
                        Middlename = items.Middlename,
                        Gender = items.Gender,
                        DateofBirth = items.DateofBirth,
                        Email = items.Email,
                        PhoneNumber = items.PhoneNumber,
                        HomeAddress = items.HomeAddress,
                        isActive = items.isActive
                    };

                    employeesList.Add(newEmplpoyeeList);
                }
            }


            return Ok(employeeContext);
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeRequestModel requestModel)
        {
            var empRequestModel = new Employee
            {
                Id = Guid.NewGuid(),
                Fullname = requestModel.Lastname + ", " + requestModel.Firstname + " " + requestModel.Middlename,
                Firstname = requestModel.PhoneNumber,
                Lastname = requestModel.Lastname,
                Middlename = requestModel.Middlename,
                Gender = requestModel.Gender,
                DateofBirth = requestModel.DateofBirth,
                Email = requestModel.Email,
                PhoneNumber = requestModel.PhoneNumber,
                HomeAddress = requestModel.HomeAddress,
                isActive = requestModel.isActive
            };

            dbContext.Employees.Add(empRequestModel);
            dbContext.SaveChanges();

            return Ok(empRequestModel);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = dbContext.Employees.Find(id);

            if (employee is not null)
            {
                dbContext.Employees.Remove(employee);
                dbContext.SaveChanges();
            }

            return Ok();
        }
    }
}
