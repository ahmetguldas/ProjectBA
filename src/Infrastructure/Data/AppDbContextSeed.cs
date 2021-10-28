using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
   public class AppDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext db)
        {
            if (!await db.Authors.AnyAsync() && !await db.Categories.AnyAsync() && !await db.Products.AnyAsync())
            {
                var author1 = new Author() { AuthorName = "George Orwell" };
                var author2 = new Author() { AuthorName = "Livaneli" };
                var author3 = new Author() { AuthorName = "Madelina Miller" };
                var author4 = new Author() { AuthorName = "John Steinback" };
                var author5 = new Author() { AuthorName = "Matt Haig" };
                var author6 = new Author() { AuthorName = "Tolstoy" };
                var author7 = new Author() { AuthorName = "Jose Saramago" };
                var author8 = new Author() { AuthorName = "Paul Coelho" };
                var author9 = new Author() { AuthorName = "Piraye" };
                var author10 = new Author() { AuthorName = "Jackques Ranciere" };
                var author11 = new Author() { AuthorName = "Spinoza" };
                var author12 = new Author() { AuthorName = "Niger Warbutton" };
                var author13 = new Author() { AuthorName = "Rollo May" };
                await db.Authors.AddRangeAsync(author1, author2, author3, author4, author5, author6, author7, author8, author9,author10,author11, author12, author13);

                var cat1 = new Category() { CategoryName = "Edebiyat" };
                var cat2 = new Category() { CategoryName = "Felsefe" };
                await db.Categories.AddRangeAsync(cat1, cat2);

                await db.Products.AddRangeAsync(
                    new Product() { ProductName = "1984", Price = 7.31m, PictureUri = "1984.png", Author = author1, Category = cat1 },
                    new Product() { ProductName = "Balıkçı ve oğlu", Price = 12.99m, PictureUri = "balikci.png", Author = author2, Category = cat1 },
                    new Product() { ProductName = "Ben, Kirke", Price = 5.99m, PictureUri = "benkirke.jpg", Author = author3, Category = cat1 },
                    new Product() { ProductName = "Fareler ve İnsanlar", Price = 9.19m, PictureUri = "farelerveinsanlar.png", Author = author4, Category = cat1 },
                    new Product() { ProductName = "Gece yarısı kütüphanesi", Price = 39.47m, PictureUri = "geceyarisikutuphanesi.jpg", Author = author5, Category = cat1 },
                    new Product() { ProductName = "Hayvan Çiftliği", Price = 14.71m, PictureUri = "hanvanciftligi.png", Author = author1, Category = cat1 },
                    new Product() { ProductName = "İnsan ne ile yaşar", Price = 19.05m, PictureUri = "insanneyleyasar.png", Author = author6, Category = cat1 },
                    new Product() { ProductName = "Körlük", Price = 11.32m, PictureUri = "korluk.png", Author = author7, Category = cat1 },
                    new Product() { ProductName = "Okçu'nun yolu", Price = 16.62m, PictureUri = "okcununyolu.png", Author = author8, Category = cat1 },
                    new Product() { ProductName = "Seyir", Price = 16.62m, PictureUri = "piraye.png", Author = author9, Category = cat1 },
                    new Product() { ProductName = "Cahil Hoca", Price = 16.25m, PictureUri = "cahilhoca.png", Author = author10, Category = cat2 },
                    new Product() { ProductName = "Ethica", Price = 11.25m, PictureUri = "ethika.png", Author = author11, Category = cat2 },
                    new Product() { ProductName = "Felsefenin Kısa Tarihi", Price = 10.25m, PictureUri = "felsefeninkisatarihi.png", Author = author12, Category = cat2 },
                    new Product() { ProductName = "Yaratma Cesareti", Price = 10.25m, PictureUri = "yaratmacesareti.png", Author = author12, Category = cat2 }
                    );
                await db.SaveChangesAsync();
            }
        }
    }
}
