namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CategoryNew
    {
        public int ID { get; set; }

        [StringLength(250)]
        [Display(Name="Tên")]
        [Required(ErrorMessage = "Tên không được rỗng")]
        public string Name { get; set; }

        [StringLength(250)]
        [Display(Name = "Tiêu đề liên kết")]
        public string MetaTitle { get; set; }

        [Display(Name = "Danh mục cha")]
        public int? ParentID { get; set; }

        [Display(Name = "Thứ tự hiển thị")]
        public int? DisplayOrder { get; set; }

        [StringLength(250)]
        [Display(Name = "Tiêu đề SEO")]
        [Required(ErrorMessage = "Tiêu đề SEO không được rỗng")]
        public string SeoTitle { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(250)]
        [Display(Name = "Người tạo")]
        public string CreatedBy { get; set; }

        [Display(Name = "Ngày chỉnh sửa")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Người chỉnh sửa")]
        public DateTime? ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeyWords { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

        [Display(Name = "Hiển thị trên trang chủ")]
        public bool? ShowOnHome { get; set; }
    }
}
