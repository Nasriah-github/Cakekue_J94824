using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
namespace Cakekue_J94824.Models
{
    public class Product
    {
        public int ID { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}



       