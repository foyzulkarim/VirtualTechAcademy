using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ZooApp.MvcClient.Models;

namespace ZooApp.MvcClient.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ZooApp.MvcClient.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            AddRoles(context);
            AddUsers(context);

        }

        private void AddUsers(ApplicationDbContext dbContext)
        {
            string email = "foyzulkarim@gmail.com";
            ApplicationUser applicationUser = dbContext.Users.FirstOrDefault(x => x.Email == email);
            if (applicationUser==null)
            {
                var userId = Guid.NewGuid().ToString();
                IdentityRole identityRole = dbContext.Roles.First(x => x.Name == "Admin");
                IdentityUserRole userRole=new IdentityUserRole()
                {
                    UserId = userId, RoleId = identityRole.Id
                };
                PasswordHasher hasher=new PasswordHasher();
                string hashPassword = hasher.HashPassword("123456");
                applicationUser=new ApplicationUser()
                {
                    Email = email, UserName = email, Id = userId, Roles = { userRole }, PasswordHash = hashPassword
                };
                dbContext.Users.Add(applicationUser);
                dbContext.SaveChanges();
            }
        }

        private void AddRoles(ApplicationDbContext dbContext)
        {
            List<string> roles  = new List<string>() {"Admin","User"};
            foreach (string r in roles)
            {
                IdentityRole identityRole = dbContext.Roles.FirstOrDefault(x => x.Name == r);
                if (identityRole==null)
                {
                    identityRole =new IdentityRole(r);
                    dbContext.Roles.Add(identityRole);
                }
            }
            dbContext.SaveChanges();
        }
    }
}
