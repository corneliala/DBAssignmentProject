using DBProject.Services;

var menu = new MenuService();

while (true)
{
    Console.Clear();
    Console.WriteLine("1. Submit a ticket");
    Console.WriteLine("2. Show all tickets");
    Console.WriteLine("3. Show a specific ticket");
    Console.WriteLine("4. Update the status of a ticket ");
    Console.WriteLine("5. Remove a ticket");
    Console.Write("Pick one of the choices (1-5): ");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Clear();
            await menu.SubmitNewTicketAsync();
            break;

        case "2":
            Console.Clear();
            await menu.ListAllTicketsAsync();
            break;

        case "3":
            Console.Clear();
            await menu.ListSpecificTicketAsync();
            break;

        case "4":
            Console.Clear();
            await menu.UpdateSpecificTicketAsync();
            break;

        case "5":
            Console.Clear();
            await menu.DeleteSpecificTicketAsync();
            break;

    }

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}
