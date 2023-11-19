namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcolumnforidgen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ComHouses", "ActiveCkeck", c => c.String());
            AddColumn("dbo.ComOutSides", "ActiveCkeck", c => c.String());
            AddColumn("dbo.Societys", "ActiveCkeck", c => c.String());
            AddColumn("dbo.Tbl_Cong", "ActiveCkeck", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_Cong", "ActiveCkeck");
            DropColumn("dbo.Societys", "ActiveCkeck");
            DropColumn("dbo.ComOutSides", "ActiveCkeck");
            DropColumn("dbo.ComHouses", "ActiveCkeck");
        }
    }
}
