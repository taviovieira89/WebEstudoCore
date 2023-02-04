using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEstudo.Entidades
{
    [Table("produtos", Schema = "est")]
    public class Produtos
    {
        [Required]
        [Key]
        public int id_produto { get; set; }
        [Required]
        public string nm_produto { get; set; } = "";
        public decimal? preco { get; set; }
        [Required]
        [ForeignKey("id_usuario_criador")]
        public int id_usuario_criador { get; set; }
        public DateTime? dt_criacao { get; set; }
        public int? id_usuario_edicao { get; set; }
        public DateTime? dt_edicao { get; set; }

    }
}
