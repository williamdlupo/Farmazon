//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Farmazon
{
    using System;
    using System.Collections.Generic;
    
    public partial class MarketItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MarketItem()
        {
            this.Inventories = new HashSet<Inventory>();
        }
    
        public int ItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoLocation { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual MarketItem MarketItem1 { get; set; }
        public virtual MarketItem MarketItem2 { get; set; }
    }
}
