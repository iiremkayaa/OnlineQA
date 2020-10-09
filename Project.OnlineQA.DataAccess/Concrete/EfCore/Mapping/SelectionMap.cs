using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.OnlineQA.DataAccess.Concrete.EfCore.Mapping
{
    public class SelectionMap : IEntityTypeConfiguration<Selection>
    {
        public void Configure(EntityTypeBuilder<Selection> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Description).HasColumnType("ntext");
            builder.Property(I => I.NumberOfSelection).HasDefaultValue(0);
            builder.HasMany(I => I.UserSelections).WithOne(I => I.Selection).HasForeignKey(I => I.SelectionId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
