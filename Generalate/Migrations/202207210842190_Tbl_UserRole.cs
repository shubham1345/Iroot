namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_UserRole : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_UserRole",
                c => new
                    {
                        Userrole_Id = c.Int(nullable: false, identity: true),
                        Role_Name = c.String(),
                    })
                .PrimaryKey(t => t.Userrole_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tbl_UserRole");
        }
    }
}
