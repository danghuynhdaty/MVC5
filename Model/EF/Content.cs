namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Content")]
    public partial class Content
    {
        public Content(long iD, string name, string metaTitle, string description, string image, long categoryID, string detail, string seoTitle, DateTime? createdDate, string createdBy, DateTime? modifiedDate, DateTime? modifiedBy, string metaKeyWords, string metaDescription, bool? status, DateTime? topMost, int? viewCount, string tags)
        {
            ID = iD;
            Name = name;
            MetaTitle = metaTitle;
            Description = description;
            Image = image;
            CategoryID = categoryID;
            Detail = detail;
            SeoTitle = seoTitle;
            CreatedDate = createdDate;
            CreatedBy = createdBy;
            ModifiedDate = modifiedDate;
            ModifiedBy = modifiedBy;
            MetaKeyWords = metaKeyWords;
            MetaDescription = metaDescription;
            Status = status;
            TopMost = topMost;
            ViewCount = viewCount;
            Tags = tags;
        }

        public Content()
        {
        }

        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public long CategoryID { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        [StringLength(250)]
        public string SeoTitle { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public DateTime? ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeyWords { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }

        public bool? Status { get; set; }

        public DateTime? TopMost { get; set; }

        public int? ViewCount { get; set; }

        [StringLength(500)]
        public string Tags { get; set; }




    }
}
