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
    using System.Collections.Generic;
    
    public partial class Document
    {
        public int ID { get; set; }
        public Nullable<int> CommunityId { get; set; }
        public Nullable<int> PlaceId { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> CityId { get; set; }
        public Nullable<int> DistrictId { get; set; }
        public Nullable<int> DocumentCategoryId { get; set; }
        public Nullable<int> DocumentSubCategoryId { get; set; }
        public Nullable<int> Year { get; set; }
        public string DocumentName { get; set; }
    }
}
