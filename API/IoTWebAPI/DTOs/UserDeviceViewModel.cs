﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebAPI.DTOs
{
    public class UserDeviceViewModel
    {
        public int d_id { get; set; }
        public string device_name { get; set; }
        public string device_description { get; set; }
        public string img_url { get; set; }
        [DataType(DataType.Date)]
        public DateTime create_date { get; set; }
        //Attributes
    }
}
