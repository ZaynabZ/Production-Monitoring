using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductionMonitoringV1.Models
{
    public class Billette
    {
        public int Id { get; set; }
        public int IdCoulee { get; set; }

        public string Nuance { get; set; }
        public float Longueur { get; set; }
        public float Diametre { get; set; }
        public float PoidsMoyen { get; set; }
        public DateTime DateUtilisation { get; set; }
        public bool IsValid { get; set; }
    }
}