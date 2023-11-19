namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingnewcolumnname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Complains", "MyDate", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_Complains", "MyDate");
        }
    }
}
