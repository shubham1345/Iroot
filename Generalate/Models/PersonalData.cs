using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class PersonalData
    {

        public string ID { get; set; }
        public string MemberID { get; set; }
        public string Name { get; set; }
        public string PDocumentCategory { get; set; }
        public string PDocumentSubCategory { get; set; }
        public string PYear { get; set; }
        public HttpPostedFileBase[] files { get; set; }
 
        public string ProvinceName { get; set; }
    }
}

//ID	int	
//DocumentId	int	
//Filename	nvarchar(200)	
//ArchivedFile	uniqueidentifier	
//FileContent	varbinary(MAX)	
//FileMIMEtype	varchar(2000)	
//FileExtension	varchar(5)	
//Filesendtime	date	
//Username	nvarchar(MAX)	
//[Adhar No]	nvarchar(MAX)	
//FileSentdate	datetime	
//PANCopy	nvarchar(MAX)	
//UserId	nchar(10)	
//PDocumentCategory	nvarchar(50)	
//PDocumentSubCategory	nvarchar(50)	
//PYear	nvarchar(50)	
		