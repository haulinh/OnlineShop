namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Categories1 = new HashSet<Category>();
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public int? ParentId { get; set; }

        public int? SortOrder { get; set; }

        public bool? ShowInMenu { get; set; }

        public bool? ShowInHome { get; set; }

        [StringLength(250)]
        public string Thumbnail { get; set; }

        [StringLength(128)]
        public string SeoAlias { get; set; }

        [StringLength(128)]
        public string SiteTitle { get; set; }

        [StringLength(158)]
        public string MetaKeywords { get; set; }

        [StringLength(158)]
        public string MetaDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Categories1 { get; set; }

        public virtual Category Category1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
