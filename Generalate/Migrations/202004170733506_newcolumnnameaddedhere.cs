namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcolumnnameaddedhere : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_PersonalDetails", "GenFileNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_PersonalDetails", "GenFileNo");
        }
    }
}
