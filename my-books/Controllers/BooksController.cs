using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost ("add-book")]

        public IActionResult AddBook([FromBody] BookVM book)
        {
            _booksService.AddBook(book);
            return Ok();
        }

        [HttpGet ("get-all-books")]

        public IActionResult GetAllBooks()
        {
          return Ok( _booksService.GetAllBooks());
        }

        [HttpGet("get-book-by-id/{id}")]

        public IActionResult GetBookByID(int id)
        {
            return Ok(_booksService.GetBookByID(id));
        }

        [HttpPut ("update-book-by-id/{id}")]
        public IActionResult UpdateBookByID(int id, [FromBody] BookVM book)
        {
            var updatedBook = _booksService.UpdateBookById(id, book);
            return Ok(updatedBook);
        }
    }
}
