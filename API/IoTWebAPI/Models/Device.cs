using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebAPI.Models
{
    public class Device
    {
        public int d_id { get; set; }    //PK
        public int u_id { get; set; }    //FK to User
        public string device_name { get; set; }
        public string device_description { get; set; }
        public string img_url { get; set; }
        public bool is_active { get; set; }
        [DataType(DataType.Date)]
        public DateTime create_date { get; set; }
        public List<DvAttribute> list_attributes { get; set; }    //A Device (1) - manage - (n) many attributes
        //public ICollection<DvAttribute> list_attributes { get; set; } // Recommend not have FK
        public User owner { get; set; } // n - 1 to User
    }
}
