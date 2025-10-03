using Database.Models;
using Repository.IRepository;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    interface IUnitOfWork
    {
        IBooksRepository BooksRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
