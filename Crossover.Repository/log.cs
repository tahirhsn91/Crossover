//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Crossover.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class log
    {
        public int log_id { get; set; }
        public string logger { get; set; }
        public string level { get; set; }
        public string message { get; set; }
        public string application_id { get; set; }
    
        public virtual application application { get; set; }
    }
}
