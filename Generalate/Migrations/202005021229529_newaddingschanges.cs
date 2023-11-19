namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newaddingschanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExcelSheetDatas", "AccessionNo", c => c.String());
            AddColumn("dbo.ExcelSheetDatas", "BarcodeId", c => c.String());
            AddColumn("dbo.ExcelSheetDatas", "BarcodeImage", c => c.String());
            AddColumn("dbo.ExcelSheetDatas", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExcelSheetDatas", "Title");
            DropColumn("dbo.ExcelSheetDatas", "BarcodeImage");
            DropColumn("dbo.ExcelSheetDatas", "BarcodeId");
            DropColumn("dbo.ExcelSheetDatas", "AccessionNo");
        }
    }
}
