using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasData(
                new AppUser
                {
                    Id = SeedIds.UserId1, DisplayName = "Bob", UserName = "bob",
                    NormalizedUserName = "BOB", NormalizedEmail = "BOB@TEST.COM",
                    Email = "bob@test.com",
                    PasswordHash =
                        "AQAAAAEAACcQAAAAEAy90BXaaDIxJm+9G2FiuKBNmjnGr4/syBRu/GTPuAZ2DbIAWNb1kl2VzC4PfBDJkA==",
                    ConcurrencyStamp = "5c1cbe50-290a-464b-b32d-60981bea1877",
                    SecurityStamp = "92657c22-f297-41da-984a-8deb392f5540"
                },
                new AppUser
                {
                    Id = SeedIds.UserId2, DisplayName = "Tom", UserName = "tom",
                    NormalizedUserName = "TOM", NormalizedEmail = "TOM@TEST.COM",
                    Email = "tom@test.com",
                    PasswordHash =
                        "AQAAAAEAACcQAAAAEAy90BXaaDIxJm+9G2FiuKBNmjnGr4/syBRu/GTPuAZ2DbIAWNb1kl2VzC4PfBDJkA==",
                    ConcurrencyStamp = "c01f9e4a-5935-43aa-a137-1cf23c8c499e",
                    SecurityStamp = "b88d0d77-d0c7-41b1-adf0-fa43d13028db"
                },
                new AppUser
                {
                    Id = SeedIds.UserId3, DisplayName = "Jane", UserName = "jane",
                    NormalizedUserName = "JANE", NormalizedEmail = "JANE@TEST.COM",
                    Email = "jane@test.com",
                    PasswordHash =
                        "AQAAAAEAACcQAAAAEAy90BXaaDIxJm+9G2FiuKBNmjnGr4/syBRu/GTPuAZ2DbIAWNb1kl2VzC4PfBDJkA==",
                    ConcurrencyStamp = "1abc3ae0-c563-4af0-aaee-bb7d6c1a0258",
                    SecurityStamp = "87f7b445-3fa1-497f-924c-39b0f2370947"
                });
        }
    }
}
