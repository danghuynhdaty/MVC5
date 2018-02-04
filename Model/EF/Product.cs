namespace Model.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Product")]
    public partial class Product
    {
        public int ID { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được rỗng")]
        public string Name { get; set; }

        [StringLength(20)]
        [Display(Name = "Mã sản phẩm")]
        [Required(ErrorMessage = "Mã sản phẩm không được rỗng")]
        public string Code { get; set; }

        [StringLength(250)]
        [Display(Name = "Tiêu đề liên kết")]
        public string MetaTitle { get; set; }

        [Display(Name = "Mô tả sản phẩm")]
        [Column(TypeName = "nvarchar")]
        [Required(ErrorMessage = "Mô tả sản phẩm không được rỗng")]
        public string Description { get; set; }

        [StringLength(250)]
        [Display(Name = "Hình ảnh")]
        [Required(ErrorMessage = "Hình ảnh sản phẩm không được rỗng")]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        [Display(Name = "Danh sách hình ảnh")]
        public string Images { get; set; }

        [Display(Name = "Giá sản phẩm")]
        [Required(ErrorMessage = "Giá sản phẩm không được rỗng")]
        [Range(0, uint.MaxValue, ErrorMessage = "Giá sản phẩm phải là số dương")]
        public decimal Price { get; set; }

        [Display(Name = "Giá khuyến mãi")]
        [Range(0, uint.MaxValue, ErrorMessage = "Giá khuyến mãi phải là số dương")]
        public decimal? PromotionPrice { get; set; }

        [Display(Name = "VAT")]
        public bool IncludeVAT { get; set; }

        [Display(Name = "Số lượng")]
        [Range(0, uint.MaxValue, ErrorMessage = "Số lượng phải là số dương")]
        public int Quantity { get; set; }

        [Display(Name = "Loại sản phẩm")]
        public int CategoryID { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Chi tiết sản phẩm")]
        public string Detail { get; set; }

        [Display(Name = "Thời gian bảo hành (Tháng)")]
        [Range(0, 50, ErrorMessage = "Thời gian bảo hành phải là số dương")]
        public int? Warranty { get; set; }

        [StringLength(250)]
        [Display(Name = "Tiêu đề SEO")]
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

        public DateTime? TopMost { get; set; }

        [Display(Name = "Số lượt xem")]
        public int? ViewCount { get; set; }
    }
}