using IoTWebAPI.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebAPI.Models
{
    public class DvAttribute
    {
        public int a_id { get; set; }    //PK
        public int d_id { get; set; }    // FK to Device
        public AttributeNameOpt a_name { get; set; }
        public string a_description { get; set; }
        public bool is_active { get; set; }
        [DataType(DataType.Date)]
        public DateTime? active_date { get; set; }
        [DataType(DataType.Date)]
        public DateTime?/*string*/ last_update { get; set; }
        public List<Data> data_values { get; set; } //An Device Attribue (1) - recive - (n) data values
        public Device device { get; set; } // n - 1 to Device
    }
}
