using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudServer.DataAccess.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Id")]
        public virtual int UserId { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public DateTime? DatePublished { get; set; }
        public string? Publisher { get; set; }
        public int PageLength { get; set; }
        public string? Description { get; set; }
        public string? ASIN { get; set; }
        public int Rating { get; set; }

        //foreign key to comments table or string array???
        public string? Comments { get; set; }
        public bool IsSeries { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsNotify { get; set; }
        public string? Genres { get; set; }
    }
}
