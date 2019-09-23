namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Post()
        {
            Comments = new HashSet<Comment>();
            Categories = new HashSet<Category>();
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        [StringLength(250)]
        public string Thumbnail { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(50)]
        public string ImageCaption { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? PublishedDate { get; set; }

        [StringLength(250)]
        public string Source { get; set; }

        public int Status { get; set; }

        [StringLength(250)]
        public string SeoAlias { get; set; }

        [StringLength(250)]
        public string SeoTitle { get; set; }

        [StringLength(158)]
        public string SeoMetaKeywords { get; set; }

        [StringLength(158)]
        public string SeoMetaDescription { get; set; }

        public DateTime? HotDate { get; set; }

        public DateTime? NewDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Categories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
