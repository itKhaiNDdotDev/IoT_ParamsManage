using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebAPI.DTOs.Users
{
    public class AuthViewModel
    {
        public int id { get; set; }
        public string email { get; set; }
        public string fullname { get; set; }
        public bool is_active { get; set; }
        public DateTime create_date { get; set; }
        public string token { get; set; }
    }
}
