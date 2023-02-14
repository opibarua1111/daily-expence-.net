
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace DailyExpenses.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string ProductQuantity { get; set; }
        [Required]
        public string price { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
