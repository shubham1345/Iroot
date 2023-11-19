namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mymigrationtbblcol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblGenCommissions", "GenId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblGenCommissions", "GenId");
        }
    }
}
