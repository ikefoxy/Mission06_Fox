using System.ComponentModel.DataAnnotations;

namespace Mission06_Fox.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        // Foreign key to Categories table (optional in DB)
        public int? CategoryId { get; set; }

        // Required in Mission 7 DB
        [Required]
        public string Title { get; set; } = string.Empty;

        // Mission 7: required + year cannot be earlier than 1888
        [Required]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
        public int Year { get; set; }

        // Optional in DB
        public string? Director { get; set; }

        // Optional in DB
        public string? Rating { get; set; }

        // Mission 7: must be explicitly selected (Yes/No)
        [Required(ErrorMessage = "Please select whether the movie was edited.")]
        public bool? Edited { get; set; }

        // Optional in DB
        public string? LentTo { get; set; }

        // Mission 7: must be explicitly selected (Yes/No)
        [Required(ErrorMessage = "Please select whether the movie was copied to Plex.")]
        public bool? CopiedToPlex { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}