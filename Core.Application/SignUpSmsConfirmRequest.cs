using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application
{
   public class SignUpSmsConfirmRequest
    {
        public string PrivateNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string SmsCode { get; set; }
    }
}
