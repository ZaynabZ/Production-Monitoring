namespace ProductionMonitoringV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassesToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Billettes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCoulee = c.Int(nullable: false),
                        Nuance = c.String(),
                        Longueur = c.Single(nullable: false),
                        Diametre = c.Single(nullable: false),
                        PoidsMoyen = c.Single(nullable: false),
                        DateUtilisation = c.DateTime(nullable: false),
                        IsValid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Coulees",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Marquage = c.String(),
                        NombreBillettes = c.Int(nullable: false),
                        NbrBillUtilise = c.Int(nullable: false),
                        DateReception = c.DateTime(nullable: false),
                        Expedition_Id = c.Int(),
                        Fournisseur_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Expeditions", t => t.Expedition_Id)
                .ForeignKey("dbo.Fournisseurs", t => t.Fournisseur_Id)
                .Index(t => t.Expedition_Id)
                .Index(t => t.Fournisseur_Id);
            
            CreateTable(
                "dbo.Expeditions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumeroExpedition = c.String(),
                        Moyenexpedition = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fournisseurs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Origine = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Username = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Role_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .Index(t => t.Role_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Coulees", "Fournisseur_Id", "dbo.Fournisseurs");
            DropForeignKey("dbo.Coulees", "Expedition_Id", "dbo.Expeditions");
            DropIndex("dbo.Users", new[] { "Role_Id" });
            DropIndex("dbo.Coulees", new[] { "Fournisseur_Id" });
            DropIndex("dbo.Coulees", new[] { "Expedition_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Fournisseurs");
            DropTable("dbo.Expeditions");
            DropTable("dbo.Coulees");
            DropTable("dbo.Billettes");
        }
    }
}
