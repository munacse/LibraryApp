using LibraryApp.DataAccess.Repositories;
using LibraryApp.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly LibraryAppDbContext _context;

        IBookCategoryRepository _bookCategories;
        IBookRepository _books;
        IAuthorRepository _authors;



        public UnitOfWork(LibraryAppDbContext context)
        {
            _context = context;
        }



        public IBookCategoryRepository BookCategories
        {
            get
            {
                if (_bookCategories == null)
                    _bookCategories = new BookCategoryRepository(_context);

                return _bookCategories;
            }
        }



        public IBookRepository Books
        {
            get
            {
                if (_books == null)
                    _books = new BookRepository(_context);

                return _books;
            }
        }



        public IAuthorRepository Authors
        {
            get
            {
                if (_authors == null)
                    _authors = new AuthorRepository(_context);

                return _authors;
            }
        }




        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
