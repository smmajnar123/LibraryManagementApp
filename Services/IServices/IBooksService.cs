using Database.Models;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IBooksService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync();                // Return DTOs
        Task<BookDto?> GetBookByIdAsync(int bookId);                 // Return single DTO
        Task<BookDto> AddBookAsync(CreateBookDto createDto);         // Accept Create DTO
        Task<BookDto?> UpdateBookAsync(int bookId, UpdateBookDto updateDto); // Accept Update DTO
        Task<bool> DeleteBookAsync(int bookId);                      // Return success/failure
    }
}
