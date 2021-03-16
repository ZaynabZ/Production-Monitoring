using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductionMonitoringV1.Models
{
    public class Coulee
    {
        public string Id { get; set; }
        public Fournisseur Fournisseur { get; set; }
        public string Marquage { get; set; }
        public int NombreBillettes { get; set; }
        public int NbrBillUtilise { get; set; }
        public Expedition Expedition { get; set; }
        public DateTime DateReception { get; set; }


    }
}