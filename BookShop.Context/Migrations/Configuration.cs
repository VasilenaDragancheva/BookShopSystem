namespace BookShop.Context.Migrations
{
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq.Expressions;
    using System.Xml.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<BookShopContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true; 
            this.ContextKey = "BookShop.Context.BookShopContext";
        }

        protected override void Seed(BookShopContext context)
        {

           }
    }
}