namespace Evaluation.ORM.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Evaluation.ORM.ContextBDD>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Evaluation.ORM.ContextBDD context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Intervenants.AddOrUpdate(new Intervenant()
            {
                Matricule = 1,
                Nom = "Nicolas",
                Prenom = "Bern"
            });

            context.Véhicules.AddOrUpdate(new Véhicule()
            {
                VéhiculeID = 1,
                Marque = "Renault",
                Modèle = "Kangoo",
                Immatriculation = "JK-084-LS",
                Volume = 50,
                Dispo = true
            });

            context.Matériels.AddOrUpdate(new Matériel()
            {
                MatérielID = 1,
                Désignation = "Tournevis",
                Description = "Cruxiforme",
                DateAchat = DateTime.Now,
                Dispo = true
            });

            context.Matériels.AddOrUpdate(new Matériel()
            {
                MatérielID = 2,
                Désignation = "Perceuse",
                Description = "Efficace",
                DateAchat = DateTime.Now,
                Dispo = true
            });
        }
    }
}
