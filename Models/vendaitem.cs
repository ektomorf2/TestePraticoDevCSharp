using TestePraticoDevCSharp.Utils;

namespace TestePraticoDevCSharp.Models
{
    public class vendaitem 
    {
        [PrimaryKey, Serial]
        public int id { get; set; } 
        public int idvenda { get; set; } 
        public int idproduto { get; set; } 
        public decimal quantidade { get; set; } 
        public decimal precounitario { get; set; } 
        public decimal total { get; set; }

        /// <summary>nome do produto (apenas para exibição)</summary>
        [SqlIgnore]
        public string? produto { get; set; }
    }
}
