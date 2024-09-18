using Assignmen2.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace Assignmen2.Data
{
    public class SeedUsersRoles
    {
        private readonly List<IdentityRole> _roles;
        private readonly List<ApplicationUser> _users;
        private readonly List<IdentityUserRole<string>> _userRoles;

        public SeedUsersRoles()
        {
            _roles = GetRoles();
            _users = GetUsers(); // Fetch the users
            _userRoles = GetUserRoles(_users, _roles); // Fetch user roles
        }

        // Method to assign roles to users
        private List<IdentityUserRole<string>> GetUserRoles(List<ApplicationUser> users, List<IdentityRole> roles)
        {
            var userRoles = new List<IdentityUserRole<string>>();

            var adminUser = users.FirstOrDefault(u => u.Email == "admin@example.com");
            var memberUser = users.FirstOrDefault(u => u.Email == "member@example.com");

            var adminRole = roles.FirstOrDefault(r => r.Name == "Admin");
            var memberRole = roles.FirstOrDefault(r => r.Name == "Member");

            if (adminUser != null && adminRole != null)
            {
                userRoles.Add(new IdentityUserRole<string>
                {
                    UserId = adminUser.Id,
                    RoleId = adminRole.Id
                });
            }

            if (memberUser != null && memberRole != null)
            {
                userRoles.Add(new IdentityUserRole<string>
                {
                    UserId = memberUser.Id,
                    RoleId = memberRole.Id
                });
            }

            return userRoles;
        }

        public List<IdentityRole> Roles { get { return _roles; } }
        public List<ApplicationUser> Users { get { return _users; } }
        public List<IdentityUserRole<string>> UserRoles { get { return _userRoles; } }

        // Method to get roles - generic and extendable
        private List<IdentityRole> GetRoles()
        {
            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "Member", NormalizedName = "MEMBER" }
            };

            return roles;
        }

        // Method to get users - generic for extensibility
        private List<ApplicationUser> GetUsers()
        {
            string defaultPassword = "P@$$w0rd"; // Default password for all seeded users
            var passwordHasher = new PasswordHasher<ApplicationUser>();

            List<ApplicationUser> users = new List<ApplicationUser>()
            {
                new ApplicationUser
                {
                    Id = "1",
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    EmailConfirmed = true,
                    NormalizedUserName = "ADMIN@EXAMPLE.COM",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    PasswordHash = passwordHasher.HashPassword(null, defaultPassword),
                    DateOfBirth = new DateTime(1990, 1, 1),
                    City = "Calgary",
                    Country = "Canada"
                },
                new ApplicationUser
                {
                    Id = "2",
                    UserName = "member@example.com",
                    Email = "member@example.com",
                    EmailConfirmed = true,
                    NormalizedUserName = "MEMBER@EXAMPLE.COM",
                    NormalizedEmail = "MEMBER@EXAMPLE.COM",
                    PasswordHash = passwordHasher.HashPassword(null, defaultPassword),
                    DateOfBirth = new DateTime(1991, 4, 5),
                    City = "London",
                    Country = "England"
                },
                new ApplicationUser
                {
                    Id = "3",
                    UserName = "Helper@man.com",
                    Email = "Helper@man.com",
                    EmailConfirmed = true,
                    NormalizedUserName = "Helper@man.com",
                    NormalizedEmail = "Helper@man.com",
                    PasswordHash = passwordHasher.HashPassword(null, defaultPassword),
                    DateOfBirth = new DateTime(1991, 4, 5),
                    City = "London",
                    Country = "England"
                }
            };

            return users;
        }
    }
}
