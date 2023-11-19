namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl_PrimarydetailsNewFieldCertificateAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Primarydetails", "NameInTheCertificate", c => c.String(maxLength: 200));
            AddColumn("dbo.tbl_Primarydetails", "DOBInTheCertificate", c => c.String(maxLength: 50));
            AddColumn("dbo.tbl_SeperationFromTheCongregation", "SeperationAge", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_SeperationFromTheCongregation", "SeperationAge");
            DropColumn("dbo.tbl_Primarydetails", "DOBInTheCertificate");
            DropColumn("dbo.tbl_Primarydetails", "NameInTheCertificate");
        }
    }
}
