//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentalCarProject1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Delivery
    {
        public int id_delivery { get; set; }
        public int client_id { get; set; }
        public int product_id { get; set; }
        public int storage_id { get; set; }
        public decimal delivery_price { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Product Product { get; set; }
        public virtual Storage Storage { get; set; }
    }
}
