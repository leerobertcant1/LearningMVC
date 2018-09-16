namespace LearningMVC.Migrations
{
    using LearningMVC.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<LearningDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LearningDB context)
        {
            for(int i = 0; i < 50; i++)
            {
                context.People.AddOrUpdate(p=> p.FirstName, new Person
                   {
                       FirstName = $"Lee{i}",
                       LastName = $"Cant{i}",
                       MiddleName = $"Robert{i}",
                       Age = 30 + i,
                       Id = Guid.NewGuid()
                   });
            }

            //SeedMembership();
        }

        private void SeedMembership()
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "Users", "ID", "Username", true);

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }
            if (membership.GetUser("Lee", false) == null)
            {
                membership.CreateUserAndAccount("Lee", "123");
            }
            if (!roles.GetRolesForUser("Lee").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] {"Lee"}, new[] { "Admin"});
            }
        }
    }
}
