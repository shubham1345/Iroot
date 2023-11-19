namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcolintblprimary : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Primarydetails", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Primarydetails", "Address");
        }
    }
}
