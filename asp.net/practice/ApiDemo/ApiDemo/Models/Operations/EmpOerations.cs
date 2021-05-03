using ApiDemo.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ApiDemo.Models.Operations
{
    public class EmpOerations
    {
        public int AddEmployee([FromBody] Employee employee)
        {
            try
            {
                using (var context = new DbDemoEFEntities())
                {
                    tblEmployee emp = new tblEmployee()
                    {
                        EmpId = employee.EmpId,
                        Name = employee.Name,
                        Address = employee.Address,
                        City = employee.City,
                        IsDelete = false,
                    };
                    context.tblEmployee.Add(emp);
                    context.SaveChanges();
                    return emp.Id;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public IEnumerable<tblEmployee> GetEmployees()
        {
            using (var context = new DbDemoEFEntities())
            {
                try
                {
                    return context.tblEmployee.Where(x => x.IsDelete == false).ToList();

                    //var list = context.tblEmployee.Select(x => new tblEmployee()
                    //{
                    //    Id = x.Id,
                    //    EmpId = x.EmpId,
                    //    Name = x.Name,
                    //    City = x.City,
                    //    Address = x.Address
                    //}).ToList();
                    //return list;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public tblEmployee GetEmployee(int id)
        {
            using (var context = new DbDemoEFEntities())
            {
                try
                {
                    var isId = context.tblEmployee.Where(x => x.IsDelete == false).FirstOrDefault(x => x.Id == id);
                    if (isId != null)
                    {
                        return isId;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public bool UpdateEmployee(int id, Employee employee)
        {
            using (var context = new DbDemoEFEntities())
            {
                try
                {
                    var emp = context.tblEmployee.Where(x => x.IsDelete == false).FirstOrDefault(x => x.Id == id);
                    if (emp != null)
                    {
                        emp.EmpId = employee.EmpId;
                        emp.Name = employee.Name;
                        emp.Address = employee.Address;
                        emp.City = employee.City;
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public bool DeleteEmployee(int id)
        {
            using (var context = new DbDemoEFEntities())
            {
                try
                {
                    var isId = context.tblEmployee.Where(x => x.IsDelete == false).FirstOrDefault(x => x.Id == id);
                    if (isId != null)
                    {
                        //context.tblEmployee.Remove(isId);
                        isId.IsDelete = true;
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

    }
}