namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        public int ID { get; set; }

        [Display(Name="Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không được rỗng")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage ="Mật khẩu không được rỗng")]
        [StringLength(32)]
        public string PassWord { get; set; }


        [StringLength(50)]
        [Display(Name = "Tên người dùng")]
        [Required(ErrorMessage = "Tên người dùng không được rỗng")]
        public string Name { get; set; }

        [StringLength(250)]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(250)]
        [Display(Name = "Người tạo")]
        public string CreatedBy { get; set; }

        [Display(Name = "Ngày chỉnh sửa")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Chỉnh sửa bởi")]
        public int? ModifiedBy { get; set; }
    }
}
