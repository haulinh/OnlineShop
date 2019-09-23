namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductLink
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? ProductId { get; set; }

        public int? LinkedProductId { get; set; }

        public virtual Product Product { get; set; }

        public virtual Product Product1 { get; set; }
    }
}
