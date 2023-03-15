using DBProject.Contexts;
using DBProject.Models;
using DBProject.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DBProject.Services;

internal class CustomerService
{
    private static DataContext _context = new DataContext();
    public static async Task SaveAsync(CustomerTicket customerTicket)
    {


        var customerEntity = new CustomerEntity
        {
            FirstName = customerTicket.FirstName,
            LastName = customerTicket.LastName,
            Email = customerTicket.Email,
            PhoneNumber = customerTicket.PhoneNumber
        };

        var ticketEntity = await _context.Tickets.FirstOrDefaultAsync(x => x.Description == customerTicket.Description && x.SubmittedTime == customerTicket.SubmittedTime && x.Status == customerTicket.Status);
        if (ticketEntity != null)

            customerEntity.TicketId = ticketEntity.Id;
        else
            customerEntity.Ticket = new TicketEntity
            {
                Description = customerTicket.Description,
                SubmittedTime = customerTicket.SubmittedTime,
                Status = customerTicket.Status
            };

        _context.Add(customerEntity);
        await _context.SaveChangesAsync();
        

    }

    public static async Task<IEnumerable<CustomerTicket>> GetAllAsync()
    { 
        var customers = new List<CustomerTicket>();
        foreach (var customer in await _context.Customers.Include(x => x.Ticket).ToListAsync())
            customers.Add(new CustomerTicket
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Description = customer.Ticket.Description,
                SubmittedTime = customer.Ticket.SubmittedTime,
                Status = customer.Ticket.Status
            });

        return customers;
    }

    public static async Task<CustomerTicket> GetAsync(string email)
    {
        var customer = await _context.Customers.Include(x => x.Ticket).FirstOrDefaultAsync(x => x.Email == email);
        if (customer != null)
            return new CustomerTicket
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Description = customer.Ticket.Description,
                SubmittedTime = customer.Ticket.SubmittedTime,
                Status = customer.Ticket.Status
            };
        else
            return null!;
    }

    public static async Task UpdateAsync(CustomerTicket customerTicket)
    {
        var customerEntity = await _context.Customers.Include(x => x.Ticket).FirstOrDefaultAsync(x => x.Id == customerTicket.Id);

        if (customerEntity != null)
        {
            if (customerTicket.Status != null && (customerTicket.Status == "Pending" || customerTicket.Status == "In progress" || customerTicket.Status == "Completed"))
            {
                if (customerEntity.Ticket == null)
                {
                    customerEntity.Ticket = new TicketEntity();
                }
                customerEntity.Ticket.Status = customerTicket.Status;
                _context.Update(customerEntity);
                await _context.SaveChangesAsync();
            }
        }
    }




    public static async Task DeleteAsync(string email)
    {
        var customer = await _context.Customers.Include(x => x.Ticket).FirstOrDefaultAsync(x => x.Email == email);
        if (customer != null)
        {
            _context.Remove(customer);
            await _context.SaveChangesAsync();
        }
            
    }

}
