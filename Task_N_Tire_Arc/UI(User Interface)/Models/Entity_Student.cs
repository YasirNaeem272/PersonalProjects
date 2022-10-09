using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_User_Interface_.Models
{
    public class Entity_Student
    {

        public int Std_Id { get; set; }
       
        public string F_Name { get; set; }
        public string L_Name { get; set; }
        public Nullable<int> Cntct_Number { get; set; }
        public string Std_Image { get; set; }
        public HttpPostedFileBase UserImageFile { get; set; }
        public string City_Name { get; set; }
        public string State_Name { get; set; }
        public string Area_Name { get; set; }
        public string Class_Name { get; set; }
        public int Class_Id { get; set; }
        public int Address_Id { get; set; }
        public string Address_Complete_Adres { get; set; }
        public int City_Id { get; set; }
        public int State_Id { get; set; }
        public string Class_Section { get; set; }
        public int Area_Id { get; set; }
    }
}