using System;
using LawInOrderApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LawInOrderApp.Infra.Data.Mapping
{
    public class TimeSheetMap :
    IEntityTypeConfiguration<TimeSheet>
    {
        public void Configure(EntityTypeBuilder<TimeSheet> builder)
        {
            builder.ToTable("TimeSheet");

            builder.Property(t => t.Id)
                   .HasColumnName("TimeSheetId");

            builder.Property(t => t.HourWorked)
                   .HasColumnType("int")
                   .IsRequired();

            builder.Property(t => t.DateWorked)
                   .HasColumnType("datetime")
                   .IsRequired()
                   .HasDefaultValue(DateTime.Now);

            builder.Property(t => t.UserId)
                   .HasColumnType("uniqueidentifier")
                   .IsRequired();
        }
    }
}
