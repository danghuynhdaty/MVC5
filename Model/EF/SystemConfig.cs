namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SystemConfig")]
    public partial class SystemConfig
    {
        [StringLength(50)]
        public string ID { get; set; }


        [StringLength(50)]
        [Display(Name = "Tên")]
        [Required(ErrorMessage ="Tên không được rỗng")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Loại")]
        public string Type { get; set; }

        [StringLength(50)]
        [Display(Name = "Giá trị")]
        [Required(ErrorMessage ="Giá trị không được rỗng")]
        public string Value { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }
    }
}
