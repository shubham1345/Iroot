namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcommonproinalltbles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ComOSProContacts", "CreatedBy", c => c.String());
            AddColumn("dbo.ComOSProContacts", "CreatedDate", c => c.String());
            AddColumn("dbo.ComOSProContacts", "UpdateBy", c => c.String());
            AddColumn("dbo.ComOSProContacts", "UpdateDate", c => c.String());
            AddColumn("dbo.ComOSProvinces", "CreatedBy", c => c.String());
            AddColumn("dbo.ComOSProvinces", "UpdateBy", c => c.String());
            AddColumn("dbo.ComOSProvinces", "UpdateDate", c => c.String());
            AddColumn("dbo.StaffDetails", "CreatedBy", c => c.String());
            AddColumn("dbo.StaffDetails", "CreatedDate", c => c.String());
            AddColumn("dbo.StaffDetails", "UpdateBy", c => c.String());
            AddColumn("dbo.StaffDetails", "UpdateDate", c => c.String());
            AddColumn("dbo.Tbl_Calender", "CreatedBy", c => c.String());
            AddColumn("dbo.Tbl_Calender", "CreatedDate", c => c.String());
            AddColumn("dbo.Tbl_Calender", "UpdateBy", c => c.String());
            AddColumn("dbo.Tbl_Calender", "UpdateDate", c => c.String());
            AddColumn("dbo.tbl_ComOSCommunity", "CreatedBy", c => c.String());
            AddColumn("dbo.tbl_ComOSCommunity", "UpdateBy", c => c.String());
            AddColumn("dbo.tbl_ComOSCommunity", "UpdateDate", c => c.String());
            AddColumn("dbo.tbl_ComOSContact", "CreatedBy", c => c.String());
            AddColumn("dbo.tbl_ComOSContact", "CreatedDate", c => c.String());
            AddColumn("dbo.tbl_ComOSContact", "UpdateBy", c => c.String());
            AddColumn("dbo.tbl_ComOSContact", "UpdateDate", c => c.String());
            AddColumn("dbo.tbl_ComOSInstitute", "CreatedBy", c => c.String());
            AddColumn("dbo.tbl_ComOSInstitute", "UpdateBy", c => c.String());
            AddColumn("dbo.tbl_ComOSInstitute", "UpdateDate", c => c.String());
            AddColumn("dbo.tbl_DioBishSec", "CreatedBy", c => c.String());
            AddColumn("dbo.tbl_DioBishSec", "CreatedDate", c => c.String());
            AddColumn("dbo.tbl_DioBishSec", "UpdateBy", c => c.String());
            AddColumn("dbo.tbl_DioBishSec", "UpdateDate", c => c.String());
            AddColumn("dbo.tbl_DioceseCom", "CreatedBy", c => c.String());
            AddColumn("dbo.tbl_DioceseCom", "UpdateBy", c => c.String());
            AddColumn("dbo.tbl_DioceseCom", "UpdateDate", c => c.String());
            AddColumn("dbo.tbl_DioceseInst", "CreatedBy", c => c.String());
            AddColumn("dbo.tbl_DioceseInst", "UpdateBy", c => c.String());
            AddColumn("dbo.tbl_DioceseInst", "UpdateDate", c => c.String());
            AddColumn("dbo.tbl_DioceseParish", "CreatedBy", c => c.String());
            AddColumn("dbo.tbl_DioceseParish", "UpdateBy", c => c.String());
            AddColumn("dbo.tbl_DioceseParish", "UpdateDate", c => c.String());
            AddColumn("dbo.tbl_DistSecCouncil", "CreatedBy", c => c.String());
            AddColumn("dbo.tbl_DistSecCouncil", "CreatedDate", c => c.String());
            AddColumn("dbo.tbl_DistSecCouncil", "UpdateBy", c => c.String());
            AddColumn("dbo.tbl_DistSecCouncil", "UpdateDate", c => c.String());
            AddColumn("dbo.tbl_DistSector", "CreatedBy", c => c.String());
            AddColumn("dbo.tbl_DistSector", "UpdateBy", c => c.String());
            AddColumn("dbo.tbl_DistSector", "UpdateDate", c => c.String());
            AddColumn("dbo.tbl_DistSectorData", "CreatedBy", c => c.String());
            AddColumn("dbo.tbl_DistSectorData", "UpdateBy", c => c.String());
            AddColumn("dbo.tbl_DistSectorData", "UpdateDate", c => c.String());
            AddColumn("dbo.tbl_HomeVisit", "CreatedBy", c => c.String());
            AddColumn("dbo.tbl_HomeVisit", "CreatedDate", c => c.String());
            AddColumn("dbo.tbl_HomeVisit", "UpdateBy", c => c.String());
            AddColumn("dbo.tbl_HomeVisit", "UpdateDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_HomeVisit", "UpdateDate");
            DropColumn("dbo.tbl_HomeVisit", "UpdateBy");
            DropColumn("dbo.tbl_HomeVisit", "CreatedDate");
            DropColumn("dbo.tbl_HomeVisit", "CreatedBy");
            DropColumn("dbo.tbl_DistSectorData", "UpdateDate");
            DropColumn("dbo.tbl_DistSectorData", "UpdateBy");
            DropColumn("dbo.tbl_DistSectorData", "CreatedBy");
            DropColumn("dbo.tbl_DistSector", "UpdateDate");
            DropColumn("dbo.tbl_DistSector", "UpdateBy");
            DropColumn("dbo.tbl_DistSector", "CreatedBy");
            DropColumn("dbo.tbl_DistSecCouncil", "UpdateDate");
            DropColumn("dbo.tbl_DistSecCouncil", "UpdateBy");
            DropColumn("dbo.tbl_DistSecCouncil", "CreatedDate");
            DropColumn("dbo.tbl_DistSecCouncil", "CreatedBy");
            DropColumn("dbo.tbl_DioceseParish", "UpdateDate");
            DropColumn("dbo.tbl_DioceseParish", "UpdateBy");
            DropColumn("dbo.tbl_DioceseParish", "CreatedBy");
            DropColumn("dbo.tbl_DioceseInst", "UpdateDate");
            DropColumn("dbo.tbl_DioceseInst", "UpdateBy");
            DropColumn("dbo.tbl_DioceseInst", "CreatedBy");
            DropColumn("dbo.tbl_DioceseCom", "UpdateDate");
            DropColumn("dbo.tbl_DioceseCom", "UpdateBy");
            DropColumn("dbo.tbl_DioceseCom", "CreatedBy");
            DropColumn("dbo.tbl_DioBishSec", "UpdateDate");
            DropColumn("dbo.tbl_DioBishSec", "UpdateBy");
            DropColumn("dbo.tbl_DioBishSec", "CreatedDate");
            DropColumn("dbo.tbl_DioBishSec", "CreatedBy");
            DropColumn("dbo.tbl_ComOSInstitute", "UpdateDate");
            DropColumn("dbo.tbl_ComOSInstitute", "UpdateBy");
            DropColumn("dbo.tbl_ComOSInstitute", "CreatedBy");
            DropColumn("dbo.tbl_ComOSContact", "UpdateDate");
            DropColumn("dbo.tbl_ComOSContact", "UpdateBy");
            DropColumn("dbo.tbl_ComOSContact", "CreatedDate");
            DropColumn("dbo.tbl_ComOSContact", "CreatedBy");
            DropColumn("dbo.tbl_ComOSCommunity", "UpdateDate");
            DropColumn("dbo.tbl_ComOSCommunity", "UpdateBy");
            DropColumn("dbo.tbl_ComOSCommunity", "CreatedBy");
            DropColumn("dbo.Tbl_Calender", "UpdateDate");
            DropColumn("dbo.Tbl_Calender", "UpdateBy");
            DropColumn("dbo.Tbl_Calender", "CreatedDate");
            DropColumn("dbo.Tbl_Calender", "CreatedBy");
            DropColumn("dbo.StaffDetails", "UpdateDate");
            DropColumn("dbo.StaffDetails", "UpdateBy");
            DropColumn("dbo.StaffDetails", "CreatedDate");
            DropColumn("dbo.StaffDetails", "CreatedBy");
            DropColumn("dbo.ComOSProvinces", "UpdateDate");
            DropColumn("dbo.ComOSProvinces", "UpdateBy");
            DropColumn("dbo.ComOSProvinces", "CreatedBy");
            DropColumn("dbo.ComOSProContacts", "UpdateDate");
            DropColumn("dbo.ComOSProContacts", "UpdateBy");
            DropColumn("dbo.ComOSProContacts", "CreatedDate");
            DropColumn("dbo.ComOSProContacts", "CreatedBy");
        }
    }
}
