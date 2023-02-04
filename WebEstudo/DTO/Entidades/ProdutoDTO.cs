namespace WebEstudo.DTO.Entidades
{
    public class ProdutoDTO
    {
        public int id_produto { get; set; }
        public string nm_produto { get; set; } = "";
        public decimal? preco { get; set; }
        public int id_usuario_criador { get; set; }
        public DateTime? dt_criacao { get; set; }
        public int? id_usuario_edicao { get; set; }
        public DateTime? dt_edicao { get; set; }
    }
}
