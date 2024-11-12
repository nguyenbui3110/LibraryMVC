using LibraryMVC.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryMVC.EntityConfiguration;

public class BorrowerConfiguration : IEntityTypeConfiguration<Borrower>
{
    public void Configure(EntityTypeBuilder<Borrower> builder)
    {
        builder.ToTable("Borrowers");
        builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
        // builder.Property(b => b.Address).IsRequired().HasMaxLength(200);
        builder.HasKey(b => b.Id);
    }
}