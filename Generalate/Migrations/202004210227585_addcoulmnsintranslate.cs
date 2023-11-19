namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcoulmnsintranslate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Transfer", "OldMemberId", c => c.String(maxLength: 150));
            AddColumn("dbo.Tbl_Transfer", "OldProvinceId", c => c.String(maxLength: 150));
            AddColumn("dbo.Tbl_Transfer", "OldProvinceName", c => c.String(maxLength: 550));
            AddColumn("dbo.Tbl_Transfer", "NewProvinceId", c => c.String());
            AddColumn("dbo.Tbl_Transfer", "NewMemberId", c => c.String());
            AddColumn("dbo.Tbl_Transfer", "CreatedDate", c => c.String());
            AddColumn("dbo.Tbl_Transfer", "InsertBy", c => c.String());
            AddColumn("dbo.Tbl_Transfer", "Option1", c => c.String());
            AddColumn("dbo.Tbl_Transfer", "Option2", c => c.String());
            AddColumn("dbo.Tbl_Transfer", "Option3", c => c.String());
            AddColumn("dbo.Tbl_Transfer", "Option4", c => c.String());
            DropColumn("dbo.Tbl_Transfer", "MemberId");
            DropColumn("dbo.Tbl_Transfer", "ProvinceId");
            DropColumn("dbo.Tbl_Transfer", "ProvinceName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tbl_Transfer", "ProvinceName", c => c.String(maxLength: 550));
            AddColumn("dbo.Tbl_Transfer", "ProvinceId", c => c.String(maxLength: 150));
            AddColumn("dbo.Tbl_Transfer", "MemberId", c => c.String(maxLength: 150));
            DropColumn("dbo.Tbl_Transfer", "Option4");
            DropColumn("dbo.Tbl_Transfer", "Option3");
            DropColumn("dbo.Tbl_Transfer", "Option2");
            DropColumn("dbo.Tbl_Transfer", "Option1");
            DropColumn("dbo.Tbl_Transfer", "InsertBy");
            DropColumn("dbo.Tbl_Transfer", "CreatedDate");
            DropColumn("dbo.Tbl_Transfer", "NewMemberId");
            DropColumn("dbo.Tbl_Transfer", "NewProvinceId");
            DropColumn("dbo.Tbl_Transfer", "OldProvinceName");
            DropColumn("dbo.Tbl_Transfer", "OldProvinceId");
            DropColumn("dbo.Tbl_Transfer", "OldMemberId");
        }
    }
}
