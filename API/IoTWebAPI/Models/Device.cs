using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebAPI.Models
{
    public class Device
    {
        public string d_id { get; set; }    //PK
        public string u_id { get; set; }    //FK to User
        public string device_name { get; set; }
        public string device_description { get; set; }
        public string img_url { get; set; }
        public bool is_active { get; set; }
        public DateTime create_time { get; set; }
        public List<DvAttribute> list_attributes { get; set; }    //A Device (1) - manage - (n) many attributes
        //public ICollection<DvAttribute> list_attributes { get; set; } // Recommend not have FK
        public User owner { get; set; } // n - 1 to User
    }
}
