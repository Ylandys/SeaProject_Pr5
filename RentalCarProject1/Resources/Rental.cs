//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentalCarProject1.Resources
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rental
    {
        public int id_rental { get; set; }
        public Nullable<decimal> cost_oneday_rental { get; set; }
        public Nullable<System.DateTime> rental_start_day { get; set; }
        public Nullable<int> rental_days { get; set; }
        public Nullable<decimal> car_insurance_value { get; set; }
        public Nullable<int> id_client { get; set; }
        public Nullable<int> id_car { get; set; }
    
        public virtual Car Car { get; set; }
        public virtual Client Client { get; set; }
    }
}