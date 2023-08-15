using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OsDsII.api.Controllers;

namespace OsDsII.api.Models
{   
    [Index(nameof(Email), IsUnique = true)]
    [PrimaryKey(nameof(Id))]
    [Table("customer")]
    
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]

        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        [Column("name")]
        [NotNull]
        public string Name  { get; set; }
        public string Email { get; set; }

        [Column("phone")]
        [StringLength(20)]
        [Required]
        public string Phone { get; set; }
    }
}