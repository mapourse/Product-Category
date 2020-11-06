using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL
{
    class MarketDBInitializer : DropCreateDatabaseAlways<Market>
    {
        protected override void Seed(Market context)
        {
            base.Seed(context);

            Category fruitsCat = new Category() { Name = "Fruits" };
            Category bakeryCat = new Category() { Name = "Bakery" };

            context.Categories.AddRange(
                new List<Category>() {
                    fruitsCat, bakeryCat
                });

            context.Products.AddRange(
                new List<Product>() {
                    new Product() {
                        Name = "Bread",
                        Price = 0.99M,
                        Availability = true,
                        Category = bakeryCat
                    },
                    new Product() {
                        Name = "Croissant",
                        Price = 1.99M,
                        Availability = true,
                        Category = bakeryCat
                    },
                    new Product() {
                        Name = "Orange",
                        Price = 1.59M,
                        Availability = false,
                        Category = fruitsCat
                    },
                    new Product()
                    {
                        Name = "Apple",
                        Price = 0.29M,
                        Availability = true,
                        Category = fruitsCat
                    }
                });

            context.SaveChanges();
        }
    }
}
