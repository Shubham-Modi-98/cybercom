using InventoryDbLayer.Db.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDbLayer.Db.DbOperations
{
    public class CustomerOp
    {
        InventoryManagementEntities context = null;
        public CustomerOp()
        {
            context = new InventoryManagementEntities();
        }

        public int AddCustomer(CustomerIms customer)
        {
            try
            {
                using (context)
                {
                    Customer cust = new Customer()
                    {
                        Name = customer.Name,
                        Email = customer.Email,
                        Phone = customer.Phone,
                        Status = false,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now
                    };
                    context.Customer.Add(cust);
                    context.SaveChanges();
                    int custId = cust.CustomerID;
                    if (custId > 0)
                        return custId;
                    else
                        return 0;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return 0;
            }
        }

        public int GetCustomerCounts()
        {
            try
            {
                using (context)
                {
                    int custCount = context.Customer.Where(c => c.Status == false).Count();
                    if (custCount > 0)
                        return custCount;
                    else
                        return 0;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return 0;
            }
        }

        public List<CustomerIms> GetAllCustomers()
        {
            try
            {
                using (context)
                {
                    var custList = context.Customer.Where(c => c.Status == false).Select(c => new CustomerIms()
                    {
                        CustomerID = c.CustomerID,
                        Name = c.Name,
                        Email = c.Email,
                        Phone = c.Phone,
                        UpdatedDate = c.UpdatedDate,
                    }).ToList();
                    if (custList != null)
                        return custList;
                    else
                        return null;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
            }
        }

        public List<CustomerIms> GetCustomers(int recordSkip = 0, int recordTake = 5)
        {
            try
            {
                using (context)
                {
                    var custList = context.Customer.Where(c => c.Status == false).Select(c => new CustomerIms() 
                    {
                        CustomerID = c.CustomerID,
                        Name = c.Name,
                        Email = c.Email,
                        Phone = c.Phone,
                        UpdatedDate = c.UpdatedDate,
                    }).OrderBy(x => 1 == 1).Skip(recordSkip).Take(recordTake).ToList();
                    if (custList != null)
                        return custList;
                    else
                        return null;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
            }
        }
        public CustomerIms GetCustomer(int id)
        {
            try
            {
                using (context)
                {
                    var customer = context.Customer.Where(c => c.Status == false).Select(c => new CustomerIms()
                    {
                        CustomerID = c.CustomerID,
                        Name = c.Name,
                        Email = c.Email,
                        Phone = c.Phone,
                        UpdatedDate = c.UpdatedDate,
                    }).FirstOrDefault(x => x.CustomerID == id); 
                    if (customer != null)
                        return customer;
                    else
                        return null;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
            }
        }

        public bool UpdateCustomer(int id, CustomerIms customer)
        {
            try
            {
                using (context)
                {
                    var cust = context.Customer.Where(c => c.Status == false).FirstOrDefault(c => c.CustomerID == id);
                    if (cust != null)
                    {
                        cust.Name = customer.Name;
                        cust.Email = customer.Email;
                        cust.Phone = customer.Phone;
                        cust.UpdatedDate = DateTime.Now;
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return false;
            }
        }

        public bool DeleteCustomer(int id)
        {
            try
            {
                using (context)
                {
                    var cust = context.Customer.Where(p => p.Status == false).FirstOrDefault(c => c.CustomerID == id);
                    if (cust != null)
                    {
                        cust.Status = true;
                        //context.Customer.Remove(cust);
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return false;
            }
        }

    }
}
