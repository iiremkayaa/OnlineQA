using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.OnlineQA.DataAccess.Concrete.EfCore.Mapping
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Description).HasColumnType("ntext");
            builder.Property(I => I.CommentDate).HasDefaultValueSql("getdate()");
        }
    }
}
