namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingnewcolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExcelSheetDatas", "Workbook", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExcelSheetDatas", "Workbook");
        }
    }
}
