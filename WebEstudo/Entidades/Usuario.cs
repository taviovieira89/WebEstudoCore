using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEstudo.Entidades
{
    [Table("usuario", Schema = "est")]
    public class Usuario
    {
        [Required]
        [Key]
        public int id_usuario { get; set; }
        [Required]
        public string nm_usuario { get; set; } = "";
        [Required]
        public DateTime dt_nascimento { get; set; }
        [Required]
        public string login { get; set; } = "";
        [Required]
        public string senha { get; set; } = "";
    }
}
