//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOL_Bussines_Object_Layer_
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_Area
    {
        public int Area_Id { get; set; }
        public string Area_Name { get; set; }
        public int City_Id { get; set; }

        public int Isselect { get; set; }
        public virtual tb_City tb_City { get; set; }
    }
}
