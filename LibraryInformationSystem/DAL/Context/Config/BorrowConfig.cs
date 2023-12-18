using LibraryInformationSystem.LibraryInformationSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryInformationSystem.LibraryInformationSystem.DAL.Context.Config
{
    public class BorrowConfig : IEntityTypeConfiguration<Borrow>
    {
        void IEntityTypeConfiguration<Borrow>.Configure(EntityTypeBuilder<Borrow> builder)
        {
            builder.Property(br => br.Id)
               .IsRequired()
               .UseIdentityColumn();

            builder.Property(br => br.UserId)
               .IsRequired();

            builder.Property(br => br.BookId)
               .IsRequired();

            builder.Property(br => br.StatusId)
                .IsRequired();
        }
    }
}
