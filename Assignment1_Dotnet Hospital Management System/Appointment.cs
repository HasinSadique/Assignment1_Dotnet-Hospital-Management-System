using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment1_Dotnet_Hospital_Management_System
{
    public class Appointment
    {

        [JsonPropertyName("A_ID")]
        public  int A_ID { get; set; }
        [JsonPropertyName("P_ID")]
        public  int P_ID { get; set; }
        [JsonPropertyName("D_ID")]
        public  int D_ID { get; set; }
        [JsonPropertyName("Patient_Name")]
        public  string Patient_Name { get; set; }

        [JsonPropertyName("Doctor_Name")]
        public  string Doctor_Name { get; set; }
        [JsonPropertyName("Description")]
        public  string Description { get; set; }

        public Appointment() { }
        public string ToString()
        {
            return $"{A_ID,-15} | {Patient_Name,-20} | {Doctor_Name,-20} | {Description,-60}";
        }
    }
}
