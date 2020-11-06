namespace DAL.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Market : DbContext
    {

        static Market()
        {
            Database.SetInitializer(new MarketDBInitializer());
        }

        public Market()
            : base("name=Market")
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}