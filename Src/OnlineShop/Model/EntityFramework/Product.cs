namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
            ProductAttributes = new HashSet<ProductAttribute>();
            ProductLinks = new HashSet<ProductLink>();
            ProductLinks1 = new HashSet<ProductLink>();
        }

        public int Id { get; set; }

        [StringLength(128)]
        public string Name { get; set; }

        public int? CatalogId { get; set; }

        [StringLength(128)]
        public string Description { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public decimal? Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        [StringLength(128)]
        public string Image { get; set; }

        [StringLength(128)]
        public string ThumbImage { get; set; }

        public string ImageList { get; set; }

        [StringLength(128)]
        public string SiteTitle { get; set; }

        [StringLength(158)]
        public string MetaKeywords { get; set; }

        [StringLength(158)]
        public string MetaDescription { get; set; }

        public int? ViewCount { get; set; }

        public int? Warranty { get; set; }

        [StringLength(128)]
        public string Video { get; set; }

        public DateTime? DateCreated { get; set; }

        public int? UserCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public int? UserModified { get; set; }

        public bool Status { get; set; }

        public virtual Catalog Catalog { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductLink> ProductLinks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductLink> ProductLinks1 { get; set; }
    }
}
