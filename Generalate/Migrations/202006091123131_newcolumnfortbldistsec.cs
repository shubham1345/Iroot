namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcolumnfortbldistsec : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_DistSector", "ProvinceName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_DistSector", "ProvinceName");
        }
    }
}
