using MongoDB.Bson.Serialization.Attributes;
using System;

namespace LibraryApp.Mongo.Model
{
    public class Product
    {
        [BsonId]
        public string Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string CompanyName { get; set; } = string.Empty;

        public int Price { get; set; } = 0;

        public DateTime EntryDate { get; set; } = DateTime.Now;
    }
}
