using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Mongo.Model
{
    public class Employee
    {
        public Employee()
        {
            
        }
        [BsonId]
        public string Id { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(120)]
        [JsonProperty("firstName")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(20)]
        [JsonProperty("lastName")]
        public string LastName { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [JsonProperty("birthDate")]
        public DateTime BirthDate { get; set; } = DateTime.Now;


        public string Email { get; set; } = string.Empty;


        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
