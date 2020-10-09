using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.OnlineQA.DataAccess.Concrete.EfCore.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Name).HasMaxLength(100);
            builder.Property(I => I.LastName).HasMaxLength(100);
            builder.Property(I => I.Email).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Email).HasMaxLength(100).IsRequired();
            builder.HasMany(I => I.Questions).WithOne(I => I.User).HasForeignKey(I => I.UserId);
            builder.HasMany(I => I.Comments).WithOne(I => I.User).HasForeignKey(I => I.UserId);
            builder.HasMany(I => I.UserSelections).WithOne(I => I.User).HasForeignKey(I => I.UserId);
        }
    }
}
