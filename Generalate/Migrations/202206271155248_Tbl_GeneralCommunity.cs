namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_GeneralCommunity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_GeneralCommunity",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        GenCommId = c.String(),
                        CongregationName = c.String(),
                        CommCode = c.String(),
                        GenCode = c.String(),
                        Place = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Country = c.String(),
                        EmailId = c.String(),
                        DisSec = c.String(),
                        ActiveCkeck = c.String(),
                        CreatedDate = c.String(),
                        Enterby = c.String(),
                        EnterbyName = c.String(),
                        EnterbyId = c.String(),
                        ProvinceName = c.String(maxLength: 550),
                        File = c.String(),
                        Vission = c.String(),
                        Mission = c.String(),
                        Activities = c.String(),
                        Diocese = c.String(),
                        PostalCode = c.String(),
                        Enitity = c.String(),
                        Continent = c.String(),
                        CommunityType = c.String(),
                        Status = c.Int(nullable: false),
                        StartDate = c.String(),
                        EndDate = c.String(),
                        SuspensionDate = c.String(),
                        RestartDate = c.String(),
                        Remark = c.String(),
                        History = c.String(),
                        Remarks = c.String(),
                        IsStatisticActive = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tbl_GeneralCommunity");
        }
    }
}
