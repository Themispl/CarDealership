using CarDealershipAPI.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace CarDealershipAPI.Data.Configurations
{
    public class CarCategoryConfiguration : IEntityTypeConfiguration<CarCategory>
    {
        public void Configure(EntityTypeBuilder<CarCategory> builder)
        {
            builder.HasKey(cc => cc.Id);
            builder.Property(cc => cc.Id).ValueGeneratedOnAdd();
            builder.Property(cc => cc.FuelCategory).IsRequired().HasMaxLength(50);
            builder.Property(cc => cc.Manufacturer).IsRequired().HasMaxLength(50);

            builder.HasMany(cc => cc.CarTypes)
                   .WithOne()
                   .HasForeignKey(ct => ct.CarCategoryId);
        }
    }   
}
