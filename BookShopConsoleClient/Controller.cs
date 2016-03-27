namespace BookShopConsoleClient
{
    using BookShop.Context;

    public abstract class Controller
    {
        protected Controller(BookShopContext bookShopContext)
        {
            this.BookShopContext = bookShopContext;
        }

        protected BookShopContext BookShopContext { get; private set; }
    }
}