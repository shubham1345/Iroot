namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingnewcol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sacraments", "Diocese", c => c.String());
            AddColumn("dbo.tbl_Archive", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Archive", "Description");
            DropColumn("dbo.Sacraments", "Diocese");
        }
    }
}
