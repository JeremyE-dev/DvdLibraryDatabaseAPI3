namespace DvdLibraryDatabaseAPI3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        DirectorId = c.Int(nullable: false, identity: true),
                        director = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.DirectorId);
            
            CreateTable(
                "dbo.Dvds",
                c => new
                    {
                        DvdId = c.Int(nullable: false, identity: true),
                        DirectorId = c.Int(nullable: true),
                        RatingId = c.Int(nullable: true),
                        ReleaseYearId = c.Int(nullable: true),
                        Title = c.String(maxLength: 100),
                        Notes = c.String(),
                        releaseYear = c.Int(nullable: true),
                        director = c.String(),
                        rating = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.DvdId)
                .ForeignKey("dbo.Directors", t => t.DirectorId)
                .ForeignKey("dbo.Ratings", t => t.RatingId)
                .ForeignKey("dbo.ReleaseYears", t => t.ReleaseYearId)
                .Index(t => t.DirectorId)
                .Index(t => t.RatingId)
                .Index(t => t.ReleaseYearId);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        rating = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RatingId);
            
            CreateTable(
                "dbo.ReleaseYears",
                c => new
                    {
                        ReleaseYearId = c.Int(nullable: false, identity: true),
                        releaseYear = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.ReleaseYearId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dvds", "ReleaseYearId", "dbo.ReleaseYears");
            DropForeignKey("dbo.Dvds", "RatingId", "dbo.Ratings");
            DropForeignKey("dbo.Dvds", "DirectorId", "dbo.Directors");
            DropIndex("dbo.Dvds", new[] { "ReleaseYearId" });
            DropIndex("dbo.Dvds", new[] { "RatingId" });
            DropIndex("dbo.Dvds", new[] { "DirectorId" });
            DropTable("dbo.ReleaseYears");
            DropTable("dbo.Ratings");
            DropTable("dbo.Dvds");
            DropTable("dbo.Directors");
        }
    }
}
