
using AlternativaTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlternativaTest.Data.Maps
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).IsRequired();
            builder.HasMany(x => x.Products).WithOne(x => x.Category);
        
        }
    }
}