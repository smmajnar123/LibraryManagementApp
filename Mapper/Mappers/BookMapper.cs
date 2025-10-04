using Database.Models;
using Mapper.IMapper;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Mappers
{
    public class BookMapper : IBookMapper
    {
        public BookDto ToDto(Book entity)
        {
            return new BookDto
            {
                BookId = entity.BookId,
                Title = entity.Title,
                Author = entity.Author,
                Isbn = entity.Isbn,
                PublishedYear = entity.PublishedYear,
                AvailableCopies = entity.AvailableCopies
            };
        }

        public Book ToEntity(CreateBookDto dto)
        {
            return new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                Isbn = dto.Isbn,
                PublishedYear = dto.PublishedYear,
                AvailableCopies = dto.AvailableCopies
            };
        }

        public void UpdateEntity(Book entity, UpdateBookDto dto)
        {
            entity.Title = dto.Title;
            entity.Author = dto.Author;
            entity.Isbn = dto.Isbn;
            entity.PublishedYear = dto.PublishedYear;
            entity.AvailableCopies = dto.AvailableCopies;
        }
    }
 }
