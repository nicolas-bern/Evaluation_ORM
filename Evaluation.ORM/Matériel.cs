using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.ORM
{
    public class Matériel
    {
        public Matériel()
        {
            Interventions = new List<Intervention>();
        }

        [Key]
        public int MatérielID { get; set; }

        public string Désignation { get; set; }

        public string Description { get; set; }

        public DateTime DateAchat { get; set; }

        public bool Dispo { get; set; }


        public virtual ICollection<Intervention> Interventions { get; set; }
    }
}
