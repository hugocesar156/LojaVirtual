using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Models.Pagamento
{
    public class Parcelamento
    {
        public byte Parcelas { get; set; }
        public float ValorParcela { get; set; }
        public float Total { get; set; }
        public bool Juros { get; set; }
    }
}
