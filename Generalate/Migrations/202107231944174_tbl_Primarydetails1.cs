namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl_Primarydetails1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Primarydetails", "Telephone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Primarydetails", "Telephone");
        }
    }
}
