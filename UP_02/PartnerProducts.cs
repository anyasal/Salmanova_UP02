//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UP_02
{
    using System;
    using System.Collections.Generic;
    
    public partial class PartnerProducts
    {
        public int PartnerID { get; set; }
        public int ProductID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual Partners Partners { get; set; }
        public virtual Products Products { get; set; }
        public virtual Products Products1 { get; set; }
    }
}