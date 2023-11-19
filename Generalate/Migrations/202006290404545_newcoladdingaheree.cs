namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcoladdingaheree : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Congregation", "FamilyBelongsTo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Congregation", "FamilyBelongsTo");
        }
    }
}
