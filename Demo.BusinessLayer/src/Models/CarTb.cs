using System;
using System.Collections.Generic;

namespace Demo.BusinessLayer.Models
{
    public partial class CarTb
    {
        public int CId { get; set; }
        public string ModelName { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int? NoOfPas { get; set; }
        public decimal? Price { get; set; }
        public string Image { get; set; }
        public string Fueltype { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
