using DAL.Entities;
using DAL.Repository;
using DAL.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAl.Tests
{
    public class RepositoryMoq : ContextMoq
    {
        protected IGenericRepository<User> _userRepository;
        protected IGenericRepository<Book> _bookRepository;
        protected IGenericRepository<Borrow> _borrowRepository;
        protected IGenericRepository<Status> _statusRepository;
        protected IGenericRepository<Genre> _genreRepository;

        public RepositoryMoq()
        {
            RefillDb();
            _userRepository = new GenericRepository<User>(context);
            _bookRepository = new GenericRepository<Book>(context);
            _borrowRepository = new GenericRepository<Borrow>(context);
            _statusRepository = new GenericRepository<Status>(context);
            _genreRepository = new GenericRepository<Genre>(context);
        }

    }
}
