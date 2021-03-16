namespace ProductionMonitoringV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyFournisseurIdType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Coulees", "Fournisseur_Id", "dbo.Fournisseurs");
            DropIndex("dbo.Coulees", new[] { "Fournisseur_Id" });
            DropPrimaryKey("dbo.Fournisseurs");
            AlterColumn("dbo.Coulees", "Fournisseur_Id", c => c.Int());
            AlterColumn("dbo.Fournisseurs", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Fournisseurs", "Id");
            CreateIndex("dbo.Coulees", "Fournisseur_Id");
            AddForeignKey("dbo.Coulees", "Fournisseur_Id", "dbo.Fournisseurs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Coulees", "Fournisseur_Id", "dbo.Fournisseurs");
            DropIndex("dbo.Coulees", new[] { "Fournisseur_Id" });
            DropPrimaryKey("dbo.Fournisseurs");
            AlterColumn("dbo.Fournisseurs", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Coulees", "Fournisseur_Id", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Fournisseurs", "Id");
            CreateIndex("dbo.Coulees", "Fournisseur_Id");
            AddForeignKey("dbo.Coulees", "Fournisseur_Id", "dbo.Fournisseurs", "Id");
        }
    }
}
