namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Advertisement
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string PositionId { get; set; }

        [Required]
        [StringLength(50)]
        public string PageId { get; set; }

        [Required]
        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(250)]
        public string Video { get; set; }

        public int? Width { get; set; }

        public int? Height { get; set; }

        public int? ClickCount { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public bool Status { get; set; }

        public virtual AdvertisementPage AdvertisementPage { get; set; }

        public virtual AdvertisementPosition AdvertisementPosition { get; set; }
    }
}
