using CarsCompare.Database.Models.Identity;
using System;
using System.Data.Entity.Migrations;

namespace CarsCompare.Database.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EfUnitOfWork>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());

            SetHistoryContextFactory("MySql.Data.MySqlClient", (conn, schema) => new MySqlHistoryContext(conn, schema));
        }

        protected override void Seed(EfUnitOfWork context)
        {
            context.AspNetRoles.AddOrUpdate(
                r => r.Id,
                new AspNetRoles { Id = Guid.NewGuid().ToString(), Name = "Administrator" },
                new AspNetRoles { Id = Guid.NewGuid().ToString(), Name = "Viewer" }
            );
        }
    }
}