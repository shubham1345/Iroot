namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addednewtbls : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_ComOSInstitute",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ComOsId = c.String(),
                        MyId = c.String(),
                        ComOsName = c.String(),
                        Email = c.String(),
                        MobileNo = c.String(),
                        Address = c.String(),
                        File = c.String(),
                        CreatedDate = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tbl_DioceseInst",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DioId = c.String(),
                        MyId = c.String(),
                        DioName = c.String(),
                        Email = c.String(),
                        MobileNo = c.String(),
                        Address = c.String(),
                        File = c.String(),
                        CreatedDate = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tbl_DistSecCouncil",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DistSecNameName = c.String(maxLength: 150),
                        DistSecId = c.String(maxLength: 150),
                        Superior = c.String(maxLength: 150),
                        SuperiorDes = c.String(maxLength: 150),
                        AssSuperior = c.String(maxLength: 150),
                        AssSuperiorDes = c.String(maxLength: 150),
                        CouncilorName = c.String(maxLength: 150),
                        CouncilorDes = c.String(maxLength: 150),
                        CouncilorName1 = c.String(maxLength: 150),
                        Councilor1Des = c.String(maxLength: 150),
                        CouncilorName2 = c.String(maxLength: 150),
                        Councilor2Des = c.String(maxLength: 150),
                        CouncilorName3 = c.String(maxLength: 150),
                        Councilor3Des = c.String(maxLength: 150),
                        FromDate = c.String(maxLength: 150),
                        ToDate = c.String(maxLength: 150),
                        ComMemName = c.String(maxLength: 150),
                        ComMemDes = c.String(maxLength: 150),
                        ComMemName1 = c.String(maxLength: 150),
                        ComMemDes1 = c.String(maxLength: 150),
                        ComMemName2 = c.String(maxLength: 150),
                        ComMemDes2 = c.String(maxLength: 150),
                        Secretory = c.String(maxLength: 150),
                        SecretoryDes = c.String(maxLength: 150),
                        Bursar = c.String(maxLength: 150),
                        BursarDes = c.String(maxLength: 150),
                        History = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_DistSector",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MyId = c.String(),
                        DistSecName = c.String(),
                        Place = c.String(),
                        Place1 = c.String(),
                        ActiveCkeck = c.String(),
                        Phone = c.String(),
                        Country = c.String(),
                        EmailId = c.String(),
                        History = c.String(),
                        CreatedDate = c.String(),
                        DisSec = c.String(),
                        File = c.String(),
                        Vission = c.String(),
                        Mission = c.String(),
                        Activities = c.String(),
                        Diocese = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_DistSectorData",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DistId = c.String(),
                        MyId = c.String(),
                        Title = c.String(),
                        Date = c.String(),
                        Description = c.String(),
                        File = c.String(),
                        CreatedDate = c.String(),
                        DistSecName = c.String(maxLength: 550),
                        ActiveCkeck = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Tbl_Cong", "GenCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_Cong", "GenCode");
            DropTable("dbo.tbl_DistSectorData");
            DropTable("dbo.tbl_DistSector");
            DropTable("dbo.tbl_DistSecCouncil");
            DropTable("dbo.tbl_DioceseInst");
            DropTable("dbo.tbl_ComOSInstitute");
        }
    }
}
