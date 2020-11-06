namespace DAL.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Availability { get; set; }
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        //
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }
    }
}