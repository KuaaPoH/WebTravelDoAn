using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebTravel.Models;
namespace WebTravel.Areas.Admin.Models
{
    [Table("tb_AdminUser")]
    public class TbAdminUser
    {
        [Key]
        public int UserID { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
       
        public string? Password { get; set; }
       
        public bool? IsActive { get; set; }
     
       
    }
}