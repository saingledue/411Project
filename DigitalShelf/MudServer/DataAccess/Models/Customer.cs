using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudServer.DataAccess.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string? IP { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public DateTime? LastLogin { get; set; }
        public string? Password { get; set; }
    }
}
