namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Page
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string SeoAlias { get; set; }

        public string Content { get; set; }

        public bool? Status { get; set; }

        [StringLength(128)]
        public string SiteTitle { get; set; }

        [StringLength(158)]
        public string MetaKeywords { get; set; }

        [StringLength(158)]
        public string MetaDescription { get; set; }
    }
}
