﻿namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProvineMember : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_provinceData", "Member", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_provinceData", "Member");
        }
    }
}
