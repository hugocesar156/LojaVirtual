namespace LojaVirtual.Models.Venda
{
    public class Pacote
    {
        public uint Largura { get; set; }
        public uint Altura { get; set; }
        public uint Comprimento { get; set; }
        public float Peso { get; set; }
    }

    public class Frete
    {
        public float ValorSedex { get; set; }
        public float ValorPac { get; set; }
        public string PrazoSedex { get; set; }
        public string PrazoPac { get; set; }
    }
}
