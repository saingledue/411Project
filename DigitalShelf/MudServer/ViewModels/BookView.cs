using System.ComponentModel.DataAnnotations;

namespace MudServer.ViewModels
{
    public class BookView
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a title")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Please enter the author's name")]
        public string? Author { get; set; }
        //optional
        [Required(ErrorMessage = "Please select the publication date")]
        public DateTime? DatePublished { get; set; }
        //optional
        public string? Publisher { get; set; }
        //optional but 0 or greater
        [Range(0, int.MaxValue, ErrorMessage ="Page length must be 0 or greater")]
        public int PageLength { get; set; }
        //optional
        public string? Description { get; set; }
        //optional
        public string? ASIN { get; set; }
        //Required
        [Required(ErrorMessage = "Rating must be between 1 (low) and 5 (high)")]
        public int Rating { get; set; }
        //optional
        public string? Comments { get; set; }
        //optional
        public bool IsSeries { get; set; }
        //optional
        public bool IsFavorite { get; set; }
        //optional
        public bool IsNotify { get; set; }
        //required
        [Required (ErrorMessage = "You Must Select a Genre")]
        public string? Genres { get; set; }
    }
}
