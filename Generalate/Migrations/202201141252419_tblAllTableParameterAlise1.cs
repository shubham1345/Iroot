namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblAllTableParameterAlise1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblAllTableParameterAlises", "TableName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblAllTableParameterAlises", "TableName");
        }
    }
}
