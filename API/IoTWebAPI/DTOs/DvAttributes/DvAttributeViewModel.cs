//using IoTWebAPI.Models.Enums;   //CO THE BO
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebAPI.DTOs.DvAttributes
{
    public class DvAttributeViewModel
    {
        //int temp_id { get; set; }
        //public string temp_description { get; set; }
        //public bool temp_is_active { get; set; }
        //[DataType(DataType.Date)]
        //public DateTime? temp_active_date { get; set; }
        //[DataType(DataType.Date)]
        //public DateTime?/*string*/ temp_last_update { get; set; }
        public int a_id { get; set; }
        public /*AttributeNameOpt*/string a_name { get; set; }    //sring thi bo using di kia
        public string a_description { get; set; }
        public bool a_is_active { get; set; }
        //[DataType(DataType.Date)]
        public /*DateTime?*/string a_active_date { get; set; }
        [DataType(DataType.Date)]
        public DateTime?/*string*/ a_last_update { get; set; }
    }
}
