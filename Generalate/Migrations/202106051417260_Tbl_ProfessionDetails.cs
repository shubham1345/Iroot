namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_ProfessionDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_CommunityAppointmentDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataListName = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        Designation = c.String(maxLength: 50),
                        Institution = c.String(maxLength: 50),
                        FormationId = c.String(),
                        Community = c.String(maxLength: 50),
                        Continent = c.String(),
                        Address = c.String(maxLength: 200),
                        ProvinceName = c.String(maxLength: 550),
                        CreatedBy = c.String(),
                        CreatedDate = c.String(),
                        UpdateBy = c.String(),
                        UpdateDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_InstitutionAppointmentDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataListName = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        Designation = c.String(maxLength: 50),
                        Institution = c.String(maxLength: 50),
                        FormationId = c.String(),
                        Community = c.String(maxLength: 50),
                        Continent = c.String(),
                        Address = c.String(maxLength: 200),
                        ProvinceName = c.String(maxLength: 550),
                        CreatedBy = c.String(),
                        CreatedDate = c.String(),
                        UpdateBy = c.String(),
                        UpdateDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_ProfessionDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataListName = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        Designation = c.String(maxLength: 50),
                        Institution = c.String(maxLength: 50),
                        FormationId = c.String(),
                        Community = c.String(maxLength: 50),
                        Continent = c.String(),
                        Address = c.String(maxLength: 200),
                        ProvinceName = c.String(maxLength: 550),
                        CreatedBy = c.String(),
                        CreatedDate = c.String(),
                        UpdateBy = c.String(),
                        UpdateDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tbl_ProfessionDetails");
            DropTable("dbo.Tbl_InstitutionAppointmentDetails");
            DropTable("dbo.Tbl_CommunityAppointmentDetails");
        }
    }
}
