namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_DesignationDetails1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_DesignationDetails", "Name_French", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_DesignationDetails", "Name_French");
        }
    }
}
