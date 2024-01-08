using LiberaryBook.Data;
using LiberaryBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace LiberaryBook.Controllers
{
    public class BookInventoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookInventoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var books = _context.Books.Where(b => b.IsActive)
                                      .Select(b => new BookViewModel()
                                      {
                                          Id = b.Id,
                                          Title = b.Title,
                                          Author = b.Author,
                                          BorrowedBook = b.BorrowedBook,
                                          AvilableBook = b.AvilableBook,
                                          TotalInvetory = b.TotalInvetory
                                      }).ToList();

            return View(books);
        }

        [HttpPost]
        public IActionResult removeBook(int Id)
        {
            var book = _context.Books.Where(b => b.Id == Id).FirstOrDefault();

            if (book is not null)
            {
                book.IsActive = false;
                _context.SaveChanges();

                return Json(new { success = true, message = "Book removed successfully" });
            }
            else
                return Json(new { success = false, message = "Failed to remove book" });
        }
    }
}
