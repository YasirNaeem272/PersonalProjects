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
    
    public partial class tb_State
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_State()
        {
            this.tb_City = new HashSet<tb_City>();
        }
    
        public int State_Id { get; set; }
        public string State_Name { get; set; }
        public int Isselect { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_City> tb_City { get; set; }
    }
}
