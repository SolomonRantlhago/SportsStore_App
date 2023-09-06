using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Models
{
    public class Product
    {
        
        public int ProductID { get; set; }
        [Required(ErrorMessage ="Please Enter a product Name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please Enter a Description")]
        public string Description { get; set; }

       [Required(ErrorMessage = "Please Enter a Positive Price")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(8, 2)")]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please Select a Category")]
        [Display(Name ="Category")]
        public int CategoryID { get; set; }

        public Category Category { get; set; }
    }
}
