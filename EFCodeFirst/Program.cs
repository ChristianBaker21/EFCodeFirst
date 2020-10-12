using System;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;

namespace EFCodeFirst
{
    public class Program
    {
        static void Main(string[] args)
        {
            var _context = new AppDBContext();

            var cust = new Customer()
            {
                Name = "MAX Technical Training",
                Code = "MAX4",
                Active = true,
                Sales = 1000,
                Created = DateTime.Now
            };
            _context.Customers.Add(cust);
            _context.SaveChanges();

            var custs = _context.Customers.ToList();
            foreach(var c in custs)
            {
                Console.WriteLine($"{c.Id}|{c.Name}|{c.Code}|{c.Active}|{c.Sales}|{c.Created}");
            }

            var ord = new Order()
            {
                Description = "First order",
                Total = 1000,
                Created = DateTime.Now,
                CustomerId = 3
            };

            _context.Orders.Add(ord);
            _context.SaveChanges();

            var order = _context.Orders.Find(1);

            Console.WriteLine($"{order.Id}|{order.Description}|{order.Total}|{order.Created}");

            var OrdLine = new OrderLine()
            {
                Product = "Echo",
                Price = 100,
                Quantity = 3,
                OrderId = 1
            };

            _context.Orderline.Add(OrdLine);

            _context.SaveChanges();

            var ordAll = from o in _context.Orders
                         join c in _context.Customers
                         on o.CustomerId equals c.Id
                         join l in _context.Orderline
                         on o.Id equals l.OrderId
                         select new
                         {
                             OrderId = o.Id,
                             Desc = o.Description,
                             Customer = c.Name,
                             l.Product,
                             l.Price,
                             l.Quantity,
                             LineTotal = l.Price * l.Quantity
                         };


        }
    }
}
