namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newaddedarchivecol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Archive", "Archivecheck", c => c.String());
            AddColumn("dbo.tbl_PersonalDetails", "Archivecheck", c => c.String());
            AddColumn("dbo.Tbl_formationsDetails", "Archivecheck", c => c.String());
            AddColumn("dbo.Tbl_RenewalVows", "Archivecheck", c => c.String());
            AddColumn("dbo.tbl_Retirement", "Archivecheck", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Retirement", "Archivecheck");
            DropColumn("dbo.Tbl_RenewalVows", "Archivecheck");
            DropColumn("dbo.Tbl_formationsDetails", "Archivecheck");
            DropColumn("dbo.tbl_PersonalDetails", "Archivecheck");
            DropColumn("dbo.tbl_Archive", "Archivecheck");
        }
    }
}
