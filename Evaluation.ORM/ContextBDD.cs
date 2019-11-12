using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.ORM
{
    public class ContextBDD : DbContext
    {
        public ContextBDD() : base("ChaineDeConnexion")
        {

        }

        public virtual DbSet<Intervenant> Intervenants { get; set; }
        public virtual DbSet<Véhicule> Véhicules { get; set; }
        public virtual DbSet<Matériel> Matériels { get; set; }
        public virtual DbSet<Intervention> Interventions { get; set; }
        public virtual DbSet<Administrator> Administrators { get; set; }
    }
}
