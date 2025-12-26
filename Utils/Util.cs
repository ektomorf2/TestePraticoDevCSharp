using Newtonsoft.Json;
using System.Data;
using System.Globalization;
using System.Text;

namespace TestePraticoDevCSharp.Utils
{
    public class Util
    {
        /// <summary>true: significa que o datatable em questão está carregado com no mínimo um registro
        /// false: datatable em questão está nulo, ou não contém nenhum registro</summary>
        public static bool DtOk(DataTable? d)
        {
            bool ok = d != null && d.Rows.Count > 0;
            return ok;
        }

        /// <summary>true: significa que o dataset em questão está carregado com no mínimo uma tabela e um registro. 
        /// false: dataset em questão está nulo, ou não contém nenhuma tabela e nenhum registro</summary>
        public static bool DsOk(DataSet? ds) { return ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0; }

        /// <summary>true: significa que o list em questão está carregado com no mínimo um objeto. 
        /// false: list não contém nenhum objeto, ou está nulo</summary>
        public static bool ListOk<T>(List<T>? lista)
        {
            return lista != null && lista.Count > 0;
        }

        /// <summary>método para resolver problemas de data em formato incorreto e campos que não existirem no objeto que está sendo convertido para Json</summary>
        public static JsonSerializerSettings CfJson()
        {
            JsonSerializerSettings j = new()
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            return j;
        }

        /// <summary>Converte o dataTable em JSON, e retorna deserializado em um objeto tipado</summary>
        public static T? ToObj<T>(DataTable? d)
        {
            try
            {
                if (!DtOk(d)) return default;

                string j = JsonConvert.SerializeObject(d, CfJson());

                List<T>? lista = JsonConvert.DeserializeObject<List<T>>(j);

                return (lista != null && lista.Count > 0) ? lista[0] : default;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>Converte o dataTable em JSON, e retorna deserializado em uma lista tipada</summary>
        public static List<T> ToList<T>(DataTable? d)
        {
            try
            {
                if (!DtOk(d)) return new List<T>();
                string j = JsonConvert.SerializeObject(d, CfJson());
                return JsonConvert.DeserializeObject<List<T>>(j) ?? [];
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static string RemoverAcentos(string? texto)
        {
            if (Nada(texto)) return texto;

            string normalized = texto.Normalize(NormalizationForm.FormD);

            var sb = new StringBuilder(); 
            
            foreach (var c in normalized) 
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                
                if (unicodeCategory != UnicodeCategory.NonSpacingMark) 
                { 
                    sb.Append(c); 
                } 
            } 
            
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        /// <summary>retorna uma lista de strings à partir de um array gerado de uma string com Split</summary>
        public static List<string> ListStringSplit(string? expressao, string caracterSeparador)
        {
            if (string.IsNullOrEmpty(expressao) || string.IsNullOrEmpty(caracterSeparador)) return [];
            
            List<string> lista = [];

            string[] array = expressao.Split(Convert.ToChar(caracterSeparador));

            foreach (string str in array) { lista.Add(str); }

            return lista;
        }

        /// <summary>retorna true se a string estiver vazia ou nula, ou false se tiver algum valor</summary>
        public static bool Nada(object? expressao = null)
        {
            if (expressao == null || Convert.ToString(expressao) == "''") return true;

            string exp = Convert.ToString(expressao) ?? string.Empty;

            if (Convert.ToString(expressao) == "\n") return false;

            return string.IsNullOrEmpty(exp.Trim());
        }

        public static string FoneSemMascara(string fone)
        {
            try
            {
                if (Nada(fone)) return "";
                return fone.Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", "").Replace(".", "").Trim();
            }
            catch
            {
                return "";
            }
        }

        /// <summary>verifica e retorna a quantidade de caracteres de uma string</summary>
        public static int Len(object? texto)
        {
            string? len = Convert.ToString(texto);

            if (Nada(len)) return 0;

            else return Convert.ToString(texto).Length;
        }

        /// <summary>retorna o número do mês de uma data</summary>
        public static string? NumeroMes(DateTime data)
        {
            string mes = Len(data.Month) == 1 ? $"0{data.Month}" : Convert.ToString(data.Month);

            return mes;
        }

        /// <summary>retorna o dia de uma data</summary>
        public static string? DiaDoMes(DateTime data)
        {
            string dia = Len(data.Day) == 1 ? $"0{data.Day}" : Convert.ToString(data.Day);

            return dia;
        }

        /// <summary>formata as casas decimais de um campo para exibição</summary>
        public static string Decimais(object valor, int numeroDeCasas = 2, bool substVirgulaPorPonto = false)
        {
            string? v = null;// Convert.ToString(valor);//.Replace(".", "").Replace(",","");            
            if (numeroDeCasas == 1) v = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:#,#}", v);
            else if (numeroDeCasas == 2) v = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:###,###,##0.00}", valor);
            else if (numeroDeCasas == 3) v = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:###,###,##0.000}", valor);
            else if (numeroDeCasas == 4) v = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:###,###,##0.0000}", valor);
            if (v == null) v = "0";
            if (v.IndexOf(".") >= 0 && v.IndexOf(",") >= 0) v = v.Replace(".", "");//removendo o separador de milhar
            if (v.IndexOf(",") < 0) v += ",00";
            if (substVirgulaPorPonto) v = v.Replace(",", ".");
            else v = v.Replace(".", "");
            return v;
        }

        public static bool DataValida(object? dataValidar = null)
        {
            if (Nada(dataValidar)) return false;

            string? data = Convert.ToString(dataValidar);

            bool valido = DateTime.TryParse(data, out DateTime date);

            return valido;
        }
    }
}