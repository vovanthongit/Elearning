namespace BELibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_Gender_User_Table : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Gender", c => c.Boolean(nullable: false));
        }
    }
}
