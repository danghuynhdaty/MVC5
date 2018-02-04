namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("About")]
    public partial class About
    {
        public int ID { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage ="Tên không được rỗng")]
        [Display(Name = "Tên")]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "Mô tả không được rỗng")]
        public string Description { get; set; }

        [StringLength(250)]
        [Display(Name = "Hình ảnh")]
        [Required(ErrorMessage = "Hình ảnh không được rỗng")]
        public string Image { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Chi tiết")]
        public string Detail { get; set; }

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
    }
}
