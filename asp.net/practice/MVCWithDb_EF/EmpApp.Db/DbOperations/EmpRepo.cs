using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpApp.Db.DbOperations
{
    public class EmpRepo
    {
        public int AddEmployee(EmployeeModel employee)
        {
            using (var connection = new DbDemoEFEntities())
            {
                tblEmployee emp = new tblEmployee()
                {
                    EmpId = employee.EmpId,
                    Name = employee.Name,
                    Address = employee.Address,
                    City = employee.City
                };
                connection.tblEmployee.Add(emp);
                connection.SaveChanges();
                return emp.Id;
            }
        }

        public List<EmployeeModel> GetAllEmployees()
        {
            using (var connection = new DbDemoEFEntities())
            {
                var listResult = connection.tblEmployee.Select(x => new EmployeeModel
                {
                    Id = x.Id,
                    EmpId = x.EmpId,
                    Name = x.Name,
                    Address = x.Address,
                    City = x.City
                }).ToList();

                return listResult;
            }
        }
        public EmployeeModel GetEmployee(int id)
        {
            using (var connection = new DbDemoEFEntities())
            {

                var listResult = connection.tblEmployee.Where(x => x.Id == id).Select(x => new EmployeeModel
                {
                    EmpId = x.EmpId,
                    Name = x.Name,
                    Address = x.Address,
                    City = x.City
                }).FirstOrDefault();

                return listResult;
            }
        }

        public bool UpdateEmployee(int id,EmployeeModel employee)
        {
            using (var connection = new DbDemoEFEntities())
            {
                var result = connection.tblEmployee.FirstOrDefault(x => x.Id == id);
                if(result != null)
                {
                    result.Name = employee.Name;
                    result.Address = employee.Address;
                    result.City = employee.City;
                    connection.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool DeleteEmployee(int id)
        {
            using(var connection = new DbDemoEFEntities())
            {
                var result = connection.tblEmployee.FirstOrDefault(x => x.Id == id);
                if (result != null)
                {
                    connection.tblEmployee.Remove(result);
                    connection.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
