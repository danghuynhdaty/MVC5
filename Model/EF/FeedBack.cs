namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FeedBack")]
    public partial class FeedBack
    {
        public int ID { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên người dùng")]
        [Required(ErrorMessage ="Tên không được rỗng")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage ="Số điện thoại không được rỗng")]
        public string Phone { get; set; }

        [StringLength(50)]        
        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Column(TypeName = "ntext")]
        public string FbContent { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }
    }
}
