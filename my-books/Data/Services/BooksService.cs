using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;

        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre=book.Genre,
                Author=book.Author,
                CoverUrl=book.CoverUrl,
                DateAdded=DateTime.Now            
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }

        //public List<Book> GetAllBooks()
        //{
        //    var allBooks = _context.Books.ToList();
        //    return allBooks;
        //}
        //----Alternative to above code in single line

        public List<Book> GetAllBooks() => _context.Books.ToList();

        public Book GetBookByID(int bookID) => _context.Books.FirstOrDefault(x => x.Id == bookID);
    }
}
