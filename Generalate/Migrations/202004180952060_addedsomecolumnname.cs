namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedsomecolumnname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_PersonalDetails", "Birthday", c => c.String());
            AddColumn("dbo.tbl_PersonalDetails", "Diedcheck", c => c.String());
            AddColumn("dbo.tbl_PersonalDetails", "Sapcheck", c => c.String());
            AddColumn("dbo.Tbl_formationsDetails", "Diedcheck", c => c.String());
            AddColumn("dbo.Tbl_formationsDetails", "Sapcheck", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_formationsDetails", "Sapcheck");
            DropColumn("dbo.Tbl_formationsDetails", "Diedcheck");
            DropColumn("dbo.tbl_PersonalDetails", "Sapcheck");
            DropColumn("dbo.tbl_PersonalDetails", "Diedcheck");
            DropColumn("dbo.tbl_PersonalDetails", "Birthday");
        }
    }
}
