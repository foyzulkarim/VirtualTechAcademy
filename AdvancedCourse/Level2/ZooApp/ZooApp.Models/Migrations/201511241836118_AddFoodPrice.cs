namespace ZooApp.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFoodPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foods", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.AnimalFoods", "Quantity", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AnimalFoods", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.Foods", "Price");
        }
    }
}
