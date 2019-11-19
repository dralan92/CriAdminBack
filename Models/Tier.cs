using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CriAdmin.Models
{
    public class Tier
    {
        [Key]
        public int TierId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string TierName { get; set; }
    }
}
