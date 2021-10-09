namespace BELibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_LectureId_To_StudentTest_Table : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentTest", "SubjectId", "dbo.Subject");
            DropIndex("dbo.StudentTest", new[] { "SubjectId" });
            AddColumn("dbo.Lecture", "IsTest", c => c.Boolean(nullable: false));
            AddColumn("dbo.Lecture", "FileTest", c => c.String());
            AddColumn("dbo.StudentTest", "LectureId", c => c.Int(nullable: false));
            AddColumn("dbo.StudentTest", "StudentId", c => c.Int(nullable: false));
            AddColumn("dbo.StudentTest", "Username", c => c.String(maxLength: 50, unicode: false));
            CreateIndex("dbo.StudentTest", "LectureId");
            CreateIndex("dbo.StudentTest", "Username");
            AddForeignKey("dbo.StudentTest", "LectureId", "dbo.Lecture", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentTest", "Username", "dbo.User", "Username");
            DropColumn("dbo.StudentTest", "SubjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentTest", "SubjectId", c => c.Int(nullable: false));
            DropForeignKey("dbo.StudentTest", "Username", "dbo.User");
            DropForeignKey("dbo.StudentTest", "LectureId", "dbo.Lecture");
            DropIndex("dbo.StudentTest", new[] { "Username" });
            DropIndex("dbo.StudentTest", new[] { "LectureId" });
            DropColumn("dbo.StudentTest", "Username");
            DropColumn("dbo.StudentTest", "StudentId");
            DropColumn("dbo.StudentTest", "LectureId");
            DropColumn("dbo.Lecture", "FileTest");
            DropColumn("dbo.Lecture", "IsTest");
            CreateIndex("dbo.StudentTest", "SubjectId");
            AddForeignKey("dbo.StudentTest", "SubjectId", "dbo.Subject", "Id");
        }
    }
}
