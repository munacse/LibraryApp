using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.DataAccess.Model
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Use 5-20 characters")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Not valid email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Use 8-20 characters")]
        public string Phone { get; set; }

        public string Address { get; set; }

        //Relation
        public ICollection<Book> Books { get; set; }

    }
}
