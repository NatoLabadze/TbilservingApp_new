using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrivateNumber { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
    
        public int AccessFailedCount { get; set; }
        public DateTime? PhoneNumberConfirmedDate { get; set; }
 
    }
}
