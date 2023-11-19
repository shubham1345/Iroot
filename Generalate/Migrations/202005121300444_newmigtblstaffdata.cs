namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigtblstaffdata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StaffDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StaffNameName = c.String(),
                        MyId = c.String(),
                        EnterbyId = c.String(),
                        Enterby = c.String(),
                        EnterbyName = c.String(),
                        StaffDOB = c.String(),
                        Gender = c.String(),
                        Qualificatiion = c.String(),
                        Designation = c.String(),
                        File = c.String(),
                        IdNo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StaffDetails");
        }
    }
}
