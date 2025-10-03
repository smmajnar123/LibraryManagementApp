using Database.Models;
using Repository;
using Services.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class BooksService : IBooksService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BooksService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _unitOfWork.BooksRepository.GetAllAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int bookId)
        {
            return await _unitOfWork.BooksRepository.GetByIdAsync(bookId);
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            await _unitOfWork.BooksRepository.AddAsync(book);
            await _unitOfWork.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            _unitOfWork.BooksRepository.Update(book);
            await _unitOfWork.SaveChangesAsync();
            return book;
        }

        public async Task DeleteBookAsync(int bookId)
        {
            var book = await _unitOfWork.BooksRepository.GetByIdAsync(bookId);
            if (book != null)
            {
                _unitOfWork.BooksRepository.Delete(book);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
