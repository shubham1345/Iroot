namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingmyfirstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AllProvinceRecords",
                c => new
                    {
                        PRId = c.Int(nullable: false, identity: true),
                        StartDate = c.String(),
                        EndDate = c.String(),
                        ProvinceName = c.String(),
                        ProvinceCode = c.String(),
                        Totalproffess = c.String(),
                        GrandtotalProfNovStart = c.String(),
                        TPorFP = c.String(),
                        PerProf = c.String(),
                        GrandtotalProfLast = c.String(),
                        FirststNovices = c.String(),
                        SecondNovices = c.String(),
                        GrandtotalProfNovLast = c.String(),
                        NovDepart = c.String(),
                        VTDepart = c.String(),
                        VPDepart = c.String(),
                        Death = c.String(),
                        Transfer1 = c.String(),
                        Transfer2 = c.String(),
                        Total = c.String(),
                        Total1 = c.String(),
                        Total2 = c.String(),
                        Total3 = c.String(),
                        Total4 = c.String(),
                        Total5 = c.String(),
                        Total6 = c.String(),
                        Total7 = c.String(),
                        Total8 = c.String(),
                        Total9 = c.String(),
                        Total10 = c.String(),
                        Total11 = c.String(),
                        Total12 = c.String(),
                        Total13 = c.String(),
                        Extratbl = c.String(),
                        Extratbl1 = c.String(),
                    })
                .PrimaryKey(t => t.PRId);
            
            CreateTable(
                "dbo.AppointmentDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataListName = c.String(maxLength: 150),
                        DataListItemName = c.String(maxLength: 150),
                        Date = c.String(maxLength: 150),
                        FromDate = c.String(maxLength: 150),
                        ToDate = c.String(maxLength: 150),
                        Title = c.String(maxLength: 150),
                        Description = c.String(),
                        File = c.String(maxLength: 350),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.String(maxLength: 150),
                        CongId = c.String(maxLength: 150),
                        Title = c.String(maxLength: 150),
                        Name = c.String(maxLength: 150),
                        Date = c.String(maxLength: 150),
                        FromDate = c.String(maxLength: 150),
                        ToDate = c.String(maxLength: 150),
                        doc = c.String(maxLength: 50),
                        Description = c.String(),
                        AppointmentType = c.String(maxLength: 500),
                        drpNameType = c.String(maxLength: 100),
                        DesignationType = c.String(maxLength: 500),
                        InstitutionType = c.String(maxLength: 500),
                        CommunityType = c.String(maxLength: 500),
                        Superior = c.String(maxLength: 150),
                        ParisData = c.String(),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ComHouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommunityName = c.String(maxLength: 100),
                        CommunityCode = c.String(),
                        ProvinceName = c.String(maxLength: 550),
                        OtherProvince = c.String(),
                        Place = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Country = c.String(),
                        EmailId = c.String(),
                        DisSec = c.String(),
                        File = c.String(),
                        MyId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ComHouseDetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ComId = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        Description = c.String(),
                        File1 = c.String(maxLength: 50),
                        File2 = c.String(maxLength: 50),
                        File3 = c.String(maxLength: 50),
                        File4 = c.String(maxLength: 50),
                        File5 = c.String(maxLength: 50),
                        other1 = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ComOutSides",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommunityName = c.String(maxLength: 100),
                        MyId = c.String(),
                        ProvinceName = c.String(maxLength: 550),
                        OtherProvince = c.String(),
                        Place = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Country = c.String(),
                        EmailId = c.String(),
                        DisSec = c.String(),
                        File = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ComOutSideDetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ComId = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        Description = c.String(),
                        File1 = c.String(maxLength: 50),
                        File2 = c.String(maxLength: 50),
                        File3 = c.String(maxLength: 50),
                        File4 = c.String(maxLength: 50),
                        File5 = c.String(maxLength: 50),
                        other1 = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.CongDatas",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        CongId = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        Description = c.String(),
                        File1 = c.String(maxLength: 50),
                        File2 = c.String(maxLength: 50),
                        File3 = c.String(maxLength: 50),
                        File4 = c.String(maxLength: 50),
                        File5 = c.String(maxLength: 50),
                        other1 = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                        CreatedDate = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.CongreDatas",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        ProvId = c.String(maxLength: 50),
                        CongID = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        Description = c.String(),
                        File1 = c.String(maxLength: 50),
                        File2 = c.String(maxLength: 50),
                        File3 = c.String(maxLength: 50),
                        File4 = c.String(maxLength: 50),
                        File5 = c.String(maxLength: 50),
                        other1 = c.String(maxLength: 50),
                        CreatedDate = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.CounCircCommis",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        title = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        Describtion = c.String(maxLength: 50),
                        Doc = c.String(maxLength: 50),
                        FileName = c.String(),
                        EntryLifeId = c.Int(nullable: false),
                        Type = c.String(),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.DataListItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataListName = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        Designation = c.String(maxLength: 50),
                        Institution = c.String(maxLength: 50),
                        Community = c.String(maxLength: 50),
                        Address = c.String(maxLength: 200),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DataListItems2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataListName = c.String(maxLength: 350),
                        DataListItemName = c.String(maxLength: 350),
                        Date = c.String(maxLength: 350),
                        FromDate = c.String(maxLength: 150),
                        ToDate = c.String(maxLength: 150),
                        Title = c.String(maxLength: 150),
                        Description = c.String(),
                        File = c.String(maxLength: 350),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DataLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DataLists2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FamilyDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.String(),
                        Name = c.String(maxLength: 50),
                        MemberName = c.String(maxLength: 50),
                        Relationship = c.String(maxLength: 50),
                        YearOfBirth = c.String(maxLength: 50),
                        YearOfDeath = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Address = c.String(maxLength: 500),
                        EmergencyContact = c.String(maxLength: 150),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MyComDataCHes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ComId = c.String(),
                        Date = c.String(),
                        Description = c.String(),
                        File1 = c.String(),
                        File2 = c.String(),
                        File3 = c.String(),
                        File4 = c.String(),
                        other1 = c.String(),
                        ProvinceName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MyDataCOS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ComId = c.String(),
                        Date = c.String(),
                        Description = c.String(),
                        File1 = c.String(),
                        File2 = c.String(),
                        other1 = c.String(),
                        ProvinceName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProvinceDatas",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        ProvId = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        Description = c.String(),
                        File1 = c.String(maxLength: 50),
                        File2 = c.String(maxLength: 50),
                        File3 = c.String(maxLength: 50),
                        File4 = c.String(maxLength: 50),
                        File5 = c.String(maxLength: 50),
                        other1 = c.String(maxLength: 50),
                        CreatedDate = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.RolePagePermissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.String(),
                        RoleName = c.String(),
                        PageName = c.String(),
                        HasPermission = c.Boolean(nullable: false),
                        PageViewName = c.String(),
                        ParentId = c.Int(nullable: false),
                        provinceId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RolePermissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.String(),
                        RoleName = c.String(),
                        PageName = c.String(),
                        HasPermission = c.Boolean(nullable: false),
                        PageViewName = c.String(),
                        ParentId = c.Int(nullable: false),
                        Items = c.String(),
                        adminRole = c.String(),
                        userRole = c.String(),
                        permission = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sacraments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        Sacrament = c.String(maxLength: 50),
                        Minister = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        ChurchName = c.String(maxLength: 50),
                        Remarks = c.String(maxLength: 100),
                        MemberId = c.String(maxLength: 50),
                        File = c.String(maxLength: 350),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SocietyDatas",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        SocId = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        Description = c.String(),
                        File1 = c.String(maxLength: 50),
                        File2 = c.String(maxLength: 50),
                        File3 = c.String(maxLength: 50),
                        File4 = c.String(maxLength: 50),
                        File5 = c.String(maxLength: 50),
                        other1 = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                        CreatedDate = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Societys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SocId = c.String(maxLength: 50),
                        MemberId = c.String(maxLength: 50),
                        PanNumber = c.String(maxLength: 100),
                        NameOfTheSocity = c.String(maxLength: 200),
                        FCRANumber = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        Number12A = c.String(maxLength: 50),
                        Number12AA = c.String(maxLength: 50),
                        RegistrationNumber = c.String(maxLength: 50),
                        Number80G = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        Telno = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Website = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                        TypesOfReg = c.String(maxLength: 550),
                        File = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SocInsPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.String(),
                        Title = c.String(),
                        Describtion = c.String(),
                        Doc = c.String(),
                        ProvinceName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_Academy",
                c => new
                    {
                        acaid = c.Int(nullable: false, identity: true),
                        title = c.String(maxLength: 50),
                        course = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        degree = c.String(maxLength: 50),
                        university = c.String(maxLength: 50),
                        fromdate = c.String(maxLength: 50),
                        todate = c.String(maxLength: 50),
                        classo = c.String(maxLength: 50),
                        medium = c.String(maxLength: 50),
                        adress = c.String(maxLength: 200),
                        remark = c.String(maxLength: 500),
                        doc = c.String(),
                        MemberId = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.acaid);
            
            CreateTable(
                "dbo.tbl_Archive",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        MemberId = c.String(),
                        ArchiveNo = c.String(),
                        Date = c.String(),
                        FileNo = c.String(),
                        ProvinceName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_Bank_Details",
                c => new
                    {
                        BankId = c.Long(nullable: false, identity: true),
                        BankName = c.String(maxLength: 100),
                        AccNum = c.String(maxLength: 100),
                        IFCS = c.String(maxLength: 10),
                        Branch = c.String(maxLength: 10),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.BankId);
            
            CreateTable(
                "dbo.tbl_BookOfAccountsDoc",
                c => new
                    {
                        BookOfAccountsId = c.Int(nullable: false, identity: true),
                        DoccumentName = c.String(maxLength: 50),
                        Title = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        Place = c.String(maxLength: 50),
                        Ammount = c.String(maxLength: 50),
                        File = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.BookOfAccountsId);
            
            CreateTable(
                "dbo.tbl_CandidatesInformationDoc",
                c => new
                    {
                        CandidatesInformationId = c.Int(nullable: false, identity: true),
                        DoccumentName = c.String(maxLength: 50),
                        Title = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        File = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.CandidatesInformationId);
            
            CreateTable(
                "dbo.Tbl_Comm",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommunityName = c.String(maxLength: 100),
                        CongregationName = c.String(),
                        Place = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        CreatedDate = c.String(),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_CommonDataList",
                c => new
                    {
                        CDLId = c.Int(nullable: false, identity: true),
                        DataListName = c.String(maxLength: 500),
                        Status = c.String(maxLength: 10),
                        Spare1 = c.String(maxLength: 35),
                        Spare2 = c.String(maxLength: 35),
                        Spare3 = c.String(maxLength: 35),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.CDLId);
            
            CreateTable(
                "dbo.tbl_CommonDataListItems",
                c => new
                    {
                        CDLITId = c.Int(nullable: false, identity: true),
                        DataListName = c.String(maxLength: 500),
                        DataListItemName = c.String(maxLength: 500),
                        Status = c.String(maxLength: 10),
                        Spare1 = c.String(maxLength: 35),
                        Spare2 = c.String(maxLength: 35),
                        Spare3 = c.String(maxLength: 35),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.CDLITId);
            
            CreateTable(
                "dbo.tbl_CommunicationOfficeDoc",
                c => new
                    {
                        CommunicationOfficeId = c.Int(nullable: false, identity: true),
                        DoccumentName = c.String(maxLength: 50),
                        Title = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        File = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.CommunicationOfficeId);
            
            CreateTable(
                "dbo.tbl_CommunitiesSocialCentresDoc",
                c => new
                    {
                        CommunityId = c.Int(nullable: false, identity: true),
                        CommunityName = c.String(maxLength: 50),
                        EstablishDate = c.String(maxLength: 50),
                        Place = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        ContactNumber = c.String(maxLength: 500),
                        Website = c.String(maxLength: 50),
                        File = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.CommunityId);
            
            CreateTable(
                "dbo.Tbl_Complains",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(maxLength: 50),
                        Title = c.String(maxLength: 50),
                        Discription = c.String(maxLength: 500),
                        NatureofTheComplaint = c.String(maxLength: 100),
                        ComplaintReceived = c.String(maxLength: 100),
                        Decision = c.String(maxLength: 200),
                        InvolvedIn = c.String(),
                        FileName = c.String(maxLength: 50),
                        MemberId = c.String(maxLength: 50),
                        MemberName = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_Complaint",
                c => new
                    {
                        ComplaintID = c.Int(nullable: false, identity: true),
                        MemberID = c.String(nullable: false, maxLength: 15),
                        Name = c.String(maxLength: 256),
                        ComplaintFrom = c.String(maxLength: 70),
                        ComplaintDATE = c.String(),
                        ComplaintNATURE = c.String(maxLength: 700),
                        Decesion = c.String(maxLength: 300),
                        Document = c.String(),
                        Spare1 = c.String(maxLength: 255),
                        Spare2 = c.String(maxLength: 352),
                        Spare3 = c.String(maxLength: 350),
                        SirName = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.ComplaintID);
            
            CreateTable(
                "dbo.tbl_ConfreresDoc",
                c => new
                    {
                        ConfreresId = c.Int(nullable: false, identity: true),
                        DoccumentName = c.String(maxLength: 50),
                        Title = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        File = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.ConfreresId);
            
            CreateTable(
                "dbo.Tbl_Cong",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CommId = c.String(),
                        CongregationName = c.String(),
                        CommCode = c.String(),
                        Place = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Country = c.String(),
                        EmailId = c.String(),
                        DisSec = c.String(),
                        CreatedDate = c.String(),
                        ProvinceName = c.String(maxLength: 550),
                        File = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_CongrationsData",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CongrationId = c.String(),
                        Title = c.String(),
                        Date = c.String(),
                        Description = c.String(),
                        File = c.String(),
                        CreatedDate = c.String(),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tbl_Congregation",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CongreId = c.String(),
                        CongregationName = c.String(),
                        Establishment = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                        CreatedDate = c.String(),
                        History = c.String(),
                        Country = c.String(),
                        ProvinceName = c.String(maxLength: 550),
                        File = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_EmergencyContact",
                c => new
                    {
                        EmergencyContactId = c.Long(nullable: false, identity: true),
                        MemberID = c.String(nullable: false, maxLength: 15),
                        Name = c.String(maxLength: 200),
                        Relationship = c.String(nullable: false, maxLength: 200),
                        Mobile = c.String(),
                        Landline = c.String(),
                        EmailID = c.String(maxLength: 200),
                        Address = c.String(maxLength: 500),
                        Spare1 = c.String(maxLength: 35),
                        Spare2 = c.String(maxLength: 35),
                        Spare3 = c.String(maxLength: 35),
                        SirName = c.String(maxLength: 35),
                        tbl_PersonalDetails_PersonalDetailsId = c.Long(),
                    })
                .PrimaryKey(t => t.EmergencyContactId)
                .ForeignKey("dbo.tbl_PersonalDetails", t => t.tbl_PersonalDetails_PersonalDetailsId)
                .Index(t => t.tbl_PersonalDetails_PersonalDetailsId);
            
            CreateTable(
                "dbo.tbl_PersonalDetails",
                c => new
                    {
                        PersonalDetailsId = c.Long(nullable: false, identity: true),
                        MemberID = c.String(maxLength: 15),
                        Name = c.String(nullable: false, maxLength: 200),
                        NameBaptismial = c.String(maxLength: 200),
                        EmailID = c.String(maxLength: 200),
                        SirName = c.String(maxLength: 200),
                        Image = c.Binary(),
                        MotherTongue = c.String(maxLength: 100),
                        Mobile = c.String(),
                        BloodGroup = c.String(maxLength: 20),
                        DOB = c.String(maxLength: 50),
                        FeastDays = c.String(maxLength: 10),
                        VillageTown = c.String(maxLength: 100),
                        District = c.String(maxLength: 100),
                        State = c.String(maxLength: 100),
                        Country = c.String(maxLength: 100),
                        Pincode = c.String(),
                        AadharNo = c.String(),
                        NameasinAadharCard = c.String(maxLength: 50),
                        FatherName = c.String(maxLength: 200),
                        FMobile = c.String(),
                        MotherName = c.String(maxLength: 200),
                        MMobile = c.String(),
                        NoOfBrother = c.String(),
                        NoOfSister = c.String(),
                        PlaceintheFamily = c.String(),
                        Spare1 = c.String(maxLength: 256),
                        Spare2 = c.String(maxLength: 35),
                        Spare3 = c.String(maxLength: 256),
                        Parish1 = c.String(maxLength: 256),
                        FBaptism = c.String(maxLength: 256),
                        MBaptism = c.String(maxLength: 256),
                        FileNo = c.String(maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.PersonalDetailsId);
            
            CreateTable(
                "dbo.tbl_Entry",
                c => new
                    {
                        EntryId = c.Long(nullable: false, identity: true),
                        MemberID = c.String(nullable: false, maxLength: 15),
                        Name = c.String(maxLength: 200),
                        DateOfBaptism = c.String(maxLength: 10),
                        ChurchName1 = c.String(maxLength: 200),
                        Minister1 = c.String(maxLength: 500),
                        Place1 = c.String(maxLength: 500),
                        DateOfConfirmation = c.String(maxLength: 10),
                        ChurchName2 = c.String(maxLength: 200),
                        Minister2 = c.String(maxLength: 500),
                        Place2 = c.String(maxLength: 500),
                        Spare1 = c.String(maxLength: 35),
                        Spare2 = c.String(maxLength: 35),
                        Spare3 = c.String(maxLength: 35),
                        SirName = c.String(maxLength: 35),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.EntryId);
            
            CreateTable(
                "dbo.tbl_EntryLife",
                c => new
                    {
                        EntryLifeId = c.Long(nullable: false, identity: true),
                        MemberID = c.String(nullable: false, maxLength: 15),
                        Name = c.String(maxLength: 200),
                        EntryDate = c.String(maxLength: 10),
                        Place = c.String(maxLength: 500),
                        Director = c.String(maxLength: 200),
                        Minister = c.String(maxLength: 500),
                        OngoingFormation = c.String(maxLength: 200),
                        ColName = c.String(maxLength: 500),
                        Spare1 = c.String(maxLength: 35),
                        Spare2 = c.String(maxLength: 35),
                        Spare3 = c.String(maxLength: 35),
                        SirName = c.String(maxLength: 35),
                        ProvinceName = c.String(maxLength: 550),
                        tbl_PersonalDetails_PersonalDetailsId = c.Long(),
                    })
                .PrimaryKey(t => t.EntryLifeId)
                .ForeignKey("dbo.tbl_PersonalDetails", t => t.tbl_PersonalDetails_PersonalDetailsId)
                .Index(t => t.tbl_PersonalDetails_PersonalDetailsId);
            
            CreateTable(
                "dbo.tbl_EntryLife1",
                c => new
                    {
                        EntryLifeId = c.Long(nullable: false, identity: true),
                        MemberID = c.String(nullable: false, maxLength: 15),
                        EntryDate = c.String(maxLength: 10),
                        Place = c.String(maxLength: 500),
                        Director = c.String(maxLength: 200),
                        Minister = c.String(maxLength: 500),
                        OngoingFormation = c.String(maxLength: 200),
                        ColName = c.String(maxLength: 500),
                        Spare1 = c.String(maxLength: 35),
                        Spare2 = c.String(maxLength: 35),
                        Spare3 = c.String(maxLength: 35),
                        ProvinceName = c.String(maxLength: 550),
                        tbl_PersonalDetails_PersonalDetailsId = c.Long(),
                    })
                .PrimaryKey(t => t.EntryLifeId)
                .ForeignKey("dbo.tbl_PersonalDetails", t => t.tbl_PersonalDetails_PersonalDetailsId)
                .Index(t => t.tbl_PersonalDetails_PersonalDetailsId);
            
            CreateTable(
                "dbo.tbl_FinancialGuidelineDoc",
                c => new
                    {
                        FinancialDocId = c.Int(nullable: false, identity: true),
                        DoccumentName = c.String(maxLength: 50),
                        Title = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        Phonenumber = c.String(maxLength: 50),
                        Address = c.String(maxLength: 500),
                        Email = c.String(maxLength: 50),
                        File = c.String(maxLength: 50),
                        Photo = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.FinancialDocId);
            
            CreateTable(
                "dbo.tbl_FinancialReportDoc",
                c => new
                    {
                        FinancialReportId = c.Int(nullable: false, identity: true),
                        DoccumentName = c.String(maxLength: 50),
                        Title = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        File = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.FinancialReportId);
            
            CreateTable(
                "dbo.tbl_FomDoc",
                c => new
                    {
                        FormationDocId = c.Int(nullable: false, identity: true),
                        DoccumentName = c.String(maxLength: 50),
                        Title = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        File = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.FormationDocId);
            
            CreateTable(
                "dbo.Tbl_formationsDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StageOfFormation = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        Community = c.String(maxLength: 350),
                        FromDate = c.String(maxLength: 50),
                        ToDate = c.String(maxLength: 50),
                        Title = c.String(maxLength: 50),
                        Institution = c.String(maxLength: 50),
                        Superior = c.String(maxLength: 50),
                        Formators = c.String(maxLength: 50),
                        Novisemaster = c.String(maxLength: 50),
                        Place = c.String(),
                        Receivedby = c.String(maxLength: 50),
                        Conferredby = c.String(maxLength: 50),
                        VocationFacilitator = c.String(maxLength: 50),
                        MemberId = c.String(maxLength: 50),
                        Description = c.String(),
                        FileName = c.String(),
                        ProvinceName = c.String(maxLength: 550),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_FormationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FortmationType = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_FormatorsMeetDoc",
                c => new
                    {
                        FormatorsMeetId = c.Int(nullable: false, identity: true),
                        DoccumentName = c.String(maxLength: 50),
                        Title = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        File = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.FormatorsMeetId);
            
            CreateTable(
                "dbo.tbl_FundRaisingCommiteeDoc",
                c => new
                    {
                        FundRaisingId = c.Int(nullable: false, identity: true),
                        DoccumentName = c.String(maxLength: 50),
                        Title = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        File = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.FundRaisingId);
            
            CreateTable(
                "dbo.tbl_GeneralateDoc",
                c => new
                    {
                        GeneralateId = c.Int(nullable: false, identity: true),
                        DoccumentName = c.String(maxLength: 50),
                        Title = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        File = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.GeneralateId);
            
            CreateTable(
                "dbo.tbl_GeneralMattersDoc",
                c => new
                    {
                        GeneralMattersId = c.Int(nullable: false, identity: true),
                        DoccumentName = c.String(maxLength: 50),
                        Title = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        File = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.GeneralMattersId);
            
            CreateTable(
                "dbo.Tbl_Governer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MyId = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        Designation = c.String(maxLength: 50),
                        MobileNo = c.String(maxLength: 50),
                        Address = c.String(maxLength: 550),
                        PanNo = c.String(maxLength: 50),
                        PanDoc = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_GovernerSoc",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MyId = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        Designation = c.String(maxLength: 50),
                        MobileNo = c.String(maxLength: 50),
                        Address = c.String(maxLength: 550),
                        PanNo = c.String(maxLength: 50),
                        PanDoc = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_Health",
                c => new
                    {
                        HealthId = c.Int(nullable: false, identity: true),
                        MemberID = c.String(maxLength: 15),
                        Name = c.String(maxLength: 256),
                        Complaint = c.String(maxLength: 150),
                        FromDate = c.String(maxLength: 10),
                        ToDate = c.String(maxLength: 10),
                        Diagnosis = c.String(maxLength: 100),
                        Hospital = c.String(maxLength: 150),
                        Doctor = c.String(maxLength: 100),
                        Spare1 = c.String(maxLength: 35),
                        Spare2 = c.String(maxLength: 35),
                        Spare3 = c.String(maxLength: 35),
                        SirName = c.String(maxLength: 35),
                        Title = c.String(maxLength: 100),
                        Description = c.String(maxLength: 500),
                        CreatedDate = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                        tbl_PersonalDetails_PersonalDetailsId = c.Long(),
                    })
                .PrimaryKey(t => t.HealthId)
                .ForeignKey("dbo.tbl_PersonalDetails", t => t.tbl_PersonalDetails_PersonalDetailsId)
                .Index(t => t.tbl_PersonalDetails_PersonalDetailsId);
            
            CreateTable(
                "dbo.tbl_HomeLiveAndHomeVisit",
                c => new
                    {
                        HomeliveId = c.Long(nullable: false, identity: true),
                        MemberID = c.String(nullable: false, maxLength: 15),
                        Name = c.String(maxLength: 256),
                        DepartureDate = c.String(),
                        ArrivalDate = c.String(),
                        ColName = c.String(maxLength: 500),
                        Purpose = c.String(maxLength: 200),
                        Place = c.String(maxLength: 200),
                        Spare1 = c.String(maxLength: 35),
                        Spare2 = c.String(maxLength: 35),
                        Spare3 = c.String(maxLength: 35),
                        Institute = c.String(maxLength: 40),
                        TransferLetter = c.String(),
                        SirName = c.String(),
                        ProvinceName = c.String(maxLength: 550),
                        tbl_PersonalDetails_PersonalDetailsId = c.Long(),
                    })
                .PrimaryKey(t => t.HomeliveId)
                .ForeignKey("dbo.tbl_PersonalDetails", t => t.tbl_PersonalDetails_PersonalDetailsId)
                .Index(t => t.tbl_PersonalDetails_PersonalDetailsId);
            
            CreateTable(
                "dbo.tbl_Inst",
                c => new
                    {
                        InstitutionId = c.Int(nullable: false, identity: true),
                        INSTID = c.String(nullable: false, maxLength: 15),
                        InstName = c.String(maxLength: 256),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.InstitutionId);
            
            CreateTable(
                "dbo.tbl_InstDetails",
                c => new
                    {
                        Instid = c.Long(nullable: false, identity: true),
                        Date = c.String(maxLength: 20),
                        Tital = c.String(maxLength: 20),
                        Catogory = c.String(maxLength: 20),
                        Remark = c.String(maxLength: 20),
                        File = c.String(maxLength: 35),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.Instid);
            
            CreateTable(
                "dbo.Tbl_Institution",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MyId = c.String(maxLength: 50),
                        YearOfEstablacement = c.String(maxLength: 50),
                        InstitutionName = c.String(maxLength: 50),
                        Place = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        Tial = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        Description = c.String(maxLength: 50),
                        FileName = c.String(maxLength: 50),
                        CreatedDate = c.String(maxLength: 50),
                        Telephone = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_institution123",
                c => new
                    {
                        InstitutionId = c.Long(nullable: false, identity: true),
                        MemberID = c.String(maxLength: 15),
                        FromDate = c.String(maxLength: 20),
                        Closingdate = c.String(maxLength: 20),
                        NameOfInstitution = c.String(maxLength: 20),
                        TypeOfInstitution = c.String(maxLength: 20),
                        NameOfDiocese = c.String(maxLength: 35),
                        OwenedBy = c.String(maxLength: 35),
                        MaintainedBy = c.String(maxLength: 35),
                        Address = c.String(maxLength: 100),
                        Telephone = c.String(maxLength: 100),
                        EmailID = c.String(maxLength: 35),
                        WebSite = c.String(maxLength: 35),
                        spare1 = c.String(maxLength: 100),
                        ProvinceName = c.String(maxLength: 550),
                        Spare2 = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.InstitutionId);
            
            CreateTable(
                "dbo.tbl_InstitutionFinal",
                c => new
                    {
                        InstitutionId = c.Int(nullable: false, identity: true),
                        INSTID = c.String(),
                        InstName = c.String(),
                        ProvinceName = c.String(maxLength: 550),
                        InstType = c.String(),
                    })
                .PrimaryKey(t => t.InstitutionId);
            
            CreateTable(
                "dbo.tbl_Insurance",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        Minister = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        Premium = c.String(maxLength: 50),
                        Ammount = c.String(maxLength: 50),
                        MemberId = c.String(maxLength: 50),
                        File = c.String(maxLength: 50),
                        Description = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_Jubilee",
                c => new
                    {
                        JubileeID = c.Int(nullable: false, identity: true),
                        MemberID = c.String(nullable: false, maxLength: 15),
                        Name = c.String(maxLength: 256),
                        Profession = c.String(maxLength: 256),
                        FirstProfession = c.String(maxLength: 10),
                        SilverJubilee = c.String(maxLength: 10),
                        GoldenJubilee = c.String(maxLength: 10),
                        PlatinumJubilee = c.String(maxLength: 10),
                        DiamondJubilee = c.String(maxLength: 10),
                        FPPlace = c.String(maxLength: 50),
                        SJPlace = c.String(maxLength: 50),
                        GJPlace = c.String(maxLength: 50),
                        PJPlace = c.String(maxLength: 50),
                        DJPlace = c.String(maxLength: 50),
                        Spare1 = c.String(maxLength: 35),
                        Spare2 = c.String(maxLength: 35),
                        Spare3 = c.String(maxLength: 35),
                        SirName = c.String(maxLength: 35),
                        ProvinceName = c.String(maxLength: 550),
                        tbl_PersonalDetails_PersonalDetailsId = c.Long(),
                    })
                .PrimaryKey(t => t.JubileeID)
                .ForeignKey("dbo.tbl_PersonalDetails", t => t.tbl_PersonalDetails_PersonalDetailsId)
                .Index(t => t.tbl_PersonalDetails_PersonalDetailsId);
            
            CreateTable(
                "dbo.tbl_KnownLanguages",
                c => new
                    {
                        KnownLanguagesId = c.Long(nullable: false, identity: true),
                        MemberID = c.String(nullable: false, maxLength: 15),
                        Name = c.String(maxLength: 20),
                        ToRead = c.String(maxLength: 20),
                        ToWrite = c.String(maxLength: 20),
                        ToSpeak = c.String(maxLength: 20),
                        Spare1 = c.String(maxLength: 35),
                        Spare2 = c.String(maxLength: 35),
                        Spare3 = c.String(maxLength: 35),
                        LanguageName = c.String(maxLength: 100),
                        SirName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.KnownLanguagesId);
            
            CreateTable(
                "dbo.tbl_LandDetails",
                c => new
                    {
                        Landid = c.Long(nullable: false, identity: true),
                        RegDate = c.String(maxLength: 20),
                        RegNo = c.String(maxLength: 20),
                        SurveNo = c.String(maxLength: 20),
                        DocCatogery = c.String(maxLength: 20),
                        Discreption = c.String(maxLength: 35),
                        File = c.String(maxLength: 35),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.Landid);
            
            CreateTable(
                "dbo.Tbl_LandDocuments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(maxLength: 50),
                        MyId = c.String(maxLength: 50),
                        ParisInstitutionName = c.String(maxLength: 50),
                        DocumentCategory = c.String(maxLength: 50),
                        SubCategory = c.String(maxLength: 50),
                        Khasara = c.String(maxLength: 50),
                        SurveyNo = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        Description = c.String(),
                        RegistryDocumentFile = c.String(maxLength: 100),
                        TaxbillFile = c.String(maxLength: 100),
                        PavathiFile = c.String(maxLength: 100),
                        MapFile = c.String(maxLength: 100),
                        KhasaraFile = c.String(maxLength: 100),
                        CreatedDate = c.String(maxLength: 50),
                        Year = c.String(maxLength: 50),
                        Place = c.String(maxLength: 200),
                        Tital = c.String(maxLength: 100),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_LivingOutsideTheCongregation",
                c => new
                    {
                        LivingOutsideId = c.Long(nullable: false, identity: true),
                        MemberID = c.String(nullable: false, maxLength: 15),
                        Name = c.String(maxLength: 256),
                        FromDate = c.String(maxLength: 10),
                        ToDate = c.String(maxLength: 10),
                        Place = c.String(maxLength: 256),
                        Purpose = c.String(maxLength: 256),
                        Spare1 = c.String(maxLength: 35),
                        Spare2 = c.String(maxLength: 35),
                        Spare3 = c.String(maxLength: 35),
                        SirName = c.String(maxLength: 35),
                        ProvinceName = c.String(maxLength: 550),
                        tbl_PersonalDetails_PersonalDetailsId = c.Long(),
                    })
                .PrimaryKey(t => t.LivingOutsideId)
                .ForeignKey("dbo.tbl_PersonalDetails", t => t.tbl_PersonalDetails_PersonalDetailsId)
                .Index(t => t.tbl_PersonalDetails_PersonalDetailsId);
            
            CreateTable(
                "dbo.tbl_MinistryDoc",
                c => new
                    {
                        MinistryDocId = c.Int(nullable: false, identity: true),
                        DoccumentName = c.String(maxLength: 50),
                        SubDoccument = c.String(maxLength: 50),
                        Title = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        Phonenumber = c.String(maxLength: 50),
                        Address = c.String(maxLength: 500),
                        File = c.String(maxLength: 50),
                        Photo = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.MinistryDocId);
            
            CreateTable(
                "dbo.tbl_MissionDoc",
                c => new
                    {
                        MissionId = c.Int(nullable: false, identity: true),
                        DoccumentName = c.String(maxLength: 50),
                        Title = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        File = c.String(maxLength: 50),
                        Immage = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.MissionId);
            
            CreateTable(
                "dbo.MultiLanguages",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        ControlId = c.String(),
                        ControlText = c.String(),
                        Language = c.String(),
                        CreatedDate = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tbl_OngoingFormationDoc",
                c => new
                    {
                        OngoingFormationId = c.Int(nullable: false, identity: true),
                        DoccumentName = c.String(maxLength: 50),
                        Title = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        File = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.OngoingFormationId);
            
            CreateTable(
                "dbo.tbl_OVCDoc",
                c => new
                    {
                        OvcDocId = c.Int(nullable: false, identity: true),
                        DoccumentName = c.String(maxLength: 50),
                        Title = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        Phonenumber = c.String(maxLength: 50),
                        Address = c.String(maxLength: 500),
                        File = c.String(maxLength: 50),
                        Photo = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.OvcDocId);
            
            CreateTable(
                "dbo.Tbl_Paris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MyId = c.String(maxLength: 50),
                        YearOfEstablacement = c.String(maxLength: 50),
                        ParisName = c.String(maxLength: 50),
                        Place = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        Tial = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        Description = c.String(maxLength: 50),
                        FileName = c.String(maxLength: 500),
                        CreatedDate = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_ParisInstitutionDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MyId = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        Place = c.String(maxLength: 50),
                        Type = c.String(maxLength: 50),
                        YearOfEstablacement = c.String(maxLength: 50),
                        Address = c.String(),
                        FileName = c.String(maxLength: 100),
                        ParisId = c.String(maxLength: 100),
                        SocietyId = c.String(maxLength: 100),
                        Telephone = c.String(maxLength: 100),
                        InstitutionType = c.String(maxLength: 20),
                        TypesOfReg = c.String(maxLength: 320),
                        RegistrationNo = c.String(maxLength: 100),
                        DiscCode = c.String(maxLength: 50),
                        TypeCode = c.String(maxLength: 50),
                        RegIdCode = c.String(maxLength: 50),
                        BEORegCode = c.String(maxLength: 50),
                        CertificationCode = c.String(maxLength: 50),
                        OtherDoc = c.String(maxLength: 50),
                        Doc1 = c.String(maxLength: 50),
                        Doc2 = c.String(maxLength: 50),
                        CreatedDate = c.String(maxLength: 50),
                        Tial = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        Description = c.String(maxLength: 50),
                        Country = c.String(maxLength: 50),
                        EmailId = c.String(maxLength: 50),
                        DisSec = c.String(maxLength: 150),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_Passed",
                c => new
                    {
                        PassedId = c.Long(nullable: false, identity: true),
                        MemberID = c.String(nullable: false, maxLength: 15),
                        Name = c.String(maxLength: 256),
                        LastCommunity = c.String(maxLength: 256),
                        Cause = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        CurrentStatusFor = c.String(maxLength: 150),
                        CurrentStatusAppo = c.String(maxLength: 150),
                        Time = c.String(maxLength: 10),
                        InstitutionPlace = c.String(maxLength: 50),
                        LastNatureRites = c.String(maxLength: 256),
                        LastPlaceRites = c.String(maxLength: 256),
                        DeathCertificate = c.String(),
                        obituary = c.String(),
                        Spare1 = c.String(maxLength: 35),
                        Spare2 = c.String(maxLength: 35),
                        Spare3 = c.String(maxLength: 35),
                        SirName = c.String(maxLength: 35),
                        Description = c.String(maxLength: 500),
                        Title = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                        tbl_PersonalDetails_PersonalDetailsId = c.Long(),
                    })
                .PrimaryKey(t => t.PassedId)
                .ForeignKey("dbo.tbl_PersonalDetails", t => t.tbl_PersonalDetails_PersonalDetailsId)
                .Index(t => t.tbl_PersonalDetails_PersonalDetailsId);
            
            CreateTable(
                "dbo.tbl_Primarydetails",
                c => new
                    {
                        Primaryid = c.Int(nullable: false, identity: true),
                        MemberId = c.String(maxLength: 50),
                        Knowname = c.String(maxLength: 50),
                        Baptismialname = c.String(maxLength: 50),
                        DOB = c.String(maxLength: 50),
                        DOB1 = c.String(maxLength: 50),
                        Feastday = c.String(maxLength: 50),
                        Bloodgroup = c.String(maxLength: 50),
                        emailid = c.String(maxLength: 50),
                        mobilenumber = c.String(maxLength: 50),
                        placeofbirth = c.String(maxLength: 50),
                        noofbrother = c.String(maxLength: 50),
                        noofsisters = c.String(maxLength: 50),
                        placeinfamily = c.String(maxLength: 50),
                        homediocese = c.String(maxLength: 50),
                        homeparish = c.String(maxLength: 50),
                        house = c.String(maxLength: 50),
                        city = c.String(maxLength: 50),
                        district = c.String(maxLength: 50),
                        Congregation = c.String(maxLength: 50),
                        state = c.String(),
                        pin = c.String(maxLength: 50),
                        adhar = c.String(maxLength: 50),
                        pan = c.String(maxLength: 50),
                        passport = c.String(maxLength: 50),
                        DrivingLicense = c.String(maxLength: 50),
                        nameonadhar = c.String(maxLength: 50),
                        nameonpan = c.String(maxLength: 50),
                        nameonpassport = c.String(maxLength: 50),
                        File1 = c.String(),
                        File2 = c.String(),
                        File3 = c.String(),
                        Ordination = c.String(maxLength: 50),
                        UploadPhoto = c.String(),
                        country = c.String(maxLength: 50),
                        mothertounge = c.String(maxLength: 50),
                        Nationality = c.String(maxLength: 50),
                        OtherName = c.String(),
                        FathersBaptismialName = c.String(),
                        FatherName = c.String(),
                        MotherName = c.String(),
                        MothersBaptismialName = c.String(),
                        Paris = c.String(),
                        PlaceInTheFamily = c.String(),
                        Diocese = c.String(),
                        HouseNo = c.String(),
                        HouseName = c.String(),
                        Distict = c.String(),
                        Pincode = c.String(),
                        Will = c.String(),
                        SurName = c.String(),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.Primaryid);
            
            CreateTable(
                "dbo.tbl_Province",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        MyId = c.String(),
                        ProvinceName = c.String(),
                        Place = c.String(),
                        Place1 = c.String(),
                        ActiveCkeck = c.String(),
                        Phone = c.String(),
                        Country = c.String(),
                        EmailId = c.String(),
                        History = c.String(),
                        CreatedDate = c.String(),
                        DisSec = c.String(),
                        File = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_ProvinceCouncil",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProvinceName = c.String(maxLength: 150),
                        ProvinceId = c.String(maxLength: 150),
                        Superior = c.String(maxLength: 150),
                        SuperiorDes = c.String(maxLength: 150),
                        AssSuperior = c.String(maxLength: 150),
                        AssSuperiorDes = c.String(maxLength: 150),
                        CouncilorName = c.String(maxLength: 150),
                        CouncilorDes = c.String(maxLength: 150),
                        CouncilorName1 = c.String(maxLength: 150),
                        Councilor1Des = c.String(maxLength: 150),
                        CouncilorName2 = c.String(maxLength: 150),
                        Councilor2Des = c.String(maxLength: 150),
                        CouncilorName3 = c.String(maxLength: 150),
                        Councilor3Des = c.String(maxLength: 150),
                        FromDate = c.String(maxLength: 150),
                        ToDate = c.String(maxLength: 150),
                        ComMemName = c.String(maxLength: 150),
                        ComMemDes = c.String(maxLength: 150),
                        ComMemName1 = c.String(maxLength: 150),
                        ComMemDes1 = c.String(maxLength: 150),
                        ComMemName2 = c.String(maxLength: 150),
                        ComMemDes2 = c.String(maxLength: 150),
                        Secretory = c.String(maxLength: 150),
                        SecretoryDes = c.String(maxLength: 150),
                        Bursar = c.String(maxLength: 150),
                        BursarDes = c.String(maxLength: 150),
                        History = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_provinceData",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ProvinceId = c.String(),
                        MyId = c.String(),
                        Title = c.String(),
                        Date = c.String(),
                        Description = c.String(),
                        File = c.String(),
                        CreatedDate = c.String(),
                        ProvinceName = c.String(maxLength: 550),
                        ActiveCkeck = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tbl_ProvincialDoc",
                c => new
                    {
                        ProvincialId = c.Int(nullable: false, identity: true),
                        DoccumentName = c.String(maxLength: 50),
                        Title = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        File = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.ProvincialId);
            
            CreateTable(
                "dbo.tbl_ReligiousEducation",
                c => new
                    {
                        ReligiousId = c.Long(nullable: false, identity: true),
                        MemberID = c.String(nullable: false, maxLength: 15),
                        Name = c.String(maxLength: 200),
                        DegreeName = c.String(maxLength: 100),
                        FromDate = c.String(maxLength: 10),
                        ToDate = c.String(maxLength: 10),
                        University = c.String(maxLength: 300),
                        Address = c.String(maxLength: 500),
                        ClassObtained = c.String(maxLength: 35),
                        Remarks = c.String(maxLength: 35),
                        Spare1 = c.String(maxLength: 35),
                        Spare2 = c.String(maxLength: 35),
                        Spare3 = c.String(maxLength: 35),
                        Certificate = c.String(),
                        SirName = c.String(),
                        ProvinceName = c.String(maxLength: 550),
                        tbl_PersonalDetails_PersonalDetailsId = c.Long(),
                    })
                .PrimaryKey(t => t.ReligiousId)
                .ForeignKey("dbo.tbl_PersonalDetails", t => t.tbl_PersonalDetails_PersonalDetailsId)
                .Index(t => t.tbl_PersonalDetails_PersonalDetailsId);
            
            CreateTable(
                "dbo.Tbl_RenewalVows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MyId = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        Superior = c.String(maxLength: 50),
                        Duration = c.String(maxLength: 550),
                        Witness = c.String(maxLength: 50),
                        RenVowsDoc = c.String(maxLength: 50),
                        Check = c.String(maxLength: 50),
                        CurrentStatus = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_Retirement",
                c => new
                    {
                        RetirementId = c.Long(nullable: false, identity: true),
                        MemberID = c.String(nullable: false, maxLength: 15),
                        Name = c.String(maxLength: 256),
                        DOR = c.String(maxLength: 10),
                        Age = c.String(),
                        Reason = c.String(maxLength: 200),
                        Community = c.String(maxLength: 200),
                        Remarks = c.String(maxLength: 75),
                        Spare1 = c.String(maxLength: 35),
                        Spare2 = c.String(maxLength: 35),
                        Spare3 = c.String(maxLength: 35),
                        SirName = c.String(maxLength: 35),
                        ProvinceName = c.String(maxLength: 550),
                        tbl_PersonalDetails_PersonalDetailsId = c.Long(),
                    })
                .PrimaryKey(t => t.RetirementId)
                .ForeignKey("dbo.tbl_PersonalDetails", t => t.tbl_PersonalDetails_PersonalDetailsId)
                .Index(t => t.tbl_PersonalDetails_PersonalDetailsId);
            
            CreateTable(
                "dbo.tbl_SCTDoc",
                c => new
                    {
                        SctDocId = c.Int(nullable: false, identity: true),
                        DoccumentName = c.String(maxLength: 50),
                        Title = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        Phonenumber = c.String(maxLength: 50),
                        Address = c.String(maxLength: 500),
                        File = c.String(maxLength: 50),
                        Photo = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.SctDocId);
            
            CreateTable(
                "dbo.tbl_SecularEducation",
                c => new
                    {
                        SecularId = c.Long(nullable: false, identity: true),
                        MemberID = c.String(maxLength: 15),
                        Name = c.String(maxLength: 100),
                        DegreeName = c.String(maxLength: 100),
                        FromDate = c.String(maxLength: 10),
                        ToDate = c.String(maxLength: 10),
                        University = c.String(maxLength: 35),
                        Address = c.String(maxLength: 35),
                        ClassObtained = c.String(maxLength: 35),
                        Medium = c.String(maxLength: 35),
                        Remarks = c.String(maxLength: 300),
                        Title = c.String(maxLength: 35),
                        Course = c.String(maxLength: 35),
                        Spare3 = c.String(maxLength: 35),
                        Certificate = c.String(),
                        ProvinceName = c.String(maxLength: 550),
                        SirName = c.String(),
                    })
                .PrimaryKey(t => t.SecularId);
            
            CreateTable(
                "dbo.tbl_Seminar",
                c => new
                    {
                        SeminarId = c.Long(nullable: false, identity: true),
                        MemberID = c.String(nullable: false, maxLength: 15),
                        Community = c.String(maxLength: 256),
                        Name = c.String(maxLength: 256),
                        FromDate = c.String(maxLength: 10),
                        ToDate = c.String(maxLength: 10),
                        SeminarName = c.String(maxLength: 256),
                        Place = c.String(maxLength: 256),
                        Institute = c.String(maxLength: 256),
                        Spare1 = c.String(maxLength: 35),
                        Spare2 = c.String(maxLength: 35),
                        Spare3 = c.String(maxLength: 35),
                        SirName = c.String(maxLength: 35),
                        ProvinceName = c.String(maxLength: 550),
                        tbl_PersonalDetails_PersonalDetailsId = c.Long(),
                    })
                .PrimaryKey(t => t.SeminarId)
                .ForeignKey("dbo.tbl_PersonalDetails", t => t.tbl_PersonalDetails_PersonalDetailsId)
                .Index(t => t.tbl_PersonalDetails_PersonalDetailsId);
            
            CreateTable(
                "dbo.tbl_SeperationFromTheCongregation",
                c => new
                    {
                        SeperationId = c.Long(nullable: false, identity: true),
                        MemberID = c.String(nullable: false, maxLength: 15),
                        Name = c.String(maxLength: 256),
                        SeperationDate = c.String(maxLength: 10),
                        Title = c.String(maxLength: 35),
                        Describtion = c.String(maxLength: 35),
                        File = c.String(maxLength: 35),
                        ProvinceName = c.String(maxLength: 550),
                        StageOFFormation = c.String(),
                        tbl_PersonalDetails_PersonalDetailsId = c.Long(),
                    })
                .PrimaryKey(t => t.SeperationId)
                .ForeignKey("dbo.tbl_PersonalDetails", t => t.tbl_PersonalDetails_PersonalDetailsId)
                .Index(t => t.tbl_PersonalDetails_PersonalDetailsId);
            
            CreateTable(
                "dbo.tbl_ServiceInTheCongregation",
                c => new
                    {
                        ServiceId = c.Long(nullable: false, identity: true),
                        MemberID = c.String(nullable: false, maxLength: 15),
                        Name = c.String(maxLength: 256),
                        FromDate = c.String(maxLength: 10),
                        ToDate = c.String(maxLength: 10),
                        Address = c.String(maxLength: 1024),
                        Community = c.String(maxLength: 100),
                        Office = c.String(maxLength: 50),
                        Other = c.String(maxLength: 150),
                        superiorName = c.String(maxLength: 100),
                        EmailId = c.String(maxLength: 200),
                        Spare1 = c.String(maxLength: 35),
                        Spare2 = c.String(maxLength: 35),
                        Spare3 = c.String(maxLength: 35),
                        Certificate = c.String(),
                        ProvinceName = c.String(maxLength: 550),
                        tbl_PersonalDetails_PersonalDetailsId = c.Long(),
                    })
                .PrimaryKey(t => t.ServiceId)
                .ForeignKey("dbo.tbl_PersonalDetails", t => t.tbl_PersonalDetails_PersonalDetailsId)
                .Index(t => t.tbl_PersonalDetails_PersonalDetailsId);
            
            CreateTable(
                "dbo.tbl_Soc_Addminstration",
                c => new
                    {
                        SocityAdministrationId = c.Int(nullable: false, identity: true),
                        SocityName = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        RegNo = c.String(maxLength: 50),
                        PanNo = c.String(maxLength: 50),
                        FCRANo = c.String(maxLength: 500),
                        ANo = c.String(maxLength: 50),
                        GNo = c.String(maxLength: 50),
                        Spare = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.SocityAdministrationId);
            
            CreateTable(
                "dbo.tbl_SocialInstitutionDoc",
                c => new
                    {
                        SocialInstitutionId = c.Int(nullable: false, identity: true),
                        CommunityName = c.String(maxLength: 50),
                        InstitutionName = c.String(maxLength: 50),
                        EstablishDate = c.String(maxLength: 50),
                        Place = c.String(maxLength: 50),
                        Address = c.String(maxLength: 500),
                        ContactNumber = c.String(maxLength: 50),
                        Website = c.String(maxLength: 50),
                        File = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.SocialInstitutionId);
            
            CreateTable(
                "dbo.Tbl_SocietyDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SocietyName = c.String(maxLength: 100),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_Socityadd",
                c => new
                    {
                        SocitydetailsID = c.Int(nullable: false, identity: true),
                        Date = c.String(maxLength: 50),
                        Title = c.String(maxLength: 50),
                        Catogery = c.String(maxLength: 50),
                        Remark = c.String(maxLength: 250),
                        File = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.SocitydetailsID);
            
            CreateTable(
                "dbo.tbl_SpiritualCommunityDoc",
                c => new
                    {
                        SpiritualCommunityId = c.Int(nullable: false, identity: true),
                        DoccumentName = c.String(maxLength: 50),
                        SubDoccument = c.String(maxLength: 50),
                        Title = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        File = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.SpiritualCommunityId);
            
            CreateTable(
                "dbo.tbl_StCamillusProvincialateDoc",
                c => new
                    {
                        StCamillusProvincialateId = c.Int(nullable: false, identity: true),
                        DoccumentName = c.String(maxLength: 50),
                        SubDoccument = c.String(maxLength: 50),
                        Title = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        File = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.StCamillusProvincialateId);
            
            CreateTable(
                "dbo.Tbl_Transfer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.String(maxLength: 150),
                        ProvinceId = c.String(maxLength: 150),
                        NewProvinceName = c.String(maxLength: 150),
                        BrotherName = c.String(maxLength: 150),
                        ProvinceName = c.String(maxLength: 550),
                        Extra = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_TravelRecord",
                c => new
                    {
                        TravelId = c.Long(nullable: false, identity: true),
                        MemberID = c.String(nullable: false, maxLength: 15),
                        Name = c.String(maxLength: 256),
                        FromDate = c.String(maxLength: 256),
                        ToDate = c.String(maxLength: 256),
                        Place = c.String(maxLength: 256),
                        Purpose = c.String(maxLength: 256),
                        Spare1 = c.String(maxLength: 35),
                        Spare2 = c.String(maxLength: 35),
                        Spare3 = c.String(maxLength: 35),
                        SirName = c.String(maxLength: 35),
                        ProvinceName = c.String(maxLength: 550),
                        tbl_PersonalDetails_PersonalDetailsId = c.Long(),
                    })
                .PrimaryKey(t => t.TravelId)
                .ForeignKey("dbo.tbl_PersonalDetails", t => t.tbl_PersonalDetails_PersonalDetailsId)
                .Index(t => t.tbl_PersonalDetails_PersonalDetailsId);
            
            CreateTable(
                "dbo.tbl_unknow",
                c => new
                    {
                        memid = c.Int(nullable: false, identity: true),
                        Knowname = c.String(),
                        Baptismialname = c.String(),
                        DOB = c.String(),
                        DOB1 = c.String(),
                        Feastday = c.String(),
                        Bloodgroup = c.String(),
                        emailid = c.String(),
                        mobilenumber = c.String(),
                        whatsappnumber = c.String(),
                        facebookid = c.String(),
                        twitterid = c.String(),
                        blog = c.String(),
                        house = c.String(),
                        city = c.String(),
                        district = c.String(),
                        state = c.String(),
                        pin = c.String(),
                        adhar = c.String(),
                        pan = c.String(),
                        nameonadhar = c.String(),
                        File1 = c.String(),
                        File2 = c.String(),
                        nameonpan = c.String(),
                    })
                .PrimaryKey(t => t.memid);
            
            CreateTable(
                "dbo.Tbl_UserLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        UserPassword = c.String(nullable: false),
                        UserRole = c.String(),
                        Spare1 = c.String(),
                        Spare2 = c.String(),
                        Spare3 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_UserModuleLogin",
                c => new
                    {
                        LoginId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        UserPassword = c.String(nullable: false),
                        UserRole = c.String(),
                        Spare1 = c.String(),
                        Spare2 = c.String(),
                        Spare3 = c.String(),
                    })
                .PrimaryKey(t => t.LoginId);
            
            CreateTable(
                "dbo.tbl_VocationalTrainingDoc",
                c => new
                    {
                        VocationalTrainingId = c.Int(nullable: false, identity: true),
                        DoccumentName = c.String(maxLength: 50),
                        Title = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        Phonenumber = c.String(maxLength: 50),
                        Activities = c.String(maxLength: 50),
                        File = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.VocationalTrainingId);
            
            CreateTable(
                "dbo.tbl_VocationPromotionDoc",
                c => new
                    {
                        VocationPromotionId = c.Int(nullable: false, identity: true),
                        DoccumentName = c.String(maxLength: 50),
                        Title = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        Phonenumber = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        File = c.String(maxLength: 50),
                        ProvinceName = c.String(maxLength: 550),
                    })
                .PrimaryKey(t => t.VocationPromotionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_TravelRecord", "tbl_PersonalDetails_PersonalDetailsId", "dbo.tbl_PersonalDetails");
            DropForeignKey("dbo.tbl_ServiceInTheCongregation", "tbl_PersonalDetails_PersonalDetailsId", "dbo.tbl_PersonalDetails");
            DropForeignKey("dbo.tbl_SeperationFromTheCongregation", "tbl_PersonalDetails_PersonalDetailsId", "dbo.tbl_PersonalDetails");
            DropForeignKey("dbo.tbl_Seminar", "tbl_PersonalDetails_PersonalDetailsId", "dbo.tbl_PersonalDetails");
            DropForeignKey("dbo.tbl_Retirement", "tbl_PersonalDetails_PersonalDetailsId", "dbo.tbl_PersonalDetails");
            DropForeignKey("dbo.tbl_ReligiousEducation", "tbl_PersonalDetails_PersonalDetailsId", "dbo.tbl_PersonalDetails");
            DropForeignKey("dbo.tbl_Passed", "tbl_PersonalDetails_PersonalDetailsId", "dbo.tbl_PersonalDetails");
            DropForeignKey("dbo.tbl_LivingOutsideTheCongregation", "tbl_PersonalDetails_PersonalDetailsId", "dbo.tbl_PersonalDetails");
            DropForeignKey("dbo.tbl_Jubilee", "tbl_PersonalDetails_PersonalDetailsId", "dbo.tbl_PersonalDetails");
            DropForeignKey("dbo.tbl_HomeLiveAndHomeVisit", "tbl_PersonalDetails_PersonalDetailsId", "dbo.tbl_PersonalDetails");
            DropForeignKey("dbo.tbl_Health", "tbl_PersonalDetails_PersonalDetailsId", "dbo.tbl_PersonalDetails");
            DropForeignKey("dbo.tbl_EntryLife1", "tbl_PersonalDetails_PersonalDetailsId", "dbo.tbl_PersonalDetails");
            DropForeignKey("dbo.tbl_EntryLife", "tbl_PersonalDetails_PersonalDetailsId", "dbo.tbl_PersonalDetails");
            DropForeignKey("dbo.tbl_EmergencyContact", "tbl_PersonalDetails_PersonalDetailsId", "dbo.tbl_PersonalDetails");
            DropIndex("dbo.tbl_TravelRecord", new[] { "tbl_PersonalDetails_PersonalDetailsId" });
            DropIndex("dbo.tbl_ServiceInTheCongregation", new[] { "tbl_PersonalDetails_PersonalDetailsId" });
            DropIndex("dbo.tbl_SeperationFromTheCongregation", new[] { "tbl_PersonalDetails_PersonalDetailsId" });
            DropIndex("dbo.tbl_Seminar", new[] { "tbl_PersonalDetails_PersonalDetailsId" });
            DropIndex("dbo.tbl_Retirement", new[] { "tbl_PersonalDetails_PersonalDetailsId" });
            DropIndex("dbo.tbl_ReligiousEducation", new[] { "tbl_PersonalDetails_PersonalDetailsId" });
            DropIndex("dbo.tbl_Passed", new[] { "tbl_PersonalDetails_PersonalDetailsId" });
            DropIndex("dbo.tbl_LivingOutsideTheCongregation", new[] { "tbl_PersonalDetails_PersonalDetailsId" });
            DropIndex("dbo.tbl_Jubilee", new[] { "tbl_PersonalDetails_PersonalDetailsId" });
            DropIndex("dbo.tbl_HomeLiveAndHomeVisit", new[] { "tbl_PersonalDetails_PersonalDetailsId" });
            DropIndex("dbo.tbl_Health", new[] { "tbl_PersonalDetails_PersonalDetailsId" });
            DropIndex("dbo.tbl_EntryLife1", new[] { "tbl_PersonalDetails_PersonalDetailsId" });
            DropIndex("dbo.tbl_EntryLife", new[] { "tbl_PersonalDetails_PersonalDetailsId" });
            DropIndex("dbo.tbl_EmergencyContact", new[] { "tbl_PersonalDetails_PersonalDetailsId" });
            DropTable("dbo.tbl_VocationPromotionDoc");
            DropTable("dbo.tbl_VocationalTrainingDoc");
            DropTable("dbo.tbl_UserModuleLogin");
            DropTable("dbo.Tbl_UserLogins");
            DropTable("dbo.tbl_unknow");
            DropTable("dbo.tbl_TravelRecord");
            DropTable("dbo.Tbl_Transfer");
            DropTable("dbo.tbl_StCamillusProvincialateDoc");
            DropTable("dbo.tbl_SpiritualCommunityDoc");
            DropTable("dbo.tbl_Socityadd");
            DropTable("dbo.Tbl_SocietyDetails");
            DropTable("dbo.tbl_SocialInstitutionDoc");
            DropTable("dbo.tbl_Soc_Addminstration");
            DropTable("dbo.tbl_ServiceInTheCongregation");
            DropTable("dbo.tbl_SeperationFromTheCongregation");
            DropTable("dbo.tbl_Seminar");
            DropTable("dbo.tbl_SecularEducation");
            DropTable("dbo.tbl_SCTDoc");
            DropTable("dbo.tbl_Retirement");
            DropTable("dbo.Tbl_RenewalVows");
            DropTable("dbo.tbl_ReligiousEducation");
            DropTable("dbo.tbl_ProvincialDoc");
            DropTable("dbo.Tbl_provinceData");
            DropTable("dbo.Tbl_ProvinceCouncil");
            DropTable("dbo.tbl_Province");
            DropTable("dbo.tbl_Primarydetails");
            DropTable("dbo.tbl_Passed");
            DropTable("dbo.Tbl_ParisInstitutionDetails");
            DropTable("dbo.Tbl_Paris");
            DropTable("dbo.tbl_OVCDoc");
            DropTable("dbo.tbl_OngoingFormationDoc");
            DropTable("dbo.MultiLanguages");
            DropTable("dbo.tbl_MissionDoc");
            DropTable("dbo.tbl_MinistryDoc");
            DropTable("dbo.tbl_LivingOutsideTheCongregation");
            DropTable("dbo.Tbl_LandDocuments");
            DropTable("dbo.tbl_LandDetails");
            DropTable("dbo.tbl_KnownLanguages");
            DropTable("dbo.tbl_Jubilee");
            DropTable("dbo.tbl_Insurance");
            DropTable("dbo.tbl_InstitutionFinal");
            DropTable("dbo.tbl_institution123");
            DropTable("dbo.Tbl_Institution");
            DropTable("dbo.tbl_InstDetails");
            DropTable("dbo.tbl_Inst");
            DropTable("dbo.tbl_HomeLiveAndHomeVisit");
            DropTable("dbo.tbl_Health");
            DropTable("dbo.Tbl_GovernerSoc");
            DropTable("dbo.Tbl_Governer");
            DropTable("dbo.tbl_GeneralMattersDoc");
            DropTable("dbo.tbl_GeneralateDoc");
            DropTable("dbo.tbl_FundRaisingCommiteeDoc");
            DropTable("dbo.tbl_FormatorsMeetDoc");
            DropTable("dbo.Tbl_FormationTypes");
            DropTable("dbo.Tbl_formationsDetails");
            DropTable("dbo.tbl_FomDoc");
            DropTable("dbo.tbl_FinancialReportDoc");
            DropTable("dbo.tbl_FinancialGuidelineDoc");
            DropTable("dbo.tbl_EntryLife1");
            DropTable("dbo.tbl_EntryLife");
            DropTable("dbo.tbl_Entry");
            DropTable("dbo.tbl_PersonalDetails");
            DropTable("dbo.tbl_EmergencyContact");
            DropTable("dbo.tbl_Congregation");
            DropTable("dbo.Tbl_CongrationsData");
            DropTable("dbo.Tbl_Cong");
            DropTable("dbo.tbl_ConfreresDoc");
            DropTable("dbo.tbl_Complaint");
            DropTable("dbo.Tbl_Complains");
            DropTable("dbo.tbl_CommunitiesSocialCentresDoc");
            DropTable("dbo.tbl_CommunicationOfficeDoc");
            DropTable("dbo.tbl_CommonDataListItems");
            DropTable("dbo.tbl_CommonDataList");
            DropTable("dbo.Tbl_Comm");
            DropTable("dbo.tbl_CandidatesInformationDoc");
            DropTable("dbo.tbl_BookOfAccountsDoc");
            DropTable("dbo.tbl_Bank_Details");
            DropTable("dbo.tbl_Archive");
            DropTable("dbo.tbl_Academy");
            DropTable("dbo.SocInsPages");
            DropTable("dbo.Societys");
            DropTable("dbo.SocietyDatas");
            DropTable("dbo.Sacraments");
            DropTable("dbo.RolePermissions");
            DropTable("dbo.RolePagePermissions");
            DropTable("dbo.ProvinceDatas");
            DropTable("dbo.MyDataCOS");
            DropTable("dbo.MyComDataCHes");
            DropTable("dbo.FamilyDetails");
            DropTable("dbo.DataLists2");
            DropTable("dbo.DataLists");
            DropTable("dbo.DataListItems2");
            DropTable("dbo.DataListItems");
            DropTable("dbo.CounCircCommis");
            DropTable("dbo.CongreDatas");
            DropTable("dbo.CongDatas");
            DropTable("dbo.ComOutSideDetails");
            DropTable("dbo.ComOutSides");
            DropTable("dbo.ComHouseDetails");
            DropTable("dbo.ComHouses");
            DropTable("dbo.Appointments");
            DropTable("dbo.AppointmentDatas");
            DropTable("dbo.AllProvinceRecords");
        }
    }
}
