using DamianMuchaDom2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DamianMuchaDom2.Controllers
{
    public class HomeController : Controller
    {
        //list containing the books
        List<Book> bookList;

        public HomeController()
        {
            //manually adding the books as there's no connection with the db yet
            bookList = new List<Book>();
            bookList.Add(new Book(1, "Witcher: Sword of Destiny", "Second book in The Witcher series", "Andrzej Sapkowski", "Fantasy", 34.99, "witcher.jpg"));
            bookList.Add(new Book(2, "The Lord of the Ice Garden", "First book in The Lord of The Ice Garden series", "Jarosław Grzędowicz", "Fantasy", 34.99, "ice.jpg"));
            bookList.Add(new Book(3, "Dune", "First book in the Dune series", "Frank Herbert", "Fantasy", 39.99, "dune.jpg"));
        }

        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Viewing all books data
        /// </summary>
        /// <returns></returns>
        public IActionResult AllBooks()
        {
            return View(bookList);
        }
        /// <summary>
        /// Viewing one book detailed view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult BookDetails(int id)
        {
            var book = bookList.FirstOrDefault(x => x.Id == id);
            return View(book);
        }
        /// <summary>
        /// Viewing a form allowing to make an order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult CreateOrder(int id)
        {
            var book = bookList.FirstOrDefault(x => x.Id == id);
            ViewBag.book = book;
            return View();
        }
        /// <summary>
        /// Post method for making an order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOrder([Bind("BookId, Email, Phone, FirstName, LastName, City, Address, Amount")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.OrderDate = DateTime.Now;
                var book = bookList.FirstOrDefault(x => x.Id == order.BookId);
                ViewBag.orderedBook = book;
                return View("PlacedOrder", order);
            }
            else
            {
                var book = bookList.FirstOrDefault(x => x.Id == order.BookId);
                ViewBag.book = book;
                return View(order);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
