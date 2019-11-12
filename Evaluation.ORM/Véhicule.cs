using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.ORM
{
    public class Véhicule
    {
        public Véhicule()
        {
            Interventions = new List<Intervention>();
        }

        [Key]
        public int VéhiculeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Marque { get; set; }

        [Required]
        [StringLength(50)]
        public string Modèle { get; set; }

        [Required]
        public string Immatriculation { get; set; }

        public float Volume { get; set; }

        public bool Dispo { get; set; }

        public virtual ICollection<Intervention> Interventions { get; set; }
    }
}
