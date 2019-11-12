using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.ORM
{
    public class Administrator
    {
        public Administrator()
        {
            Intervenants = new List<Intervenant>();
            Véhicules = new List<Véhicule>();
            Matériels = new List<Matériel>();
        }

        [Key]
        public int ID { get; set; }


        public virtual ICollection<Intervenant> Intervenants { get; set; }
        public virtual ICollection<Véhicule> Véhicules { get; set; }
        public virtual ICollection<Matériel> Matériels { get; set; }
    }
}
