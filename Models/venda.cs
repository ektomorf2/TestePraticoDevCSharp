using TestePraticoDevCSharp.Utils;

namespace TestePraticoDevCSharp.Models
{
    public class venda
    {
        [PrimaryKey, Serial]
        public int id { get; set; }
        public int idcliente { get; set; }

        public DateTime datahora { get; set; } = DateTime.Now;
        public decimal total { get; set; }

        [SqlIgnore]
        public List<vendaitem> itens { get; set; } = [];

        /// <summary>nome do cliente da venda (não mapeado no banco de dados)
        /// </summary>
        [SqlIgnore]
        public string? cliente { get; set; }

        [SqlIgnore]
        public DateTime dataIni { get; set; }

        [SqlIgnore]
        public DateTime dataFim { get; set; }
    }
}
