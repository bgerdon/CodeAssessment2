using CodingAssessment.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
            var GetAllCustomersInstance = new Services.CustomerService();
            foreach (var item in GetAllCustomersInstance.GetAllCustomers())
            {
                Console.WriteLine($" {item.LastName}, {item.FirstName}");
            }



            // Todo:  Output the customers (ordered by Last Name, FirstName) but output only every other customer to screen.  i.e. skip every other name in the list.
            Console.WriteLine("Press any key to list every other customer in the list");
            Console.ReadKey();
            foreach (var item in GetAllCustomersInstance.GetAllCustomers().Where((v, i) => i % 2 == 0))
            {
                Console.WriteLine($" {item.LastName}, {item.FirstName}");
            }
          
            Console.ReadKey();



            //  Todo: Output all customer names to the screen where the last name OR first name matches any part of the user entered search criteria.                    
            Console.WriteLine("Enter a name below to filter by name (last or first)");
            string nameFilterCriteria = Console.ReadLine();

            Console.WriteLine("Below are the results that match your search criteria");
            var customerSearchQuery = GetAllCustomersInstance.GetAllCustomers().Where(x => x.FirstName.Contains(nameFilterCriteria) || x.LastName.Contains(nameFilterCriteria)).FirstOrDefault();
            //from customer in GetAllCustomersInstance.GetAllCustomers().Where(x => x.FirstName.Contains(nameFilterCriteria) || x.LastName.Contains(nameFilterCriteria)).FirstOrDefault();
              //  where customer.FirstName.Contains(nameFilterCriteria) || customer.LastName.Contains(nameFilterCriteria)
               // select customer;
               if (customerSearchQuery != null)
            {
                Console.WriteLine($"{customerSearchQuery.LastName}, {customerSearchQuery.FirstName}");
            }
          
            // above returns the variable type...need to make sure it prints the desired elements of the variable ie the iterated/filtered customers


            //// Todo: Add an optional property called Disabled to the Customer model.   
            //// Todo: Update the existing CustomerDataAccess.GetCustomerData() function so that Luke Skywalker and Fox Mulder show as Disabled in the returned data.
            //// Todo:   Update the CustomerService class and create a new function that only returns customers who are not Disabled.
            //// Todo:   Output all active(not disabled) customer names to the screen. One customer per line.  (Lastname, FirstName) 
           
            Console.WriteLine("Press any key to list all the Active customers (do not list customers where the disabled flag is set)");
            Console.ReadKey();
            var GetActiveCustomersInstance = new Services.CustomerService();
            foreach (var customer in GetActiveCustomersInstance.GetActiveCustomers())
            {
                Console.WriteLine($"{customer.LastName}, {customer.FirstName}");
            }
                       

            //// Todo: Output all active customers in the format above using the existing BirthDate property to calculate the customers age in years   

            Console.WriteLine("Press any key to list all the Active customers in the following format (LastName, FirstName, Age in Years)");
            Console.ReadKey();
            var GetActiveCustomersAgeInstance = new Services.CustomerService();
            foreach (var customer in GetActiveCustomersAgeInstance.GetActiveCustomers())
            {
                var birthday = customer.BirthDate;
                var customerAge = DateTime.Now.Year - birthday.Value.Year;
                Console.WriteLine($"{customer.LastName}, {customer.FirstName}, {customerAge}");
            }

            //// Todo: Output all active customers in the format above.  Use the https://api.genderize.io API to guess the customer's gender based on their first name.  Refer to the api documentation here:  https://genderize.io

            Console.WriteLine("Press any key to list all the Active customers in the following format (LastName, FirstName, Age in Years, Probable Gender)");
            Console.ReadKey();

            var httpClient = new HttpClient();



            GetAsync(httpClient);
 

            Console.WriteLine("Press any key to end");
            Console.ReadLine();
        }

        static async Task GetAsync(HttpClient httpClient)
        {
        var GetActiveCustomersGenderInstance = new Services.CustomerService();

            foreach (var customer in GetActiveCustomersGenderInstance.GetActiveCustomers())
            {
                var birthday = customer.BirthDate;
                var customerAge = DateTime.Now.Year - birthday.Value.Year;


                using HttpResponseMessage response = await httpClient.GetAsync("https://api.genderize.io?name=" + customer.FirstName);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<GenderizeData>(json);

                //    var gender = await httpClient.GetFromJsonAsync //want to retrieve the value of gender from the json object

                Console.WriteLine($"{customer.LastName}, {customer.FirstName}, {customerAge}, {data.Gender}");

            }
        }
    }
    class GenderizeData
    {
        public string Name { get; set; }

        public string Gender { get; set; }

        public string Count { get; set; }

        public string Probability { get; set; }
    }
}
