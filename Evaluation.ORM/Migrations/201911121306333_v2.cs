namespace Evaluation.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Interventions",
                c => new
                    {
                        InterventionID = c.Int(nullable: false, identity: true),
                        Intervenant_Matricule = c.Int(),
                        Véhicule_VéhiculeID = c.Int(),
                    })
                .PrimaryKey(t => t.InterventionID)
                .ForeignKey("dbo.Intervenants", t => t.Intervenant_Matricule)
                .ForeignKey("dbo.Véhicule", t => t.Véhicule_VéhiculeID)
                .Index(t => t.Intervenant_Matricule)
                .Index(t => t.Véhicule_VéhiculeID);
            
            CreateTable(
                "dbo.MatérielIntervention",
                c => new
                    {
                        Matériel_MatérielID = c.Int(nullable: false),
                        Intervention_InterventionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Matériel_MatérielID, t.Intervention_InterventionID })
                .ForeignKey("dbo.Matériel", t => t.Matériel_MatérielID, cascadeDelete: true)
                .ForeignKey("dbo.Interventions", t => t.Intervention_InterventionID, cascadeDelete: true)
                .Index(t => t.Matériel_MatérielID)
                .Index(t => t.Intervention_InterventionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Interventions", "Véhicule_VéhiculeID", "dbo.Véhicule");
            DropForeignKey("dbo.MatérielIntervention", "Intervention_InterventionID", "dbo.Interventions");
            DropForeignKey("dbo.MatérielIntervention", "Matériel_MatérielID", "dbo.Matériel");
            DropForeignKey("dbo.Interventions", "Intervenant_Matricule", "dbo.Intervenants");
            DropIndex("dbo.MatérielIntervention", new[] { "Intervention_InterventionID" });
            DropIndex("dbo.MatérielIntervention", new[] { "Matériel_MatérielID" });
            DropIndex("dbo.Interventions", new[] { "Véhicule_VéhiculeID" });
            DropIndex("dbo.Interventions", new[] { "Intervenant_Matricule" });
            DropTable("dbo.MatérielIntervention");
            DropTable("dbo.Interventions");
        }
    }
}
