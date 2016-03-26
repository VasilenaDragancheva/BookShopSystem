namespace BookShopConsoleClient
{
    using System.Linq;

    using BookShop.Context;

    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new BookShopContext();

            var count = context.Books.Count();
        }
    }
}