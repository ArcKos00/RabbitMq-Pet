using Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banking.Data.Configurations
{
    internal class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasData(new Account()
            {
                Id = 1,
                Money = 10,
                Status = "New"
            },
                new Account()
                {
                    Id = 2,
                    Money = 10,
                    Status = "Old"
                });
        }
    }
}
