namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_ProvinceCouncilNewFieldAdded_PersonalDetailsId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_ProvinceCouncil", "PersonalDetailsId", c => c.Long());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_ProvinceCouncil", "PersonalDetailsId");
        }
    }
}
