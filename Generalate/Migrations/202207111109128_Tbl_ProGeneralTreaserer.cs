namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_ProGeneralTreaserer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_ProGeneralTreaserer",
                c => new
                    {
                        ProvTreaserer_Id = c.Int(nullable: false, identity: true),
                        GenId = c.String(maxLength: 150),
                        GenName = c.String(),
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
                        Name = c.String(),
                        Designation = c.String(),
                        Responsibility = c.String(),
                        DataListItemsId = c.Int(nullable: false),
                        PersonalDetailsId = c.Long(),
                        ProvinceId = c.String(maxLength: 150),
                        Status = c.String(),
                        Mandate = c.String(),
                        MissionCountry = c.String(),
                    })
                .PrimaryKey(t => t.ProvTreaserer_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tbl_ProGeneralTreaserer");
        }
    }
}
