using LibraryMVC.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryMVC.EntityConfiguration;

public class BorrowingHistoryConfiguration : IEntityTypeConfiguration<BorrowingHistory>
{
    public void Configure(EntityTypeBuilder<BorrowingHistory> builder)
    {
        builder.HasKey(b => b.Id);
        // builder.Property(b => b.BorrowDate).IsRequired();
        // builder.Property(b => b.ReturnDate).IsRequired();
        builder.HasOne(b => b.Borrower).WithMany(b => b.BorrowingHistories).HasForeignKey(b => b.BorrowerId);
        builder.HasOne(b => b.LibraryItem).WithMany(b => b.BorrowingHistories).HasForeignKey(b => b.LibraryItemId);
    }
}