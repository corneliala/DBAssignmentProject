using System.ComponentModel.DataAnnotations;

namespace DBProject.Models.Entities
{
    internal class TicketEntity
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public DateTime SubmittedTime { get; set; }

        [StringLength(15)]
        public string Status { get; set; } = null!;


        public ICollection<CustomerEntity> Customers = new HashSet<CustomerEntity>();
    }


}
