namespace BookShop.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq.Expressions;

    using BookShopModels;

    public sealed class Configuration : DbMigrationsConfiguration<BookShopContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "BookShop.Context.BookShopContext";
        }

        protected override void Seed(BookShopContext context)
        {
            using (var reader = new StreamReader("books.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] entities = line.Split(new char[] { ' ' }, 6);
                    var edition = (EditionType)int.Parse(entities[0]);
                    var dateRelease = DateTime.Parse(entities[1]);
                    var copies = int.Parse(entities[2]);
                    var price = decimal.Parse(entities[3]);
                    var ageRestriction = (AgeRestriction)int.Parse(entities[4]);
                    var title = entities[5];
                    var book = new Book()
                                   {
                                       EditionType = edition,
                                       ReleaseDate = dateRelease,
                                       Copies = copies,
                                       Price = price,
                                       AgeRestriction =     ageRestriction,
                                       Title = title
                                   };
                    context.Books.Add(book);

                    line = reader.ReadLine();
                }
            }

            using (var reader = new StreamReader("authors.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] entities = line.Split(new char[] { ' ' });
                    context.Authors.Add(new Author() { FirstName = entities[0], LastName = entities[1] });

                    line = reader.ReadLine();
                }
            }
        }
    }
}