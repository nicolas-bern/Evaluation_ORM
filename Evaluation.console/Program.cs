using Evaluation.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ContextBDD())
            {
                var intervenant = db.Intervenants.First(c => c.Matricule == 1);
                var véhicule = db.Véhicules.First(c => c.VéhiculeID == 1);
                var tournevis = db.Matériels.First(c => c.MatérielID == 1);
                var perceuse = db.Matériels.First(c => c.MatérielID == 2);

                var intervention = new Intervention
                {
                    DateDebut = DateTime.Now,
                    Intervenant = intervenant,
                    Véhicule = véhicule,
                };

                intervention.Matériels.Add(tournevis);
                intervention.Matériels.Add(perceuse);

                db.SaveChanges();
            }
        }
    }
}
