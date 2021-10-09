namespace BELibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Status_To_StudentTest_Table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lecture", "TestTitle", c => c.String());
            AddColumn("dbo.StudentTest", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.StudentTest", "Point", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentTest", "Point", c => c.Int());
            DropColumn("dbo.StudentTest", "Status");
            DropColumn("dbo.Lecture", "TestTitle");
        }
    }
}
