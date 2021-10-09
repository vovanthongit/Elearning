namespace BELibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init_Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Username = c.String(nullable: false, maxLength: 50, unicode: false),
                        LectureId = c.Int(nullable: false),
                        ReplyId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lecture", t => t.LectureId)
                .ForeignKey("dbo.User", t => t.Username)
                .Index(t => t.Username)
                .Index(t => t.LectureId);
            
            CreateTable(
                "dbo.Lecture",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        SubjectId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 50, unicode: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false, maxLength: 50, unicode: false),
                        UrlVideo = c.String(nullable: false, maxLength: 250, unicode: false),
                        TimeVideo = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Content = c.String(),
                        Image = c.String(maxLength: 250, unicode: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 50, unicode: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false, maxLength: 50, unicode: false),
                        NumberStudent = c.Int(nullable: false),
                        MaxStudent = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Description = c.String(nullable: false, maxLength: 300),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LanguageId = c.String(nullable: false, maxLength: 2, unicode: false),
                        Name = c.String(nullable: false, maxLength: 500),
                        Image = c.String(maxLength: 250, unicode: false),
                        Description = c.String(nullable: false, maxLength: 300),
                        Content = c.String(nullable: false),
                        Benefits = c.String(maxLength: 1000),
                        Requirements = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 50, unicode: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false, maxLength: 50, unicode: false),
                        Status = c.Boolean(nullable: false),
                        TopHot = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rating",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Point = c.Double(nullable: false),
                        Username = c.String(nullable: false, maxLength: 50, unicode: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Document",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        UrlDocument = c.String(nullable: false, maxLength: 5000, unicode: false),
                        SubjectId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 50, unicode: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.StudentSubject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50, unicode: false),
                        SubjectId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ApproveName = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.Username)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .Index(t => t.Username)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 100, unicode: false),
                        Status = c.Boolean(nullable: false),
                        RoleId = c.Int(nullable: false),
                        FullName = c.String(nullable: false, maxLength: 250),
                        Email = c.String(nullable: false, maxLength: 250, unicode: false),
                        Phone = c.String(maxLength: 50, unicode: false),
                        IsLocked = c.Boolean(nullable: false),
                        LinkAvata = c.String(maxLength: 250, unicode: false),
                        DateOfBirth = c.DateTime(nullable: false, storeType: "date"),
                        Gender = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.TeacherSubject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50, unicode: false),
                        SubjectId = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false, storeType: "date"),
                        FinishTime = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.Username)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .Index(t => t.Username)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.StudentTest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileAnswer = c.String(maxLength: 250, unicode: false),
                        ReplyFile = c.String(nullable: false, maxLength: 250, unicode: false),
                        SubjectId = c.Int(nullable: false),
                        Point = c.Int(),
                        Email = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherSubject", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.StudentTest", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.StudentSubject", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.TeacherSubject", "Username", "dbo.User");
            DropForeignKey("dbo.StudentSubject", "Username", "dbo.User");
            DropForeignKey("dbo.Comment", "Username", "dbo.User");
            DropForeignKey("dbo.Lecture", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Document", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Subject", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Rating", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Comment", "LectureId", "dbo.Lecture");
            DropIndex("dbo.StudentTest", new[] { "SubjectId" });
            DropIndex("dbo.TeacherSubject", new[] { "SubjectId" });
            DropIndex("dbo.TeacherSubject", new[] { "Username" });
            DropIndex("dbo.StudentSubject", new[] { "SubjectId" });
            DropIndex("dbo.StudentSubject", new[] { "Username" });
            DropIndex("dbo.Document", new[] { "SubjectId" });
            DropIndex("dbo.Rating", new[] { "CourseId" });
            DropIndex("dbo.Subject", new[] { "CourseId" });
            DropIndex("dbo.Lecture", new[] { "SubjectId" });
            DropIndex("dbo.Comment", new[] { "LectureId" });
            DropIndex("dbo.Comment", new[] { "Username" });
            DropTable("dbo.Role");
            DropTable("dbo.StudentTest");
            DropTable("dbo.TeacherSubject");
            DropTable("dbo.User");
            DropTable("dbo.StudentSubject");
            DropTable("dbo.Document");
            DropTable("dbo.Rating");
            DropTable("dbo.Course");
            DropTable("dbo.Subject");
            DropTable("dbo.Lecture");
            DropTable("dbo.Comment");
        }
    }
}
