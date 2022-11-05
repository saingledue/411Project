using System.ComponentModel.DataAnnotations;

namespace MudServer.ViewModels
{
    public class UserView
    {
        [Key]
        public int Id { get; set; }
        public string email { get; set; } = null!;
    }
}
