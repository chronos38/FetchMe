namespace FetchMe.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Trainer = c.String(),
                        Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.Team_Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Minutes = c.Int(nullable: false),
                        Score_Id = c.Int(),
                        Team1_Id = c.Int(),
                        Team2_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Scores", t => t.Score_Id)
                .ForeignKey("dbo.GameDatas", t => t.Team1_Id)
                .ForeignKey("dbo.GameDatas", t => t.Team2_Id)
                .Index(t => t.Score_Id)
                .Index(t => t.Team1_Id)
                .Index(t => t.Team2_Id);
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score1 = c.Int(nullable: false),
                        Score2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Goals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Minute = c.Int(nullable: false),
                        Goalscrorer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TeamMembers", t => t.Goalscrorer_Id)
                .Index(t => t.Goalscrorer_Id);
            
            CreateTable(
                "dbo.TeamMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.Team_Id);
            
            CreateTable(
                "dbo.Replacements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Minute = c.Int(nullable: false),
                        In_Id = c.Int(),
                        Out_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TeamMembers", t => t.In_Id)
                .ForeignKey("dbo.TeamMembers", t => t.Out_Id)
                .Index(t => t.In_Id)
                .Index(t => t.Out_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Replacements", "Out_Id", "dbo.TeamMembers");
            DropForeignKey("dbo.Replacements", "In_Id", "dbo.TeamMembers");
            DropForeignKey("dbo.Goals", "Goalscrorer_Id", "dbo.TeamMembers");
            DropForeignKey("dbo.TeamMembers", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Games", "Team2_Id", "dbo.GameDatas");
            DropForeignKey("dbo.Games", "Team1_Id", "dbo.GameDatas");
            DropForeignKey("dbo.Games", "Score_Id", "dbo.Scores");
            DropForeignKey("dbo.GameDatas", "Team_Id", "dbo.Teams");
            DropIndex("dbo.Replacements", new[] { "Out_Id" });
            DropIndex("dbo.Replacements", new[] { "In_Id" });
            DropIndex("dbo.TeamMembers", new[] { "Team_Id" });
            DropIndex("dbo.Goals", new[] { "Goalscrorer_Id" });
            DropIndex("dbo.Games", new[] { "Team2_Id" });
            DropIndex("dbo.Games", new[] { "Team1_Id" });
            DropIndex("dbo.Games", new[] { "Score_Id" });
            DropIndex("dbo.GameDatas", new[] { "Team_Id" });
            DropTable("dbo.Replacements");
            DropTable("dbo.TeamMembers");
            DropTable("dbo.Goals");
            DropTable("dbo.Scores");
            DropTable("dbo.Games");
            DropTable("dbo.Teams");
            DropTable("dbo.GameDatas");
        }
    }
}
