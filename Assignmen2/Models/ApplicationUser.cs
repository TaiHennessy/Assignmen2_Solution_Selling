using Microsoft.AspNetCore.Identity;
using System;

namespace Assignmen2.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime? DateOfBirth { get; set; }  // Nullable to allow empty values
        public string City { get; set; }
        public string Country { get; set; }

        // Navigation property for the products this user is selling
        public ICollection<Product> Products { get; set; }

    }
}
