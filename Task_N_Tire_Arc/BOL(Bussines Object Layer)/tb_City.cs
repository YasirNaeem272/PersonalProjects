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
    
    public partial class tb_City
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_City()
        {
            this.tb_Area = new HashSet<tb_Area>();
        }
    
        public int City_Id { get; set; }
        public string City_Name { get; set; }
        public int State_Id { get; set; }
        public int Isselect { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Area> tb_Area { get; set; }
        public virtual tb_State tb_State { get; set; }
    }
}
