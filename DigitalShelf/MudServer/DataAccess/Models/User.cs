using System.ComponentModel.DataAnnotations;

namespace MudServer.DataAccess.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string email { get; set; } = null!;
    }
}
