using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAssessment.Services
{
    internal static class CustomerService
    {
        public List<Model.Customer> GetAllCustomers()
        {
            var customers = DataAccess.CustomerDataAccess.GetCustomerData();
            return customers;            
        }
        
    }
}
