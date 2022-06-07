using System;
using System.Collections.Generic;

namespace BookStore.Database.Entities
{
    public class Author
    {
        public Guid AuthorId { get; set; }
        public string Name { get; set; }
        public List<Guid> BookIds { get; set; }
        public List<Book> Books { get; set; }
    }
}
