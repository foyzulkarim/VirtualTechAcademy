namespace ZooApp.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnimalUnique : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Animals", "Ix_AnimalName");
            CreateIndex("dbo.Animals", "Name", unique: true, name: "Ix_AnimalName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Animals", "Ix_AnimalName");
            CreateIndex("dbo.Animals", "Name", name: "Ix_AnimalName");
        }
    }
}
