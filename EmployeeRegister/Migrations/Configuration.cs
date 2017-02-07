namespace EmployeeRegister.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeRegister.DataAccessLayer.EmployeesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EmployeeRegister.DataAccessLayer.EmployeesContext context)
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

            context.Employees.AddOrUpdate(e => e.Id,
               new Employee { Id = 1, FirstName = "Kalle", LastName = "Jan", Department = "IT", Position = "Developer", Salary = 31500 },
               new Employee { Id = 2, FirstName = "Karin", LastName = "Sten", Department = "IT", Position = "Developer", Salary = 30200 },
               new Employee { Id = 3, FirstName = "Bala", LastName = "Dan", Department = "Architect", Position = "Solution Architect", Salary = 43100 },
               new Employee { Id = 4, FirstName = "Tal", LastName = "Man", Department = "Project", Position = "Manager", Salary = 51780 },
               new Employee { Id = 5, FirstName = "Dildar", LastName = "Khan", Department = "Sport", Position = "Manager", Salary = 57780 },
               new Employee { Id = 6, FirstName = "Bilal", LastName = "Khan", Department = "Sport", Position = "Trainer", Salary = 41780 });
        }
    }
}
