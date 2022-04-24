using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TashBlock.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int CostPrice { get; set; }
        public int SellingPrice { get; set; }
        public string UnitofMaterial { get; set; }
        public string Level3Id { get; set; }
    }
}
