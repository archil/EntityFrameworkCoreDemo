using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.EntityTypeConfigurations
{
    public class CarEntityTypeConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder
                .HasKey(c => c.LicencePlateNumber);

            builder
                .Property(c => c.LicencePlateNumber)
                .IsRequired()
                .HasMaxLength(6)
                .HasColumnType("varchar(6)");
        }
    }
}
