using TestePraticoDevCSharp.Utils;

namespace TestePraticoDevCSharp.Models
{
    public class cliente 
    {
        [PrimaryKey, Serial]
        public int id { get; set; }
        public string? nome { get; set; } 
        public string? email { get; set; } 
        public string? telefone { get; set; }
    }
}
