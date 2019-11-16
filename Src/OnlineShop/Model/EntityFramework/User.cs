namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long ID { get; set; }

        
        [Required(ErrorMessage = "Tên tài khoản không được để trống")]
        [DisplayName("Tên tài khoản")]
        [StringLength(50, ErrorMessage = "Tên tài khoản không vượt quá 50 ký tự"), MinLength(6, ErrorMessage = "Độ dài tối thiểu 6 ký tự")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Mật khẩu")]
        [StringLength(50, ErrorMessage = "Mật khẩu không vượt quá 50 ký tự"), MinLength(6, ErrorMessage = "Mật khẩu tối thiểu 6 ký tự")]
        public string Password { get; set; }

        [StringLength(20)]
        public string GroupID { get; set; }

        [StringLength(50)]
        [DisplayName("Họ tên")]
        public string Name { get; set; }

        [StringLength(50)]
        [DisplayName("Địa chỉ")]    
        public string Address { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20), MinLength(6, ErrorMessage = "Độ dài tối thiểu 6 ký tự")]
        [DisplayName("Số điện thoại")]
        public string Phone { get; set; }

        public int? ProvinceID { get; set; }

        public int? DistrictID { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public bool Status { get; set; }
    }
}
