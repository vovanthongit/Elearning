using BELibrary.Entity;
using BELibrary.Utils;

namespace BELibrary.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BELibrary.Entity.ELearningDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BELibrary.Entity.ELearningDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var role = new Role
            {
                Id = RoleKey.Admin,
                Name = RoleKey.GetRole(RoleKey.Admin)
            };
            context.Roles.AddOrUpdate(c => c.Id, role);

            context.SaveChanges();
            var passwordFactory = VariableExtensions.DefautlPassword + VariableExtensions.KeyCryptor;
            var passwordCrypto = CryptorEngine.Encrypt(passwordFactory, true);
            context.Users.AddOrUpdate(c => c.Username, new User()
            {
                FullName = "Quản Trị",
                Phone = "0973 112 112",
                Username = "admin",
                Password = passwordCrypto,
                RoleId = role.Id,
                IsLocked = false,
                LinkAvata = "/FileUploads/images/28618678.png",
                DateOfBirth = new DateTime(1997, 01, 01),
                Status = true,
                Email = "uim89127@zzrgg.com"
            });
        }
    }
}