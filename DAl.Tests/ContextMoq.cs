using DAL.Context;
using DAL.Entities;
using DAL.Repository;
using DAL.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DAl.Tests;

public abstract class ContextMoq
{
    protected readonly ApplicationContext context;

    public ContextMoq()
    {
        var options = new DbContextOptionsBuilder<ApplicationContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        context = new ApplicationContext(options);
    }

    protected void RefillDb()
    {
        var Users = new List<User>
        {
            new User { Id = 1, Name = "testName" },
            new User { Id = 2, Name = "testName2" },
            new User { Id = 3, Name = "testName3" }
        };

        var Books = new List<Book>
        {
            new Book { Id = 1, Title = "test", GenreId = 1, Count =10, Author = "test"},
            new Book { Id = 2, Title = "test1", GenreId = 2, Count =10, Author = "test"},
            new Book { Id = 3, Title = "test2", GenreId = 3, Count =10, Author = "test"}
        };

        var Borrows = new List<Borrow> 
        {
            new Borrow { Id = 1, UserId =1, BookId =3, BorrowDate = DateTime.Now, StatusId = 1 },
            new Borrow { Id = 2, UserId =2, BookId =2, BorrowDate = DateTime.Now, StatusId = 2 },
            new Borrow { Id = 3, UserId =3, BookId =1, BorrowDate = DateTime.Now, StatusId = 3 }
        };

        var Genres = new List<Genre> 
        {
            new Genre { Id = 1, Name = "test1"},
            new Genre { Id = 2, Name = "test2"},
            new Genre { Id = 3, Name = "test3"}
        };

        var Statuses = new List<Status>
        { 
            new Status { Id = 1, Name = "test1"},
            new Status { Id = 2, Name = "test2"},
            new Status { Id = 3, Name = "test3"}
        };

        context.Users.RemoveRange(context.Users);
        context.Users.AddRange(Users);
        context.Borrows.RemoveRange(context.Borrows);
        context.Borrows.AddRange(Borrows);
        context.Books.RemoveRange(context.Books);
        context.Books.AddRange(Books);
        context.Genres.RemoveRange(context.Genres);
        context.Genres.AddRange(Genres);
        context.Status.RemoveRange(context.Status);
        context.Status.AddRange(Statuses);
        context.SaveChanges();
    }
}
