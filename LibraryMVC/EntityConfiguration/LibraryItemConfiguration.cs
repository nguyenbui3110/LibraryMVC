using LibraryMVC.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryMVC.EntityConfiguration;

public class LibraryItemConfiguration : IEntityTypeConfiguration<LibraryItem>
{
    public void Configure(EntityTypeBuilder<LibraryItem> builder)
    {
        builder.HasKey(item => item.Id);
        builder.Property(item => item.Title).IsRequired().HasMaxLength(50);
        builder.Property(item => item.Author).IsRequired().HasMaxLength(50);
        builder.Property(item => item.PublicationDate).IsRequired();
        builder.HasDiscriminator<string>("ItemType") // Phân biệt các loại item
            .HasValue<Book>("Book")
            .HasValue<Dvd>("DVD")
            .HasValue<Magazine>("Magazine");
    }
}