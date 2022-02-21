using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebAPI.DTOs
{
    public class CreateDeviceRequest
    {
        public string device_name { get; set; }
        public string device_description { get; set; }
        public string img_url { get; set; }
        //Atributes
        public string a_des_temp { get; set; }
        public bool temp_is_active { get; set; }
        public string a_des_humi { get; set; }
        public bool humi_is_active { get; set; }
        public string a_des_pres { get; set; }
        public bool pres_is_active { get; set; }
        public string a_des_brin { get; set; }
        public bool brin_is_active { get; set; }
    }
}
