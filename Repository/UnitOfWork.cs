using Database.Data;
using Database.Models;
using LibraryAPI.Repositories;
using Repository.IRepository;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Repository
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryManagementDbContext _context;

        public IBooksRepository BooksRepository { get; private set; }

        public UnitOfWork(LibraryManagementDbContext context)
        {
            _context = context;
            BooksRepository = new BooksRepository(_context);

        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
