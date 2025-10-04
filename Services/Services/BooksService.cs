using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Models;
using Mapper.IMapper;
using Repository;
using Services.IServices;
using Shared.DTO;

namespace LibraryAPI.Services
{
    public class BooksService : IBooksService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookMapper _bookMapper;

        public BooksService(IUnitOfWork unitOfWork, IBookMapper bookMapper)
        {
            _unitOfWork = unitOfWork;
            _bookMapper = bookMapper;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var books = await _unitOfWork.BooksRepository.GetAllAsync();
            return _bookMapper.ToDtoList(books);
        }

        public async Task<BookDto?> GetBookByIdAsync(int bookId)
        {
            var book = await _unitOfWork.BooksRepository.GetByIdAsync(bookId);
            return book != null ? _bookMapper.ToDto(book) : null;
        }

        public async Task<BookDto> AddBookAsync(CreateBookDto createDto)
        {
            var entity = _bookMapper.ToEntity(createDto);
            await _unitOfWork.BooksRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _bookMapper.ToDto(entity);
        }

        public async Task<BookDto?> UpdateBookAsync(int id, UpdateBookDto updateDto)
        {
            var existingBook = await _unitOfWork.BooksRepository.GetByIdAsync(id);
            if (existingBook == null)
                return null;

            _bookMapper.UpdateEntity(existingBook, updateDto);

            _unitOfWork.BooksRepository.Update(existingBook);
            await _unitOfWork.SaveChangesAsync();

            return _bookMapper.ToDto(existingBook);
        }

        public async Task<bool> DeleteBookAsync(int bookId)
        {
            var book = await _unitOfWork.BooksRepository.GetByIdAsync(bookId);
            if (book == null)
                return false;

            _unitOfWork.BooksRepository.Delete(book);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
