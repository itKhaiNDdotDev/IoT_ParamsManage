using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebAPI.DTOs.DvAtbDatas
{
    public class DataValueViewModel
    {
        public int id { get; set; }
        public int a_id { get; set; }
        public float value { get; set; }
        public DateTime update_time { get; set; }
    }
}
