using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.DataAccess.Model
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Use 5-20 characters")]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int Page { get; set; }

        //Relation
        public Author Author { get; set; }

        public BookCategory BookCategory { get; set; }
    }
}
