using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models;

namespace Shop.Services
{
    public class ShopRepository : IShopRepository
    {
        private ShoopContext _shopContext;

        public ShopRepository(ShoopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public void AddCustomer(Customer customer)
        {
            _shopContext.Customer.Add(customer);
        }

        public void AddOrder(Orders order)
        {
            _shopContext.Orders.Add(order);
        }

        public void DeleteCustomer(int id)
        {
            var customerForDelete = GetCustomer(id);
            _shopContext.Remove(customerForDelete);
        }

        public void DeleteOrder(int id)
        {
            var orderForDelete = GetOrder(id);
            _shopContext.Remove(orderForDelete);
        }

        public void DeleteOrder(Orders order)
        {
            throw new NotImplementedException();
        }

        public bool ExistCustomer(int id)
        {
            return _shopContext.Customer.Any(c => c.CustomerId == id);
        }

        public bool ExistOrder(int id)
        {
            return _shopContext.Orders.Any(o => o.OrderId == id);
        }

        public Customer GetCustomer(int id)
        {
            return _shopContext.Customer.FirstOrDefault(customer => customer.CustomerId == id);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _shopContext.Customer.OrderBy(a => a.LastName).ThenBy(a => a.FirstName);
        }

        public Orders GetOrder(int id)
        {
            return _shopContext.Orders.FirstOrDefault(order => order.OrderId == id);
        }

        public IEnumerable<Orders> GetOrders()
        {
            return _shopContext.Orders.OrderBy(a => a.OrderDate);
        }

        public bool Save()
        {
            return _shopContext.SaveChanges() >= 0;
        }

        public void UpdateCustomer(Customer customer,int id)
        {
            var updateCustomer = GetCustomer(id);

            updateCustomer.FirstName = customer.FirstName;
            updateCustomer.LastName = customer.LastName;
            updateCustomer.Phone = customer.Phone;

            _shopContext.Update(updateCustomer);
        }

        public void UpdateOrder(int id)
        {
            // throw new NotImplementedException();
        }
    }
}
