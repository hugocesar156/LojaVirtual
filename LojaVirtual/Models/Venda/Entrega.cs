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
        public float Valor { get; set; }
        public string Prazo { get; set; }
    }
}
