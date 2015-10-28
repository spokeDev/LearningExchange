using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSWebApi.Models
{
    public class Citation
    {
        public int ID { get; set; }
        public string CitationNumber { get; set; }
        public string PlateNumber { get; set; }
        public Person Driver { get; set; }
        public string ViolationCode { get; set; }
        public int Speed { get; set; }
        public int SpeedZone { get; set; }
        public DateTime ViolationDateTime { get; set; }
        public decimal Fine { get; set; }
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }
}