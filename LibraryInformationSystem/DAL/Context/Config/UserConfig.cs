using LibraryInformationSystem.LibraryInformationSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryInformationSystem.LibraryInformationSystem.DAL.Context.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        void IEntityTypeConfiguration<User>.Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.Borrows)
                .WithOne(br => br.User)
                .HasForeignKey(br => br.UserId);

            builder.Property(u => u.Id)
                .IsRequired()
                .UseIdentityColumn();

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(u => u.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);     
        }
    }
}
