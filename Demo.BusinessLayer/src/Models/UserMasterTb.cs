using System;
using System.Collections.Generic;

namespace Demo.BusinessLayer.Models
{
    public partial class UserMasterTb
    {
        public int UId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public DateTime? Birthdate { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public int? UserTypeId { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
