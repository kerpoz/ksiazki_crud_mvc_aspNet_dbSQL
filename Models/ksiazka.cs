//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ksiazki_crud.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ksiazka
    {
        public int ID { get; set; }
        public string tytul { get; set; }
        public string autor { get; set; }
        public Nullable<decimal> cena { get; set; }
    }
}
