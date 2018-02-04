namespace Model.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Content")]
    public partial class Content
    {
        public int ID { get; set; }

        [Display(Name = "Tên bài viết")]
        [Required(ErrorMessage = "Tên bài viết không được rỗng")]
        [StringLength(250)]
        public string Name { get; set; }

        [Display(Name = "Tiêu đề liên kết")]
        [Required(ErrorMessage = "Tiêu đề liên kết không được rỗng")]
        [StringLength(250)]
        public string MetaTitle { get; set; }

        [Display(Name = "Mô tả bài viết")]
        [StringLength(500)]
        public string Description { get; set; }

        [Display(Name = "Hình ảnh")]
        [Required(ErrorMessage = "Hình ảnh không được rỗng")]
        [StringLength(250)]
        public string Image { get; set; }

        [Display(Name = "Loại bài viết")]
        public int CategoryID { get; set; }

        [Display(Name = "Nội dung bài viết")]
        [Required(ErrorMessage = "Nội dung bài viết không được rỗng")]
        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        [Display(Name = "Tiêu đề SEO")]
        [Required(ErrorMessage = "Tiêu đề seo không được rỗng")]
        [StringLength(250)]
        public string SeoTitle { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Người tạo")]
        [StringLength(250)]
        public string CreatedBy { get; set; }

        [Display(Name = "Ngày chỉnh sửa")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Người chỉnh sửa")]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeyWords { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

        public DateTime? TopMost { get; set; }

        [Display(Name = "Số lượt xem")]
        public int? ViewCount { get; set; }

        [StringLength(500)]
        [Display(Name = "Tag bài viết")]
        public string Tags { get; set; }
    }
}