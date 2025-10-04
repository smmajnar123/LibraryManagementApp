using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Isbn { get; set; } = null!;
        public int? PublishedYear { get; set; }
        public int? AvailableCopies { get; set; }
    }

    public class CreateBookDto
    {
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Isbn { get; set; } = null!;
        public int? PublishedYear { get; set; }
        public int? AvailableCopies { get; set; }
    }

    public class UpdateBookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Isbn { get; set; } = null!;
        public int? PublishedYear { get; set; }
        public int? AvailableCopies { get; set; }
    }
}
