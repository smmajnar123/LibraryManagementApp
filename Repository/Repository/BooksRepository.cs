using Database.Data;
using Database.Models;
using LibraryAPI.Repositories;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class BooksRepository : GenericRepository<Book>, IBooksRepository
    {
        private new readonly LibraryManagementDbContext _context;

        public BooksRepository(LibraryManagementDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
