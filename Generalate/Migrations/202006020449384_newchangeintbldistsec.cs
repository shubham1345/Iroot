namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newchangeintbldistsec : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.tbl_DistSector");
            AlterColumn("dbo.tbl_DistSector", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.tbl_DistSector", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.tbl_DistSector");
            AlterColumn("dbo.tbl_DistSector", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.tbl_DistSector", "Id");
        }
    }
}
