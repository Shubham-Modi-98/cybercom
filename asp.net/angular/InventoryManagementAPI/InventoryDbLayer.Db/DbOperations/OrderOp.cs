using InventoryDbLayer.Db.Models;
using LinqToDB.SqlQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDbLayer.Db.DbOperations
{
    public class OrderOp
    {
        InventoryManagementEntities context = null;
        public OrderOp()
        {
            context = new InventoryManagementEntities();
        }

        public int GetOrderCounts(string fromDate="", string toDate="")
        {
            try
            {
                if (fromDate != null && toDate != null && fromDate != "" && toDate != "")
                {
                    DateTime from = Convert.ToDateTime(fromDate);
                    DateTime to = Convert.ToDateTime(toDate);
                    using (context)
                    {
                        int orderCount = context.Orders.Where(o => o.Status == false
                        && o.OrderDate >= from && o.OrderDate <= to).Count();
                        if (orderCount > 0)
                            return orderCount;
                        else
                            return 0;
                    }
                }
                else
                {
                    using (context)
                    {
                        int orderCount = context.Orders.Where(o => o.Status == false).Count();
                        if (orderCount > 0)
                            return orderCount;
                        else
                            return 0;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return 0;
            }
        }

        public List<OrderIms> GetOrdersAsc(int recordSkip = 0, int recordTake = 5, string fromDate ="", string toDate = "")
        {
            try
            {
                using (context)
                {
                    if ((fromDate == "" && toDate == "") || (fromDate == null && toDate == null))
                    {
                        var orderList = context.Orders.Where(o => o.Status == false).Select(o => new OrderIms()
                        {
                            OrderID = o.OrderID,
                            OrderType = new OrderTypeIms
                            {
                                Name = o.OrderType.Name,
                            },
                            OrderDate = o.OrderDate,
                            Customer = new CustomerIms
                            {
                                Name = o.Customer.Name,
                            },
                            Product = new ProductIms
                            {
                                Name = o.Product.Name,
                            },
                            Quantity = o.Quantity,
                            TotalPrice = o.TotalPrice,
                        }).OrderBy(o => o.OrderDate).Skip(recordSkip).Take(recordTake).ToList();
                        if (orderList != null)
                            return orderList;
                        else
                            return null;
                    }
                    else
                    {
                        DateTime from = Convert.ToDateTime(fromDate);
                        DateTime to = Convert.ToDateTime(toDate);
                        var orderFilterList = context.Orders.Where(o => o.Status == false
                        && o.OrderDate >= from && o.OrderDate <= to).Select(o => new OrderIms()
                        {
                            OrderID = o.OrderID,
                            OrderType = new OrderTypeIms
                            {
                                Name = o.OrderType.Name,
                            },
                            OrderDate = o.OrderDate,
                            Customer = new CustomerIms
                            {
                                Name = o.Customer.Name,
                            },
                            Product = new ProductIms
                            {
                                Name = o.Product.Name,
                            },
                            Quantity = o.Quantity,
                            TotalPrice = o.TotalPrice,
                        }).OrderBy(o => o.OrderDate).Skip(recordSkip).Take(recordTake).ToList();
                        if (orderFilterList.Count != 0)
                            return orderFilterList;
                        else
                            return null;

                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
            }
        }

        public List<OrderIms> GetOrders(int recordSkip = 0, int recordTake = 5, string fromDate = "", string toDate = "")
        {
            try
            {
                if ((fromDate == "" && toDate == "") || (fromDate == null && toDate == null))
                {
                    using (context)
                    {
                        var orderList = context.Orders.Where(o => o.Status == false).Select(o => new OrderIms()
                        {
                            OrderID = o.OrderID,
                            OrderType = new OrderTypeIms
                            {
                                Name = o.OrderType.Name,
                            },
                            OrderDate = o.OrderDate,
                            Customer = new CustomerIms
                            {
                                Name = o.Customer.Name,
                            },
                            Product = new ProductIms
                            {
                                Name = o.Product.Name,
                            },
                            Quantity = o.Quantity,
                            TotalPrice = o.TotalPrice,
                        }).OrderByDescending(o => o.OrderDate).Skip(recordSkip).Take(recordTake).ToList();
                        if (orderList != null)
                            return orderList;
                        else
                            return null;
                    }
                }
                else
                {
                    DateTime from = Convert.ToDateTime(fromDate);
                    DateTime to = Convert.ToDateTime(toDate);
                    using (context)
                    {
                        var orderFilterList = context.Orders.Where(o => o.Status == false
                        && o.OrderDate >= from && o.OrderDate <= to).Select(o => new OrderIms()
                        {
                            OrderID = o.OrderID,
                            OrderType = new OrderTypeIms
                            {
                                Name = o.OrderType.Name,
                            },
                            OrderDate = o.OrderDate,
                            Customer = new CustomerIms
                            {
                                Name = o.Customer.Name,
                            },
                            Product = new ProductIms
                            {
                                Name = o.Product.Name,
                            },
                            Quantity = o.Quantity,
                            TotalPrice = o.TotalPrice,
                        }).OrderByDescending(o => o.OrderDate).Skip(recordSkip).Take(recordTake).ToList();
                        if (orderFilterList.Count != 0)
                            return orderFilterList;
                        else
                            return null;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
            }
        }

        public int GetTodaysOrders()
        {
            try
            {
                var tDate = DateTime.Now.ToShortDateString();
                var todayDate = Convert.ToDateTime(tDate);
                using (context)
                {
                    var todayOrderCount = context.Orders
                        .Where(o => o.Status == false && o.OrderDate == todayDate).Count();
                    if (todayOrderCount > 0)
                        return todayOrderCount;
                    else
                        return 0;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return -1;
            }
        }

        //public List<OrderIms> GetFilteredOrders(DateTime fromDate, DateTime toDate)
        //{
        //    try
        //    {
        //        using (context)
        //        {
        //            var orderList = context.Orders.Where(o => o.Status == false
        //                && o.OrderDate >= fromDate && o.OrderDate <= toDate).Select(o => new OrderIms()
        //                {
        //                    OrderID = o.OrderID,
        //                    OrderType = new OrderTypeIms
        //                    {
        //                        Name = o.OrderType.Name,
        //                    },
        //                    OrderDate = o.OrderDate,
        //                    Customer = new CustomerIms
        //                    {
        //                        Name = o.Customer.Name,
        //                    },
        //                    Product = new ProductIms
        //                    {
        //                        Name = o.Product.Name,
        //                    },
        //                    Quantity = o.Quantity,
        //                    TotalPrice = o.TotalPrice,
        //                }).OrderByDescending(o => o.OrderDate).ToList();
        //            if (orderList.Count != 0)
        //                return orderList;
        //            else
        //                return null;
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        Console.WriteLine(exception);
        //        return null;
        //    }
        //}
    }
}
