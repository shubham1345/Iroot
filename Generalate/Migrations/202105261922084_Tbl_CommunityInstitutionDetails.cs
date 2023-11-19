namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_CommunityInstitutionDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_CommunityGallery",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MainID = c.String(),
                        Title = c.String(),
                        FileName = c.String(),
                        IsActive = c.Int(),
                        CreatedBy = c.String(),
                        CreatedDate = c.String(),
                        UpdateBy = c.String(),
                        UpdateDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_CommunityInstitutionDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActiveCkeck = c.String(),
                        MyId = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        Place = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        History = c.String(),
                        Remark = c.String(),
                        Remarks = c.String(),
                        Type = c.String(maxLength: 50),
                        Enterby = c.String(),
                        EnterbyName = c.String(),
                        EnterbyId = c.String(),
                        YearOfEstablacement = c.String(maxLength: 50),
                        Address = c.String(),
                        FileName = c.String(maxLength: 100),
                        ParisId = c.String(maxLength: 100),
                        Activities = c.String(),
                        Diocese = c.String(),
                        SocietyId = c.String(maxLength: 100),
                        Vission = c.String(),
                        Mission = c.String(),
                        Telephone = c.String(maxLength: 100),
                        InstitutionType = c.String(maxLength: 20),
                        TypesOfReg = c.String(maxLength: 320),
                        RegistrationNo = c.String(maxLength: 100),
                        DiscCode = c.String(maxLength: 50),
                        TypeCode = c.String(maxLength: 50),
                        RegIdCode = c.String(maxLength: 50),
                        BEORegCode = c.String(maxLength: 50),
                        CertificationCode = c.String(maxLength: 50),
                        OtherDoc = c.String(maxLength: 50),
                        Doc1 = c.String(maxLength: 50),
                        Doc2 = c.String(maxLength: 50),
                        CreatedDate = c.String(maxLength: 50),
                        Tial = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        StartDate = c.String(maxLength: 50),
                        CloseDate = c.String(maxLength: 50),
                        SuspensionDate = c.String(maxLength: 50),
                        RestartDate = c.String(maxLength: 50),
                        Description = c.String(maxLength: 50),
                        Country = c.String(maxLength: 50),
                        EmailId = c.String(maxLength: 50),
                        PostalCode = c.String(maxLength: 50),
                        Status = c.String(maxLength: 50),
                        Enitity = c.String(maxLength: 50),
                        CommunityType = c.String(maxLength: 50),
                        Continent = c.String(maxLength: 50),
                        CommId = c.String(maxLength: 50),
                        CongregationName = c.String(maxLength: 150),
                        CommCode = c.String(maxLength: 150),
                        DisSec = c.String(maxLength: 150),
                        ProvinceName = c.String(maxLength: 550),
                        CreatedBy = c.String(),
                        UpdateBy = c.String(),
                        UpdateDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblCommunityImportantDates",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MainID = c.String(),
                        Name = c.String(),
                        Day = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        IsActive = c.Int(),
                        CreatedBy = c.String(),
                        CreatedDate = c.String(),
                        UpdateBy = c.String(),
                        UpdateDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblCommunityImportantDates");
            DropTable("dbo.Tbl_CommunityInstitutionDetails");
            DropTable("dbo.tbl_CommunityGallery");
        }
    }
}
