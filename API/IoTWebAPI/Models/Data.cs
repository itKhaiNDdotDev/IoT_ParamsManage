using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebAPI.Models
{
    public class Data
    {
        public int id { get; set; }    //PK
        public int a_id { get; set; }    //FK to Attribute
        public float value { get; set; }
        public DateTime update_time { get; set; }
        public DvAttribute dv_attribute { get; set; }
    }
}
