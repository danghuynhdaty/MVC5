namespace Model.EF
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ContentTag")]
    public partial class ContentTag
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Mã bài viết")]
        public int ContentID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        [Display(Name = "Tags")]
        [Required(ErrorMessage = "Tags không được rỗng")]
        public string TagID { get; set; }
    }
}