using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.OnlineQA.DataAccess.Concrete.EfCore.Mapping
{
    public class UserSelectionMap : IEntityTypeConfiguration<UserSelection>
    {
        public void Configure(EntityTypeBuilder<UserSelection> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.HasIndex(I => new { I.UserId, I.SelectionId }).IsUnique();
            builder.HasOne(I => I.User).WithMany(I => I.UserSelections).HasForeignKey(I => I.UserId);
            builder.HasOne(I => I.Selection).WithMany(I => I.UserSelections).HasForeignKey(I => I.SelectionId);
        }
    }
}
