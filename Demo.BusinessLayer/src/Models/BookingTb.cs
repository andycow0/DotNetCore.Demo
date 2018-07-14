using System;
using System.Collections.Generic;

namespace Demo.BusinessLayer.Models
{
    public partial class BookingTb
    {
        public int BookingId { get; set; }
        public string Name { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string SAddress { get; set; }
        public string DAddress { get; set; }
        public string EmailId { get; set; }
        public string ContactNo { get; set; }
        public int? CId { get; set; }
        public int? Amount { get; set; }
        public string PaymentStatus { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
