using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.DataAccess.Model
{
    public class BookCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Use 3-20 characters")]
        public string Name { get; set; }

        //Relation
        public ICollection<Book> Books { get; set; }
    }
}
