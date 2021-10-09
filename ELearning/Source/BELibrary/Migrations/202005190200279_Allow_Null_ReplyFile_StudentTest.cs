namespace BELibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Allow_Null_ReplyFile_StudentTest : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentTest", "ReplyFile", c => c.String(maxLength: 250, unicode: false));
            DropColumn("dbo.StudentTest", "StudentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentTest", "StudentId", c => c.Int(nullable: false));
            AlterColumn("dbo.StudentTest", "ReplyFile", c => c.String(nullable: false, maxLength: 250, unicode: false));
        }
    }
}
