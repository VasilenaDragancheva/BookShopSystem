using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopConsoleClient
{
    using BookShop.Context;

    public class BooksController : Controller
    {
        public BooksController(BookShopContext bookShopContext)
            : base(bookShopContext)
        {
        }


        public string BooksAfterYear(int year)
        {
            //TODO Validations
            var titles =
                this.BookShopContext.Books.Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year >= year)
                    .Select(b => b.Title);

            return string.Join(Environment.NewLine, titles);
        }

        public string BooksByAuthor(string firstName, string lastName)
        {
            //TODO Validations
            var books =
                this.BookShopContext.Books.Where(
                    b => b.Authors.Any(a => a.FirstName == firstName && a.LastName == lastName))
                    .OrderByDescending(b => b.ReleaseDate)
                    .ThenBy(b => b.Title)
                    .Select(b => string.Format("Title:{0} ReleaseDate:{1} Copies{2}", b.Title, b.ReleaseDate, b.Copies));

            return string.Join(Environment.NewLine, books);

        }
    }
}
