namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public long ID { get; set; }

        [StringLength(250, ErrorMessage = "Tên sản phẩm không vượt quá 250 ký tự"), MinLength(1, ErrorMessage = "Độ dài tối thiểu 1 ký tự")]
        [DisplayName("Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        public string Name { get; set; }

        [StringLength(10)]
        [DisplayName("Mã sản phẩm")]
        public string Code { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Meta title không được để trống")]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        [DisplayName("Mô tả")]
        public string Description { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }



        [DisplayName("Giá gốc")]
        [DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode = true)]

        [DataType(DataType.Currency)]

        public decimal? Price { get; set; }


        [DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode = true)]

        [DataType(DataType.Currency)]
        [DisplayName("Giá khuyến mãi")]
        public decimal? PromotionPrice { get; set; }


        [DisplayName("Bao gồm VAT")]
        public bool? IncludedVAT { get; set; }



        [DisplayName("Số lượng")]
        public int Quantity { get; set; }


        [DisplayName("Loại sản phẩm")]
        [Required(ErrorMessage = "Loại sản phẩm không được để trống")]
        public long CategoryID { get; set; }


        [DisplayName("Bài Giới thiệu")]
        [Column(TypeName = "ntext")]
        public string Detail { get; set; }


        [DisplayName("Bảo hành")]
        public int? Warranty { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }

        public bool? Status { get; set; }

        public DateTime? TopHot { get; set; }

        public int? ViewCount { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }


    }
}
