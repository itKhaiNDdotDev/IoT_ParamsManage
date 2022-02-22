using IoTWebAPI.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebAPI.DTOs.Devices
{
    public class ActiveDvAttributeRequset
    {
        public AttributeNameOpt a_name { get; set; }
        public string a_description { get; set; }
        public bool is_active { get; set; }
    }
}
