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

            //veritabanı boşsa burayı koy

            
            var cat3 = new Category() { CategoryName = "Roman" };
            var cat1 = new Category() { CategoryName = "cocuk" };
            dbContext.AddRange(cat3, cat1);
            

            var a1 = new Author() { AuthorName = "seda" };
            var a2 = new Author() { AuthorName = "seda" };
            dbContext.AddRange(a1, a2);
            


            var p1 = new Product() { BookName = "Kürk Mantolu Madonna", Price = 0.00m,  Description="öylesine", Title="sea",  Image = "kurkmanto.png", Category = cat3 , Author=a1};  
            var p2 = new Product() { BookName = "Kürk Mantolu Madonna", Price = 0.00m,  Description="öylesine", Title="sea",  Image = "kurkmanto.png", Category = cat1 , Author=a2};  
            //todo
            dbContext.AddRange(p1,p2);
            await dbContext.SaveChangesAsync();
        }
    }
}
