using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignmen2.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        // SellerId property for the seller (linked to ApplicationUser)
        public string SellerId { get; set; }

        // This property will store the path to the uploaded file in the database
        public string PhotoPath { get; set; }

        // This property is only used to handle the file upload and is not mapped to the database
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
