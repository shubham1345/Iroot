namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MultiLanguage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MultiLanguages", "SpanishText", c => c.String());
            AddColumn("dbo.MultiLanguages", "Language3", c => c.String());
            AddColumn("dbo.MultiLanguages", "ItalyText", c => c.String());
            AddColumn("dbo.MultiLanguages", "Language4", c => c.String());
            AddColumn("dbo.MultiLanguages", "GermanText", c => c.String());
            AddColumn("dbo.MultiLanguages", "Language5", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MultiLanguages", "Language5");
            DropColumn("dbo.MultiLanguages", "GermanText");
            DropColumn("dbo.MultiLanguages", "Language4");
            DropColumn("dbo.MultiLanguages", "ItalyText");
            DropColumn("dbo.MultiLanguages", "Language3");
            DropColumn("dbo.MultiLanguages", "SpanishText");
        }
    }
}
