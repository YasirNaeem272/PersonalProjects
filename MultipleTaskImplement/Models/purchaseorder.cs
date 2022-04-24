using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TashBlock.Models
{
    public class purchaseorder
    {
        [Key]
        public int Id { get; set; }
        public Nullable<System.DateTime> PurchaseOrderDate { get; set; }
        public int PurchaseOrderNo { get; set; }
        public int Terms { get; set; }
        public int Ref_MroNo { get; set; }
        public int Attn { get; set; }
        public int FaxNo { get; set; }
        public int ContactPerson { get; set; }
        public string ProjectTitle { get; set; }
        public int DeliverTo { get; set; }
        public string SupplierName { get; set; }
        public string SupplierLocation { get; set; }
        //public string ProductName { get; set; }
        //public string ProductCode { get; set; }
        //public int Price { get; set; }
        //public int Quality { get; set; }
        //public float Discount { get; set; }
        //public int Value { get; set; }
        //public int Total { get; set; }
        //public int TotalQuality { get; set; }
        //public int NetAmount { get; set; }
        //public int DiscountOptional { get; set; }
        //public int ValueOptional { get; set; }
        //public float SalesTax { get; set; }
    }
}

