namespace lr5.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public List<Book> Books { get; set; }

        public Author() { Books = new List<Book>(); }

        public void AddBook(Book b)
        {
            Books.Add(b);
        }
    }

    public class Genre
    {
        public int ID { get; set; }
        public string? GenreName { get; set; }
        public List<Book> Books { get; set; }

        public Genre() { Books = new List<Book>(); }

        public void AddBook(Book b)
        {
            Books.Add(b);
        }
    }

    public class Book
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public Author? Aut { get; set; }
        public Genre? Gen { get; set; }
    }

}
