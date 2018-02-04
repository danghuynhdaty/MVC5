namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        public int ID { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên menu")]
        public string Text { get; set; }

        [StringLength(250)]
        [Display(Name = "Liên kết")]
        public string Link { get; set; }

        [Display(Name = "Thứ tự hiển thị")]
        public int? DisplayOrder { get; set; }

        [StringLength(50)]
        [Display(Name = "Mục tiêu")]
        public string Target { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

        [Display(Name = "Loại")]
        public int TypeID { get; set; }
    }
}
