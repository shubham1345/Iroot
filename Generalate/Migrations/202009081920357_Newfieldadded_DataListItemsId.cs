namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Newfieldadded_DataListItemsId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_ProvinceCouncil", "DataListItemsId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_ProvinceCouncil", "DataListItemsId");
        }
    }
}
