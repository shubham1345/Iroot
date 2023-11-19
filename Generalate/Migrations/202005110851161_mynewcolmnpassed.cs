namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mynewcolmnpassed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Passed", "Age", c => c.String(maxLength: 50));
            AddColumn("dbo.tbl_Passed", "WorkingYear", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Passed", "WorkingYear");
            DropColumn("dbo.tbl_Passed", "Age");
        }
    }
}
