using LibraryInformationSystem.LibraryInformationSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryInformationSystem.LibraryInformationSystem.DAL.Context.Config
{
    public class StatusConfig : IEntityTypeConfiguration<Status>
    {
        void IEntityTypeConfiguration<Status>.Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasMany(s => s.Borrows)
                .WithOne(br => br.Status)
                .HasForeignKey(br => br.StatusId);

            builder.Property(br => br.Id)
                .IsRequired();

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(new Status { Id = 1, Name = "Returned", Borrows = new List<Borrow>() },
                            new Status { Id = 2, Name = "Not returned yet", Borrows = new List<Borrow>() },
                            new Status { Id = 3, Name = "Lost", Borrows = new List<Borrow>() });

        }
    }
}
