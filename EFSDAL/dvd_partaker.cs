//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFSDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class dvd_partaker
    {
        public int id { get; set; }
        public int dvd_id { get; set; }
        public int partaker_id { get; set; }
        public int capacity_code { get; set; }
    
        public virtual capacity capacity { get; set; }
        public virtual dvd dvd { get; set; }
        public virtual partaker partaker { get; set; }
    }
}
