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
            if (await dbContext.Categories.AnyAsync() || await dbContext.Products.AnyAsync()) return;

            //veritabanı boşsa burayı koy

            Category cat1 = new Category() { CategoryName = "Edebiyat Kitapları" };
            Category cat2 = new Category() { CategoryName = "Çocuk Kitapları" };
            Category cat3 = new Category() { CategoryName = "Roman" };
            dbContext.AddRange(cat1, cat2, cat3);
            await dbContext.SaveChangesAsync();  //adı, fiyatı


            var p1 = new Product() { BookName = "", Price = 0.00m, Description = "", Image = ".jpg", Category = cat1 };  
            //todo
            dbContext.AddRange(p1);
            await dbContext.SaveChangesAsync();
        }
    }
}
