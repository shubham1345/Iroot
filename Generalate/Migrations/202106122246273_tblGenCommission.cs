namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblGenCommission : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblGenCommissions", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblGenCommissions", "Status");
        }
    }
}
