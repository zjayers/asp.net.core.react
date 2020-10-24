using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<AppUser>();
            var hash = hasher.HashPassword(null, "Pa$$w0rd");

            builder.HasData(
                new AppUser()
                {
                    Id = "233683EE-CD2D-4B0D-97CD-34715E6D5BDF", DisplayName = "Bob", UserName = "bob",
                    NormalizedUserName = "BOB", NormalizedEmail = "BOB@TEST.COM",
                    Email = "bob@test.com", PasswordHash = hash
                },
                new AppUser()
                {
                    Id = "EC50E466-AE94-4D0A-BAAD-831A41191223", DisplayName = "Tom", UserName = "tom",
                    NormalizedUserName = "TOM", NormalizedEmail = "TOM@TEST.COM",
                    Email = "tom@test.com", PasswordHash = hash
                },
                new AppUser()
                {
                    Id = "DEB85499-584C-49C1-8DC4-765838874650", DisplayName = "Jane", UserName = "jane",
                    NormalizedUserName = "JANE", NormalizedEmail = "JANE@TEST.COM",
                    Email = "jane@test.com", PasswordHash = hash
                });
        }
    }
}
