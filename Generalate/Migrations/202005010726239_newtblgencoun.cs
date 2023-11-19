namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtblgencoun : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GeneralCouncils",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FromDate = c.String(maxLength: 150),
                        ToDate = c.String(maxLength: 150),
                        SuperiorGeneral = c.String(),
                        Designation1 = c.String(),
                        AsstSuperiorGeneral = c.String(),
                        Designation2 = c.String(),
                        CouncillorSprituality = c.String(),
                        Designation3 = c.String(),
                        CouncillorFormation = c.String(),
                        Designation4 = c.String(),
                        CouncillorEducation = c.String(),
                        Designation5 = c.String(),
                        CouncillorSocApo = c.String(),
                        Designation6 = c.String(),
                        SecretaryGeneral = c.String(),
                        Designation7 = c.String(),
                        BursarGeneral = c.String(),
                        Designation8 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GeneralCouncils");
        }
    }
}
