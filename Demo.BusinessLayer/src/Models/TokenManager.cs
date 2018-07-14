using System;
using System.Collections.Generic;

namespace Demo.BusinessLayer.Models
{
    public partial class TokenManager
    {
        public int TokenId { get; set; }
        public string TokenKey { get; set; }
        public DateTime? IssuedOn { get; set; }
        public DateTime? ExpiresOn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UserId { get; set; }
    }
}
