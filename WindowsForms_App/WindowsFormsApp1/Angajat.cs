//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Angajat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int An { get; set; }
        public Nullable<int> Categorie { get; set; }
        public string Adresa { get; set; }
        public int Vanzari { get; set; }
    
        public virtual Categorie Categorie1 { get; set; }
    }
}
