//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Generalate.Models.Edmx
{
    using System;
    
    public partial class GetInboxByMailId_Result
    {
        public Nullable<long> Slno { get; set; }
        public Nullable<long> FileSlno { get; set; }
        public Nullable<int> FileCount { get; set; }
        public string EmailUid { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string CCAddress { get; set; }
        public string BCCAddress { get; set; }
        public Nullable<System.DateTime> EmailDate { get; set; }
        public string Subject { get; set; }
        public byte[] Body { get; set; }
        public Nullable<int> MailType { get; set; }
        public bool IsDeleted { get; set; }
        public System.Guid ID { get; set; }
        public string asciiBody { get; set; }
        public string utfBody { get; set; }
        public string utfsBody { get; set; }
        public System.Guid InboxEmailID { get; set; }
        public byte[] Attachment { get; set; }
        public string Filename { get; set; }
        public System.Guid FileId { get; set; }
    }
}