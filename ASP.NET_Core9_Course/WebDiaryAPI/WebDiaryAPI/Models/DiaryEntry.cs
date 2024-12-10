using System.ComponentModel.DataAnnotations;

namespace WebDiaryAPI.Models
{
    public class DiaryEntry
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
        [Required]
        public DateTime Created { get; set; } = DateTime.Today;
    }
}
