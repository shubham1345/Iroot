namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingnewtblandcolumns : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ComOSProContacts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DioId = c.String(),
                        MyId = c.String(),
                        DioName = c.String(),
                        Email = c.String(),
                        MobileNo = c.String(),
                        Address = c.String(),
                        File = c.String(),
                        Date = c.String(),
                        ProvinceName = c.String(),
                        MemberName = c.String(),
                        Types = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ComOSProvinces",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DioId = c.String(),
                        MyId = c.String(),
                        DioName = c.String(),
                        Email = c.String(),
                        MobileNo = c.String(),
                        Address = c.String(),
                        File = c.String(),
                        CreatedDate = c.String(),
                        ProvinceName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tbl_ComOSCommunity",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DioId = c.String(),
                        MyId = c.String(),
                        DioName = c.String(),
                        Email = c.String(),
                        MobileNo = c.String(),
                        Address = c.String(),
                        File = c.String(),
                        CreatedDate = c.String(),
                        ProvinceName = c.String(),
                        ComName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tbl_ComOSContact",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DioId = c.String(),
                        MyId = c.String(),
                        DioName = c.String(),
                        Email = c.String(),
                        MobileNo = c.String(),
                        Address = c.String(),
                        File = c.String(),
                        Date = c.String(),
                        ProvinceName = c.String(),
                        MemberName = c.String(),
                        Types = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_ComOSContact");
            DropTable("dbo.tbl_ComOSCommunity");
            DropTable("dbo.ComOSProvinces");
            DropTable("dbo.ComOSProContacts");
        }
    }
}
