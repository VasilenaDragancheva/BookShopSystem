namespace BookShopConsoleClient
{
    using System.Linq;

    using BookShop.Context;

    public class Program
    {
        public static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            var context = new BookShopContext();

            var count = context.Books.Count();
        }
    }
}