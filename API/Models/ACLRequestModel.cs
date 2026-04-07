using System.ComponentModel.DataAnnotations;

namespace APIASPDOTNETMSSQLServer.Models
{
    public class ACLRequestModel
    {
        [Required(ErrorMessage = "O campo 'Tipo' é obrigatório.")]
        [StringLength(20, ErrorMessage = "O 'Tipo' deve ter no máximo 20 caracteres.")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "O campo 'Descrição' é obrigatório.")]
        [StringLength(100, ErrorMessage = "A 'Descrição' deve ter no máximo 100 caracteres.")]
        public string Descricao { get; set; }
    }
}
