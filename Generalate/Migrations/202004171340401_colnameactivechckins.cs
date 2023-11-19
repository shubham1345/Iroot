namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class colnameactivechckins : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_ParisInstitutionDetails", "ActiveCkeck", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_ParisInstitutionDetails", "ActiveCkeck");
        }
    }
}
