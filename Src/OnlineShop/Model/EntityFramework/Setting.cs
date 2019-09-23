namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Setting
    {
        [StringLength(50)]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int? ValueNumber { get; set; }

        public bool? ValueBit { get; set; }

        [StringLength(50)]
        public string ValueString { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ValueDate { get; set; }
    }
}
