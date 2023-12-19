using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        void IEntityTypeConfiguration<Book>.Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasMany(b => b.Borrows)
                .WithOne(br => br.Book)
                .HasForeignKey(br => br.BookId);

            builder.Property(b => b.Id)
               .IsRequired()
               .UseIdentityColumn();

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(b => b.Author)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.GenreId)
                .IsRequired();

            builder.Property(b => b.PublishedYear)
                .IsRequired();
        }
    }
}
