using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAssessment.DataAccess
{
    internal static class CustomerDataAccess
    {
        /// <summary>
        /// Return some sample customer data
        /// </summary>
        /// <returns></returns>
        public static List<Model.Customer> GetCustomerData()
        {
            string modifiedByUser = "test.tester";
            DateTime modifiedDate = DateTime.Now;

            return new List<Model.Customer>() {
                new Model.Customer(){ CustomerID = 1, LastName = "Smith", MiddleName = "A.", FirstName="John", BillingID="01234",
                    BirthDate = Convert.ToDateTime("11/09/1960"), CommunityID=505, ModifyBy=modifiedByUser, ModifyDT = modifiedDate,
                   Disabled = false
                    },
                new Model.Customer(){ CustomerID = 1, LastName = "McAdams", MiddleName = "B.", FirstName="Amy", BillingID="56564",
                    BirthDate = Convert.ToDateTime("05/11/1977"), CommunityID=505, ModifyBy=modifiedByUser, ModifyDT = modifiedDate},
                new Model.Customer(){ CustomerID = 1, LastName = "Gonsales", MiddleName = "C.", FirstName="Jill", BillingID="03333",
                    BirthDate = Convert.ToDateTime("11/19/2001"), CommunityID=505, ModifyBy=modifiedByUser, ModifyDT = modifiedDate},
                new Model.Customer(){ CustomerID = 1, LastName = "Anderson", MiddleName = "D.", FirstName="Juan", BillingID="44456",
                    BirthDate = Convert.ToDateTime("02/24/1982"), CommunityID=505, ModifyBy=modifiedByUser, ModifyDT = modifiedDate},
                new Model.Customer(){ CustomerID = 1, LastName = "Mulder", MiddleName = "E.", FirstName="Fox", BillingID="2223",
                    BirthDate = Convert.ToDateTime("02/24/1982"), CommunityID=505, ModifyBy=modifiedByUser, ModifyDT = modifiedDate, Disabled = true},
                new Model.Customer(){ CustomerID = 1, LastName = "Skywalker", MiddleName = "F.", FirstName="Luke", BillingID="6565",
                    BirthDate = Convert.ToDateTime("02/24/1982"), CommunityID=505, ModifyBy=modifiedByUser, ModifyDT = modifiedDate, Disabled = true}
            };
        }
    }
}
