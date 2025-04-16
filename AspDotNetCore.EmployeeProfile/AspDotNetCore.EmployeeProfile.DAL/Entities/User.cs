using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspDotNetCore.EmployeeProfile.DAL.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        [Column("UserName", TypeName = "varchar(20)")]
        public string? UserName { get; set; }
        [Required]
        [Column("Password", TypeName = "varchar(20)")]
        public required string Password { get; set; }
        [Required]
        [Column("Roles", TypeName = "varchar(50)")]
        public string? Roles { get; set; }

    }
}
