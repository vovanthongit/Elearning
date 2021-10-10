namespace BELibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_tableQuestion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContentQuestion = c.String(),
                        AnswerA = c.String(),
                        AnswerB = c.String(),
                        AnswerC = c.String(),
                        AnswerD = c.String(),
                        TypeQuestion = c.Int(nullable: false),
                        Note = c.String(),
                        AddedTimestamp = c.DateTime(),
                        AddedUserId = c.String(),
                        ChangedTimestamp = c.DateTime(),
                        ChangedUserId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Question");
        }
    }
}
