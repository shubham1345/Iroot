namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InstutionAppointments_Newtablecreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InstutionAppointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.String(maxLength: 150),
                        CongId = c.String(maxLength: 150),
                        Title = c.String(maxLength: 150),
                        Name = c.String(maxLength: 150),
                        Date = c.String(maxLength: 150),
                        FromDate = c.String(maxLength: 150),
                        ToDate = c.String(maxLength: 150),
                        doc = c.String(maxLength: 1000),
                        Description = c.String(),
                        AppointmentType = c.String(maxLength: 500),
                        drpNameType = c.String(maxLength: 100),
                        DesignationType = c.String(maxLength: 1500),
                        InstitutionType = c.String(maxLength: 500),
                        CommunityType = c.String(maxLength: 500),
                        Superior = c.String(maxLength: 150),
                        ParisData = c.String(),
                        Diocese = c.String(),
                        OSProvince = c.String(),
                        OSCongName = c.String(),
                        OSCongProvince = c.String(),
                        ProvinceName = c.String(maxLength: 550),
                        SGGeneralate = c.String(maxLength: 200),
                        InsDesignationType = c.String(),
                        OptionGuid = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.String(),
                        UpdateBy = c.String(),
                        UpdateDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InstutionAppointments");
        }
    }
}
