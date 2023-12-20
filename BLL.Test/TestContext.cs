using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Test
{
    public class TestContext
    {
        public List<User> Users { get; set; }
        public List<Book> Books { get; set; }
        public List<Borrow> Borrows { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Status> Statuses { get; set; }

        public TestContext() 
        {
            Users = new List<User>{
                new User { Id = 1, Name = "testName" },
                new User { Id = 2, Name = "testName2" },
                new User { Id = 3, Name = "testName3" }};

            Books = new List<Book>
            {
                new Book { Id = 1, Title = "test", GenreId = 1, Count =10, Author = "test"},
                new Book { Id = 2, Title = "test1", GenreId = 2, Count =10, Author = "test"},
                new Book { Id = 3, Title = "test2", GenreId = 3, Count =10, Author = "test"}
            };

            Borrows = new List<Borrow> {
                new Borrow { Id = 1, UserId =1, BookId =3, BorrowDate = DateTime.Now, StatusId = 1 },
                new Borrow { Id = 2, UserId =2, BookId =2, BorrowDate = DateTime.Now, StatusId = 2 },
                new Borrow { Id = 3, UserId =3, BookId =1, BorrowDate = DateTime.Now, StatusId = 3 }};

            Genres = new List<Genre> { new Genre { Id = 1, Name = "test1"},
                                       new Genre { Id = 2, Name = "test2"},
                                       new Genre { Id = 3, Name = "test3"}};

            Statuses = new List<Status> { new Status { Id = 1, Name = "test1"},
                                          new Status { Id = 2, Name = "test2"},
                                          new Status { Id = 3, Name = "test3"}};

        }
    }
}
