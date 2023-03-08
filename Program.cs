using System;
using System.Linq;

namespace CodingAssessment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /************************************************************************************************
             Step 1 : Fix all build errors in the project
             Step 2:  Find all Todo: comments in this console project and code to achieve desired effect.
            *************************************************************************************************/

            Console.WriteLine("Press any key to return all of the customer names (Last, First)");
            Console.ReadKey();

            //// get all customer names 
            foreach (var item in Services.CustomerService.GetAllCustomers())
                Console.WriteLine($", {item.CustomerID}, {item.LastName}, {item.FirstName}");

            Console.WriteLine("Press any key to list every other customer in the list");
            Console.ReadKey();
            // Todo:  Output the customers (ordered by Last Name, FirstName) but output only every other customer to screen.  i.e. skip every other name in the list.



            Console.WriteLine("Enter a name below to filter by name (last or first)");
            string nameFilterCriteria = Console.ReadLine();
            Console.WriteLine("Below are the results that match your search criteria");
            //  Todo: Output all customer names to the screen where the last name OR first name matches any part of the user entered search criteria.                    
            

                        
            Console.WriteLine("Press any key to list all the Active customers (do not list customers where the disabled flag is set)");
            Console.ReadKey();
            //// Todo: Add an optional property called Disabled to the Customer model.   
            //// Todo: Update the existing CustomerDataAccess.GetCustomerData() function so that Luke Skywalker and Fox Mulder show as Disabled in the returned data.
            //// Todo:   Update the CustomerService class and create a new function that only returns customers who are not Disabled.
            //// Todo:   Output all active(not disabled) customer names to the screen. One customer per line.  (Lastname, FirstName)                        


            Console.WriteLine("Press any key to list all the Active customers in the following format (LastName, FirstName, Age in Years)");
            Console.ReadKey();
            //// Todo: Output all active customers in the format above using the existing BirthDate property to calculate the customers age in years   


            Console.WriteLine("Press any key to list all the Active customers in the following format (LastName, FirstName, Age in Years, Probable Gender)");
            Console.ReadKey();
            //// Todo: Output all active customers in the format above.  Use the https://api.genderize.io API to guess the customer's gender based on their first name.  Refer to the api documentation here:  https://genderize.io

            Console.WriteLine("Press any key to end");
            Console.ReadLine();
        }
    }
}
