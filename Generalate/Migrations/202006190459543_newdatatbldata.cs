namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdatatbldata : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_Health", "Complaint", c => c.String());
            AlterColumn("dbo.tbl_Health", "Hospital", c => c.String());
            AlterColumn("dbo.tbl_Health", "Description", c => c.String());
            AlterColumn("dbo.tbl_Retirement", "DOR", c => c.String());
            AlterColumn("dbo.tbl_SeperationFromTheCongregation", "SeperationDate", c => c.String());
            AlterColumn("dbo.tbl_SeperationFromTheCongregation", "Title", c => c.String());
            AlterColumn("dbo.tbl_SeperationFromTheCongregation", "Describtion", c => c.String());
            AlterColumn("dbo.tbl_SeperationFromTheCongregation", "File", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_SeperationFromTheCongregation", "File", c => c.String(maxLength: 35));
            AlterColumn("dbo.tbl_SeperationFromTheCongregation", "Describtion", c => c.String(maxLength: 635));
            AlterColumn("dbo.tbl_SeperationFromTheCongregation", "Title", c => c.String(maxLength: 35));
            AlterColumn("dbo.tbl_SeperationFromTheCongregation", "SeperationDate", c => c.String(maxLength: 10));
            AlterColumn("dbo.tbl_Retirement", "DOR", c => c.String(maxLength: 10));
            AlterColumn("dbo.tbl_Health", "Description", c => c.String(maxLength: 500));
            AlterColumn("dbo.tbl_Health", "Hospital", c => c.String(maxLength: 150));
            AlterColumn("dbo.tbl_Health", "Complaint", c => c.String(maxLength: 150));
        }
    }
}
