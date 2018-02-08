using LibraryApp.Mongo.Interfaces;
using LibraryApp.Mongo.Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Mongo.Repositories
{
    public class UnitOfWorkMongo : IUnitOfWorkMongo
    {
        private readonly NoteContext _context = null;

        IProductRepository _productRepository;
        private INoteRepository _noteRepository;

        public UnitOfWorkMongo(IOptions<Settings> settings)
        {
            _context = new NoteContext(settings); 
        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(_context);

                return _productRepository;
            }
        }

        public INoteRepository NoteRepository
        {
            get
            {
                if (_noteRepository == null)
                    _noteRepository = new NoteRepository(_context);

                return _noteRepository;
            }
        }

    }
}
