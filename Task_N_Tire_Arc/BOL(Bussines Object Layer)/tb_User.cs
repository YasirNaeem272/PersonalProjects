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
    
    public partial class tb_User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_User()
        {
            this.tb_Staff = new HashSet<tb_Staff>();
        }
    
        public int Usr_Id { get; set; }
        public string Usr_Name { get; set; }
        public string Usr_Email { get; set; }
        public string Usr_Password { get; set; }
        public int Role_Id { get; set; }
    
        public virtual tb_Role tb_Role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Staff> tb_Staff { get; set; }
    }
}
