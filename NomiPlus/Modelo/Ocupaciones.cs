//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NomiPlus.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ocupaciones
    {
        public Ocupaciones()
        {
            this.Empleado = new HashSet<Empleado>();
        }
    
        public int nIdOcupacion { get; set; }
        public string sOcupacion { get; set; }
        public bool bActivo { get; set; }
    
        public virtual ICollection<Empleado> Empleado { get; set; }
    }
}
