using CarDealershipAPI.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace CarDealershipAPI.Data.Configurations
{
    public class CarTypeConfiguration : IEntityTypeConfiguration<CarType>
    {
        public void Configure(EntityTypeBuilder<CarType> builder)
        {
            builder.HasKey(ct => ct.Id);
            builder.Property(ct => ct.Id).ValueGeneratedOnAdd();
            builder.Property(ct => ct.Model).IsRequired().HasMaxLength(50);
            builder.Property(ct => ct.Price).IsRequired().HasColumnType("decimal(18,2)");

            builder.HasOne<CarCategory>()
                   .WithMany(cc => cc.CarTypes)
                   .HasForeignKey(ct => ct.CarCategoryId);
        }
    }
}
