using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspDotNetCore.EmployeeProfile.DAL.Entities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; } // Primary key
        [Required]
        [Column("EmployeeName",TypeName ="varchar(30)")]
        public required string EmployeeName { get; set; }
        [Required]
        [Column("DOB", TypeName = "date")]
        public DateOnly DOB { get; set; }
        [Required]
        [Column("Gender", TypeName = "Char(1)")]
        public Char? Gender { get; set; }
        [Required]
        [Column("Email", TypeName = "varchar(50)")]
        [EmailAddress]
        public string? Email { get; set; }

        [Column("State", TypeName = "varchar(30)")]
        public string? State { get; set; }
        [Required]
        [Column("DateCreated", TypeName = "datetime")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

    }
}
