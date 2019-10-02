namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserRole
    {
        public int RoleId { get; set; }

        public int UserId { get; set; }

        public int UserRoleID { get; set; }

        public virtual Role Role { get; set; }

        public virtual User User { get; set; }
    }
}
