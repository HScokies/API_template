using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace API.Models.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName {get; set;}
    }
}
