using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Services
{
    public interface IShopRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(int id);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer,int id);
        void DeleteCustomer(int id);
        bool ExistCustomer(int id);
        IEnumerable<Orders> GetOrders();
        Orders GetOrder(int id);
        void AddOrder(Orders order);
        void UpdateOrder(int id);
        void DeleteOrder(Orders order);
        bool ExistOrder(int id);
        bool Save();
    }
}
