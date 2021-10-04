using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext dbContext)
        {
            if (await dbContext.Categories.AnyAsync() || await dbContext.Products.AnyAsync() || await dbContext.Authors.AnyAsync()) return;



            var cat1 = new Category() { CategoryName = "Edebiyat Kitapları" };
            var cat2 = new Category() { CategoryName = "Tarih Kitapları" };   //todo
            dbContext.AddRange(cat1, cat2);



            var yazar1 = new Author() { AuthorName = "Sabahattin Ali" };
            var yazar2 = new Author() { AuthorName = "George Orwell" };
            var yazar3 = new Author() { AuthorName = "Stefan Zweig" };
            var yazar4 = new Author() { AuthorName = "Albert Camus" };
            var yazar5 = new Author() { AuthorName = "Oğuz Atay" };
            var yazar6 = new Author() { AuthorName = "Recep Tayyip Erdoğan" };
            var yazar7 = new Author() { AuthorName = "Andrew Marr" };
            dbContext.AddRange(yazar1, yazar2, yazar3, yazar4, yazar5, yazar6, yazar7);


            var p1 = new Product() { BookName = "Kürk Mantolu Madonna", Price = 50.00m, Image = "kurkmanto.png", Category = cat1, Author = yazar1 };
            var p2 = new Product() { BookName = "1984", Price = 50.00m, Image = "1984.png", Category = cat1, Author = yazar2 };
            var p3 = new Product() { BookName = "Satranç", Price = 52.00m, Image = "satranc.png", Category = cat1, Author = yazar3 };
            var p4 = new Product() { BookName = "Yabancı", Price = 60.00m, Image = "yabanci.png", Category = cat1, Author = yazar4 };
            var p5 = new Product() { BookName = "Kuyucaklı Yusuf", Price = 55.00m, Image = "kuyucakliyusuf.png", Category = cat1, Author = yazar1 };
            var p6 = new Product() { BookName = "Tutunamayanlar", Price = 52.00m, Image = "tutunamayanlar.png", Category = cat1, Author = yazar5 };
            var p7 = new Product() { BookName = "Korku", Price = 50.00m, Image = "korku.png", Category = cat1, Author = yazar3 };
            var p8 = new Product() { BookName = "Düşüş", Price = 50.00m, Image = "dusus.png", Category = cat1, Author = yazar4 };
            var p9 = new Product() { BookName = "Hayvan Çiftliği", Price = 60.00m, Image = "hayvanciftligi.png", Category = cat1, Author = yazar2 };
            var p10 = new Product() { BookName = "Tehlikeli Oyunlar", Price = 60.00m, Image = "tehlikelioyunlar.png", Category = cat1, Author = yazar5 };
            var p11 = new Product() { BookName = "Daha Adil Bir Dünya Mümkün", Price = 50.00m, Image = "rte.png", Category = cat2, Author = yazar6 };
            var p12 = new Product() { BookName = "Büyük Dünya Tarihi", Price = 50.00m, Image = "buyukdunyatarihi.png", Category = cat2, Author = yazar7 };

            //todoiiii
            dbContext.AddRange(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);
            await dbContext.SaveChangesAsync();
        }
    }
}
