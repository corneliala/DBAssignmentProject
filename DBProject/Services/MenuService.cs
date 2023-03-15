
using DBProject.Models;

namespace DBProject.Services
{
    internal class MenuService
    {

        public async Task SubmitNewTicketAsync()
        {
            var customerTicket = new CustomerTicket();

            Console.Write("First name: ");
            customerTicket.FirstName = Console.ReadLine() ?? "";

            Console.Write("Last name: ");
            customerTicket.LastName = Console.ReadLine() ?? "";

            Console.Write("Email address: ");
            customerTicket.Email = Console.ReadLine() ?? "";

            Console.Write("Phone number : ");
            customerTicket.PhoneNumber = Console.ReadLine() ?? "";

            Console.Write("Describe your issue: ");
            customerTicket.Description = Console.ReadLine() ?? "";

            customerTicket.SubmittedTime = DateTime.Now;

            customerTicket.Status = "Pending";



            await CustomerService.SaveAsync(customerTicket);


        }

        public async Task ListAllContactsAsync()
        {
            //get all customers + addresses from database
            var customers = await CustomerService.GetAllAsync();

            if (customers.Any())
            {
                foreach (CustomerTicket customerTicket in customers)
                {
                    Console.WriteLine($"Customer ID: {customerTicket.Id}");
                    Console.WriteLine($"Name: {customerTicket.FirstName} {customerTicket.LastName}");
                    Console.WriteLine($"Email address: {customerTicket.Email}");
                    Console.WriteLine($"Phone number: {customerTicket.PhoneNumber}");
                    Console.WriteLine($"Ticket: {customerTicket.Description}, {customerTicket.SubmittedTime}, {customerTicket.Status}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No customer tickets found in the database.");
            }


        }
        public async Task ListSpecificContactAsync()
        {
            Console.Write("Write the email of the customer: ");
            var email = Console.ReadLine();

            if (!string.IsNullOrEmpty(email))
            {
                //get specific customer + address from database
                var customerTicket = await CustomerService.GetAsync(email);

                if (customerTicket != null)
                {
                    Console.WriteLine($"Customer ID: {customerTicket.Id}");
                    Console.WriteLine($"Name: {customerTicket.FirstName} {customerTicket.LastName}");
                    Console.WriteLine($"Email address: {customerTicket.Email}");
                    Console.WriteLine($"Phone number: {customerTicket.PhoneNumber}");
                    Console.WriteLine($"Ticket: {customerTicket.Description}, {customerTicket.SubmittedTime}, {customerTicket.Status}");
                    Console.WriteLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"No customer with the email address {email} was found.");
                }
            }
            else
            {
                Console.WriteLine("No email address submitted.");
            }
        }


        public async Task UpdateSpecificContactAsync()
        {
            Console.Write("Write the email of the customer: ");
            var email = Console.ReadLine();

            if (!string.IsNullOrEmpty(email))
            {
                var customer = await CustomerService.GetAsync(email);
                if (customer != null)
                {
                    Console.Clear();
                    Console.WriteLine("Set status as:");
                    Console.WriteLine("1. Pending ");
                    Console.WriteLine("2. In progress ");
                    Console.WriteLine("3. Completed. ");

                    string input = Console.ReadLine() ?? "";

                    switch (input)
                    {
                        case "1":
                            customer.Status = "Pending";
                            break;
                        case "2":
                            customer.Status = "In progress";
                            break;
                        case "3":
                            customer.Status = "Completed";
                            break;
                        default:
                            Console.WriteLine("Invalid input.");
                            return;
                    }

                    // update specific customer from database
                    await CustomerService.UpdateAsync(customer);

                    // update ticket status in database
                    var customerTicket = new CustomerTicket { Id = customer.Id, Status = customer.Status };
                    await CustomerService.UpdateAsync(customerTicket);
                }
                else
                {
                    Console.WriteLine($"No customer with the email address {email} was found.");
                    Console.WriteLine("");
                }

            }
            else
            {
                Console.WriteLine("No email address submitted.");
            }
        }




        public async Task DeleteSpecificContactAsync()
        {



            Console.Write("Write the email of the customer: ");
            var email = Console.ReadLine();

            if (!string.IsNullOrEmpty(email))
            {
                // delete specific customer from database
                await CustomerService.DeleteAsync(email);

            }
            else
            {
                Console.WriteLine("No email address submitted.");
            }
        }
    }

}

