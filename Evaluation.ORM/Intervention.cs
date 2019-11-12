using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.ORM
{
    public class Intervention
    {
        public Intervention()
        {
            Matériels = new List<Matériel>();
        }

        [Key]
        public int InterventionID { get; set; }

        [Required]
        public DateTime DateDebut { get; set; }

        [Required]
        public DateTime? DateFin { get; set; }

        public virtual Intervenant Intervenant { get; set; }
        public virtual Véhicule Véhicule { get; set; }
        public virtual ICollection<Matériel> Matériels { get; set; }
    }
}
