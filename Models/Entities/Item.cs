using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace API.Models.Entities
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; }
        [Required]
        public int CategoryID { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Item name should contain at least 2 characters")]
        public string ItemName { get; set; }

        [Required]
        public decimal ItemPrice { get; set; }

        public Category Category { get; set; }
    }
}
