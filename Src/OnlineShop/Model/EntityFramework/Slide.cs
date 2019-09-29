namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Slide
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public int? SortOrder { get; set; }

        [StringLength(250)]
        public string Url { get; set; }

        [StringLength(10)]
        public string Target { get; set; }

        public int? Width { get; set; }

        public int? Height { get; set; }

        public bool? Status { get; set; }
    }
}
