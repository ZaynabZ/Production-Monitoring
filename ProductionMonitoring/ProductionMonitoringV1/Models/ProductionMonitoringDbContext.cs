using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductionMonitoringV1.Models
{
    public class ProductionMonitoringDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Billette> Billettes { get; set; }
        public DbSet<Coulee> Coulees { get; set; }
        public DbSet<Expedition> Expeditions { get; set; }
        public DbSet<Fournisseur> Fournisseurs { get; set; }



    }
}