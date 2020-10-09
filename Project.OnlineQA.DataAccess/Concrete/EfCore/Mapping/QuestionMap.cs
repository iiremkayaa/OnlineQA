using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.OnlineQA.DataAccess.Concrete.EfCore.Mapping
{
    public class QuestionMap : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Description).HasColumnType("ntext");
            builder.HasMany(I => I.Selections).WithOne(I => I.Question).HasForeignKey(I => I.QuestionId);
            builder.HasMany(I => I.Comments).WithOne(I => I.Question).HasForeignKey(I => I.QuestionId);
            builder.Property(I => I.PostedTime).HasDefaultValueSql("getdate()");

        }
    }
}
