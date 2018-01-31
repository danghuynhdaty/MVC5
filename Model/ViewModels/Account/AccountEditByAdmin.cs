using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModels.Account
{
    public class AccountEditByAdmin
    {

        public int ID { get; set; }

        [Display(Name = "Tên đăng nhập")]
        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên người dùng")]
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

        [Display(Name = "Người chỉnh sửa")]
        public int? ModifiedBy { get; set; }
    }
}
