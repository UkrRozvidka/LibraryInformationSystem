using LibraryInformationSystem.LibraryInformationSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryInformationSystem.LibraryInformationSystem.DAL.Context.Config
{
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        void IEntityTypeConfiguration<Genre>.Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasMany(g => g.Books)
                .WithOne(b => b.Genre)
                .HasForeignKey(b => b.GenreId);

            builder.Property(g => g.Id)
               .IsRequired();

            builder.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(new Genre { Id = 1,  Name = "Action and adventure", Books = new List<Book>() },
                            new Genre { Id = 2,  Name = "Detective", Books = new List<Book>() },
                            new Genre { Id = 3,  Name = "Sci-fi", Books = new List<Book>() },
                            new Genre { Id = 4,  Name = "Historical fiction", Books = new List<Book>() },
                            new Genre { Id = 5,  Name = "Dystopia", Books = new List<Book>() },
                            new Genre { Id = 6,  Name = "Fantasy", Books = new List<Book>() },
                            new Genre { Id = 7,  Name = "Romance novel", Books = new List<Book>() },
                            new Genre { Id = 8,  Name = "Horror", Books = new List<Book>() },
                            new Genre { Id = 9,  Name = "Fairy tale", Books = new List<Book>() },
                            new Genre { Id = 10, Name = "Graphic novel", Books = new List<Book>() },
                            new Genre { Id = 11, Name = "Classic", Books = new List<Book>() },
                            new Genre { Id = 12, Name = "Non-fiction", Books = new List<Book>() });
        }
    }
}
