namespace WebEstudo.DTO.Entidades
{
    public class UsuarioDTO
    {
        public int id_usuario { get; set; }
        public string nm_usuario { get; set; } = "";
        public DateTime dt_nascimento { get; set; }
        public string login { get; set; } = "";
        public string senha { get; set; } = "";
        public string descricao { get; set; } = "";
    }
}
