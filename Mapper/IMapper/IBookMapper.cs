using Database.Models;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.IMapper
{
    public interface IBookMapper
    {
        BookDto ToDto(Book entity);
        Book ToEntity(CreateBookDto dto);
        void UpdateEntity(Book entity, UpdateBookDto dto);
    }
}
