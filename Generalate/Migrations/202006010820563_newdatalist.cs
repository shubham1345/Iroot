namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdatalist : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tbl_DistSector", "CreatedDate1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_DistSector", "CreatedDate1", c => c.String());
        }
    }
}
