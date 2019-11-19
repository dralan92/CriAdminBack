using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CriAdmin.Models
{
    public class CriQn
    {
        [Key]
        public int QnId { get; set; }
        [Required]
        [Column(TypeName="nvarchar(100)")]
        public string Qn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Opt1 { get; set; }
        public int Weight1 { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Opt2 { get; set; }
        public int Weight2 { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Opt3 { get; set; }
        public int? Weight3 { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Opt4 { get; set; }
        public int? Weight4 { get; set; }
        public Country Country { get; set; }
        public int CountryFk { get; set; }
        public Tier Tier { get; set; }
        public int TierFk { get; set; }

    }
}
