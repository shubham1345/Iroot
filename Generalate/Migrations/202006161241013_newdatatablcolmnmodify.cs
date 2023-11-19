namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdatatablcolmnmodify : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_SeperationFromTheCongregation", "Describtion", c => c.String(maxLength: 635));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_SeperationFromTheCongregation", "Describtion", c => c.String(maxLength: 35));
        }
    }
}
