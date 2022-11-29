using System.ComponentModel.DataAnnotations;

namespace MudServer.ViewModels
{
    public class CustomerView
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please list an IP address")]
        public string? IP { get; set; }
        [Required(ErrorMessage = "Please list a city")]
        public string? City { get; set; }
        [Required(ErrorMessage = "Please list a state")]
        public string? State { get; set; }
        [Required(ErrorMessage = "Please select date last logged in")]
        public DateTime? LastLogin { get; set; }
        [Required(ErrorMessage = "Please enter a password")]
        public string? Password { get; set; }
    }
}
