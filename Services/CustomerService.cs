using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CodingAssessment.Services
{
    internal class CustomerService
    {
        public List<Model.Customer> GetAllCustomers()
        {
            var customers = DataAccess.CustomerDataAccess.GetCustomerData();
            return customers;            
        }
        
        public List<Model.Customer> GetActiveCustomers()
        {
            var activeCustomers = 
                from customer in DataAccess.CustomerDataAccess.GetCustomerData()
                where customer.Disabled != true
                select customer;
            return activeCustomers.ToList();
        }

    }
}
