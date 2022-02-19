using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebAPI.Models
{
    public class Data
    {
        public string id { get; set; }    //PK
        public string a_id { get; set; }    //FK to Attribute
        public float value { get; set; }
        public DateTime update_time { get; set; }
        public DvAttribute dv_attribute { get; set; }
    }
}
