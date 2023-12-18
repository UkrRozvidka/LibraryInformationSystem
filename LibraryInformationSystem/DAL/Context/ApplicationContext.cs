using LibraryInformationSystem.LibraryInformationSystem.DAL.Context.Config;
using LibraryInformationSystem.LibraryInformationSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryInformationSystem.LibraryInformationSystem.DAL.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public ApplicationContext() {}
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
             : base(options)
        {
            Users = Set<User>();
            Borrows = Set<Borrow>();
            Books = Set<Book>();
            Status = Set<Status>();
            Genres = Set<Genre>();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(BookConfig).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
