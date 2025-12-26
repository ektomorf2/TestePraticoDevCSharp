using TestePraticoDevCSharp.Utils;

namespace TestePraticoDevCSharp.Models
{
    public class produto 
    {
        [PrimaryKey, Serial]
        public int id { get; set; } 
        public string? nome { get; set; }
        public string? descricao { get; set; }
        public decimal preco { get; set; } 
        public decimal estoque { get; set; } 
    }
}
