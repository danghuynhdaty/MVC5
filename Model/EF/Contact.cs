namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contact")]
    public partial class Contact
    {
        public int ID { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Nội dung liên hệ")]
        [Required(ErrorMessage ="Nội dung không được rỗng")]
        public string ContactContent { get; set; }

        [Display(Name = "Trạng thái")]
        public int? Status { get; set; }
    }
}
