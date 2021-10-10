namespace BELibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_tableExam : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExamHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        LectureId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        TypeQuestion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExamResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        LectureId = c.Int(nullable: false),
                        Point = c.Int(nullable: false),
                        ExamTime = c.DateTime(),
                        TestDay = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Question", "LectureId", c => c.Int(nullable: false));
            CreateIndex("dbo.Question", "LectureId");
            AddForeignKey("dbo.Question", "LectureId", "dbo.Lecture", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Question", "LectureId", "dbo.Lecture");
            DropIndex("dbo.Question", new[] { "LectureId" });
            DropColumn("dbo.Question", "LectureId");
            DropTable("dbo.ExamResults");
            DropTable("dbo.ExamHistories");
        }
    }
}
