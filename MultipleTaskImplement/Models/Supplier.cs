using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TashBlock.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string SupplierEmail { get; set; }
        public int CountryCode { get; set; }
        public int SupplierPhoneNumber { get; set; }
        public string SupplierAddress { get; set; }
        public string LocationName { get; set; }
        public string SupplierCompanyName { get; set; }
    }
}
