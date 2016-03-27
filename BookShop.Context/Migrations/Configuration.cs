namespace BookShop.Context.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.IO;
    using System.Linq;

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
            int countOfCategories = 0;
            var categoriesName = new List<string>();

            using (var reader = new StreamReader("categories.txt"))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] categories = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    categoriesName.AddRange(categories);
                    countOfCategories += categories.Length;
                    line = reader.ReadLine();
                }
            }

            using (var reader = new StreamReader("books.txt"))
            {
                string tags = reader.ReadLine();
                var categoriesGenerator = new Random();
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] entities = line.Split(new char[] { ' ' }, 6);
                    var edition = (EditionType)int.Parse(entities[0]);
                    var dateRelease = this.ParseDate(entities[1]);
                    var copies = int.Parse(entities[2]);
                    var price = decimal.Parse(entities[3]);
                    var ageRestriction = (AgeRestriction)int.Parse(entities[4]);
                    var title = entities[5];
                    var catId = categoriesGenerator.Next(0, countOfCategories);
                    var catName = categoriesName[catId];

                    var book = new Book()
                    {
                        EditionType = edition,
                        ReleaseDate = dateRelease,
                        Copies = copies,
                        Price = price,
                        AgeRestriction = ageRestriction,
                        Title = title,

                    };
                    book.Categories.Add(new Category() { Id = catId, Name = catName });
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

        private DateTime ParseDate(string input)
        {
            int[] parts = input.Split('/').Select(int.Parse).ToArray();
            return new DateTime(parts[2], parts[1], parts[0]);
        }
    }
}