namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingsnewtbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_DistSector", "CreatedDate1", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_DistSector", "CreatedDate1");
        }
    }
}
