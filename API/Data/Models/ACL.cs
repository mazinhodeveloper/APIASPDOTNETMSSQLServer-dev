using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIASPDOTNETMSSQLServer.Data.Models
{
    [Table("ztACL")] // Maps to the SQL table name
    public class ACL
    {
        [Key]
        [Column("idACL")]
        public int IdACL { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("tipo")]
        public string Tipo { get; set; } = string.Empty; 

        [Required]
        [MaxLength(100)]
        [Column("descricao")]
        public string Descricao { get; set; } = string.Empty; 
    }
}
