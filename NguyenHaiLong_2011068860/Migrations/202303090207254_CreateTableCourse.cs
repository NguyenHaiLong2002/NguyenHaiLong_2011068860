namespace NguyenHaiLong_2011068860.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Place = c.String(nullable: false, maxLength: 255),
                        dateTime = c.DateTime(nullable: false),
                        categoryId = c.Byte(nullable: false),
                        Lecturer_Id = c.String(maxLength: 128),
                        LecturerId_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.categoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Lecturer_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.LecturerId_Id, cascadeDelete: true)
                .Index(t => t.categoryId)
                .Index(t => t.Lecturer_Id)
                .Index(t => t.LecturerId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "LecturerId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "Lecturer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "categoryId", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "LecturerId_Id" });
            DropIndex("dbo.Courses", new[] { "Lecturer_Id" });
            DropIndex("dbo.Courses", new[] { "categoryId" });
            DropTable("dbo.Courses");
            DropTable("dbo.Categories");
        }
    }
}
