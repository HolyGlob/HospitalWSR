//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HospitalWSR
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hospitalization
    {
        public int ID { get; set; }
        public int MedicalCardID { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual MedicalCard MedicalCard { get; set; }
    }
}
