using MyModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Db.DbOperations
{
    public class EmployeeRepo
    {
        public int AddEmployee(EmployeeModel model)
        {
            using(var conn = new DbDemoEFEntities())
            {
                tblEmployee employee = new tblEmployee()
                {
                    EmpId = model.EmpId,
                    Name = model.Name,
                    Address = model.Address,
                    City = model.City
                };
                conn.tblEmployee.Add(employee);
                conn.SaveChanges();
                return employee.Id;
            }
        }

        public List<EmployeeModel> GetAllEmployees()
        {
            using (var conn = new DbDemoEFEntities())
            {
                var result = conn.tblEmployee.Select(x => new EmployeeModel()
                {
                    Id = x.Id,
                    EmpId = x.EmpId,
                    Name = x.Name,
                    Address = x.Address,
                    City = x.City

                }).ToList();

                return result;
            }
        }

        public EmployeeModel GetEmployee(int id)
        {
            using (var conn = new DbDemoEFEntities())
            {
                var employee = conn.tblEmployee.Select(x => new EmployeeModel()
                {
                    Id = x.Id,
                    EmpId = x.EmpId,
                    Name = x.Name,
                    City = x.City,
                    Address = x.Address
                }).FirstOrDefault(x => x.Id == id);

                return employee;
            }
        }

        public bool UpdateEmployee(int id, EmployeeModel model)
        {
            using (var conn = new DbDemoEFEntities())
            {
                var result = conn.tblEmployee.FirstOrDefault(x => x.Id == id);
                if(result != null)
                {
                    result.EmpId = model.EmpId;
                    result.Name = model.Name;
                    result.Address = model.Address;
                    result.City = model.City;
                    conn.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public bool DeleteEmployee(int id)
        {
            using (var conn = new DbDemoEFEntities())
            {
                var result = conn.tblEmployee.FirstOrDefault(x => x.Id == id);
                if (result != null)
                {
                    conn.tblEmployee.Remove(result);
                    conn.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
