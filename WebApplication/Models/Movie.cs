using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    
    public class Movie
    {
        public int ID { get; set; }
        
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        
        [Required]
        [StringLength(24)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string Genre { get; set; }
        
        [Required]
        [Range(0, 1000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        
        [Required]
        [StringLength(16)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        public string Rating { get; set; }
        
    }
    
}