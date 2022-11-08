using System.Collections;
using System.Collections.Generic;

namespace Web.App.Composite.Models
{
    public class Category
    {
        // Id Name       UserId RefrenceId
        // 1  Kitaplar    1      0    
        // 2  Kitaplar2   1      0

        // referans id eğer 0 ise daha üst kategorisi yoktur.

        public int Id { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }

        public ICollection<Book> Books;

        public int ReferenceId { get; set; }

    }
}
