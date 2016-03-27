namespace BookShopConsoleClient
{
    using System;
    using System.Linq;
    using System.Text;

    using BookShop.Context;

    public class CategoriesController : Controller
    {
        public CategoriesController(BookShopContext bookShopContext)
            : base(bookShopContext)
        {
        }

        public string RecentBooksByCategories()
        {
            var categories =
                this.BookShopContext.Categories.OrderByDescending(c => c.Books.Count)
                    .Select(
                        cat =>
                        new
                            {
                                cat.Name,
                                BooksCount = cat.Books.Count,
                                RecentBooks =
                            cat.Books.OrderByDescending(b => b.ReleaseDate)
                            .Take(3)
                            .Select(b => string.Format("{0} ({1}) ", b.Title, b.ReleaseDate))
                            });

            var result = new StringBuilder();

            foreach (var category in categories)
            {
                result.AppendFormat("--{0} {1} books", category.Name, category.BooksCount).AppendLine();
                result.Append(string.Join(Environment.NewLine, category.RecentBooks));
            }

            return result.ToString().Trim();
        }
    }
}