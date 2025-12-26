using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;
using System.Reflection;
using TestePraticoDevCSharp.Utils;

namespace TestePraticoDevCSharp.Repository
{
    public class Db
    {
        static readonly string? conString;

        static Db()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            conString = config.GetConnectionString("DefaultConnection");
        }

        #region funcionalidades úteis
        /// <summary>coloca '' para montar o parâmetro quando for varchar, facilitando a montagem da query</summary>
        public static string VarChar(string? valor = "", bool semAcento = false)
        {
            try
            {
                if (Util.Nada(valor)) return "NULL";

                valor = !semAcento ? valor : Util.RemoverAcentos(valor);

                valor = valor.Replace("'", "''");

                return $"'{valor}'";
            }
            catch
            {
                return "NULL";
            }
        }

        /// <summary>retorna a string formatada para o uso do Like, verificando o conteúdo tanto no
        /// início quanto no fim</summary>
        public static string Like(string coluna, string? valor = "")
        {
            try
            {
                if (Util.Nada(valor)) return "NULL";

                valor = valor.Replace("'", "''");

                return $" {coluna} ILike '%{valor}%'";
            }
            catch
            {
                return "NULL";
            }
        }

        /// <summary>retorna a data no formato inglês americano, sem separadores, para utilizar em querys do Postgre. Caso tenha qualquer falha, retorna NULL</summary>
        public static string DataSql(object? data)
        {
            try
            {
                DateTime d = Convert.ToDateTime(data);

                return $"'{Convert.ToString(d.Year)}{Util.NumeroMes(d)}{Util.DiaDoMes(d)}'";
            }
            catch
            {
                return "NULL";
            }
        }

        /// <summary>adiciona a query o trecho between, entre duas datas, visando somente dia mes e ano, sem o horário</summary>
        public static string BetweenDate(string sql, string colunaData, object data1, object data2)
        {
            string between = string.Concat(
                $"Date({colunaData}) ",
                $"Between {DataSql(data1)} And {DataSql(data2)}"
            );

            sql = sql.ToUpper().IndexOf("WHERE ") < 0 ?
                $"{sql}\nWhere " :
                $"{sql}\nAnd ";

            return $"{sql}{between}\n";
        }
        #endregion

        #region inicialização e finalização de conexão

        /// <summary>inicia e retorna uma conexão aberta</summary>
        static async Task<NpgsqlConnection> Conectar()
        {
            try
            {
                NpgsqlConnection con = new(conString);

                await con.OpenAsync();

                return con;
            }

            catch (Exception e)
            {
                throw new Exception($"Erro ao conectar no banco de dados: {e.Message}");
            }

        }

        /// <summary>retorna 2 objetos, sendo uma conexão aberta e uma transação iniciada</summary>
        public static async Task<(NpgsqlConnection con, NpgsqlTransaction tran)> ConectarComTransacao() 
        {
            NpgsqlConnection con = await Conectar();

            NpgsqlTransaction tran = await con.BeginTransactionAsync(); 
            
            return (con, tran); 
        }

        /// <summary>retorna o objeto de comando SQL, com os parâmetros preenchidos e a conexão associada</summary>
        static NpgsqlCommand ComandoSqlParametrizado<T>(T obj, NpgsqlConnection con, string sql, NpgsqlTransaction? tran = null,bool parametrizaPk = false)
        {
            NpgsqlCommand cmd = tran == null ? new(sql, con) : new(sql,con,tran);

            PropertyInfo[]? prop = obj?.GetType().GetProperties();

            foreach (PropertyInfo p in prop)
            {
                if(p.CustomAttributes.Where(x => x.AttributeType.Name == "SqlIgnore").Any()) continue;

                bool pkSerial = p.CustomAttributes
                    .Where(x => x.AttributeType.Name == "Serial" || x.AttributeType.Name == "PrimaryKey")
                    .Any();

                bool parametrizar = !pkSerial || (pkSerial && parametrizaPk);

                if (parametrizar)
                {
                    cmd.Parameters.AddWithValue($"@{p.Name}", p.GetValue(obj) ?? DBNull.Value);
                }
            }

            return cmd;
        }

        /// <summary>finaliza a conexão e o objeto responsável por envio dos comandos</summary>
        public static async Task Desconectar(NpgsqlConnection con, NpgsqlCommand? cmd = null, NpgsqlTransaction? tran = null)
        {
            if(cmd != null)await cmd.DisposeAsync();

            if (tran != null) await tran.DisposeAsync();

            await con.DisposeAsync();
        }

        #endregion

        #region Insert

        /// <summary>monta e retorna uma query de insert para o objeto informado (parâmetro objeto genérico T)</summary>
        public static string SqlInsert<T>(T obj)
        {
            string sql = $"Insert Into {obj?.GetType().Name}\n(";

            PropertyInfo[]? prop = obj?.GetType().GetProperties();

            foreach (PropertyInfo p in prop)
            {
                if (p.CustomAttributes.Where(x => x.AttributeType.Name == "SqlIgnore").Any()) continue;

                bool serial = p.CustomAttributes.Where(a => a.AttributeType.Name.Contains("Serial")).Any();

                if (!serial) sql = $"{sql}{p.Name},";
            }

            sql = $"{sql})";

            sql = sql.Replace(",\n)", ")");

            sql = sql.Replace(",)", ")");

            sql = $"{sql}\nValues\n(";

            foreach (PropertyInfo p in prop)
            {
                if (p.CustomAttributes.Where(x => x.AttributeType.Name == "SqlIgnore").Any()) continue;

                bool serial = p.CustomAttributes.Where(a => a.AttributeType.Name.Contains("Serial")).Any();

                if (!serial)
                {
                    sql = $"{sql}@{p.Name},";
                }
            }

            sql = $"{sql})";
            sql = sql.Replace(",\n)", ")");
            sql = sql.Replace(",)", ")");
            sql = sql.Replace(",,", ",");
            sql = sql.Replace(",)", ")");

            return sql;
        }

        /// <summary>executa o insert, na tabela correspondente ao parâmetro obj, 
        /// e retorna o Id gerado</summary>
        public static async Task<int> Insert<T>(T obj, bool retornaId = true)
        {
            string sql = retornaId ? $"{SqlInsert(obj)}\nReturning id" : $"{SqlInsert(obj)}";

            NpgsqlConnection con = new();

            NpgsqlCommand cmd = new();

            try
            {
                con = await Conectar();

                cmd = ComandoSqlParametrizado(obj, con, sql);

                int id = 0;

                if (retornaId) id = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                else await cmd.ExecuteNonQueryAsync();

                return id;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            finally
            {
                await Desconectar(con, cmd);
            }
        }

        /// <summary>executa o insert, na tabela correspondente ao parâmetro obj, 
        /// e retorna o Id gerado, utilizando transaction</summary>
        public static async Task<int> InsertTran<T>(NpgsqlConnection con, NpgsqlTransaction tran, T obj, bool retornaId = true)
        {
            string sql = retornaId ? $"{SqlInsert(obj)}\nReturning id" : $"{SqlInsert(obj)}";

            NpgsqlCommand cmd = new();

            try
            {
                cmd = ComandoSqlParametrizado(obj, con, sql,tran);

                int id = 0;
                
                if(retornaId) id = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                else await cmd.ExecuteNonQueryAsync();

                return id;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            finally
            {
                await cmd.DisposeAsync();
            }
        }

        #endregion

        #region Update
        /// <summary>monta e retorna um string com o comando Update</summary>
        public static string SqlUpdate<T>(T obj, string? parametros = null)
        {
            string sql = $"Update {obj?.GetType().Name} Set\n";

            PropertyInfo[]? prop = obj?.GetType().GetProperties();

            string pks = "";

            foreach (PropertyInfo p in prop)
            {
                if (p.CustomAttributes.Where(x => x.AttributeType.Name == "SqlIgnore").Any()) continue;

                if (p.CustomAttributes.Where(a => a.AttributeType.Name == "PrimaryKey").Any())
                {
                    pks = !Util.Nada(pks) 
                        ? $"{pks} And {p.Name} = @{p.Name}" 
                        : $"{p.Name} = @{p.Name}";
                }

                bool pkSerial = p.CustomAttributes
                    .Where(a => a.AttributeType.Name.Contains("Serial") || a.AttributeType.Name.Contains("PrimaryKey"))
                    .Any();

                if (!pkSerial)
                {
                    sql = $"{sql}{p.Name} = @{p.Name},\n";
                }
            }

            if (!Util.Nada(pks) || !Util.Nada(parametros))
            {
                sql = $"{sql} Where ";
                sql = sql.Replace(",\n Where", "\nWhere").
                    Replace(",\nWhere", "\nWhere").
                    Replace(", Where", "\nWhere").
                    Replace(",Where", "\nWhere");
            }

            if (sql.EndsWith(",\n")) sql = sql[..^2];

            sql = Util.Nada(parametros) ? $"{sql}{pks}" : $"{sql}{parametros}";

            return $"{sql};";
        }

        /// <summary>executa o update na tabela correspondente ao parâmetro obj</summary>
        public static async Task Update<T>(T obj, string? parametros = null)
        {
            NpgsqlConnection con = new();

            NpgsqlCommand cmd = new();

            try
            {
                string sql = $"{SqlUpdate(obj, parametros)}";

                con = await Conectar();

                cmd = ComandoSqlParametrizado(obj, con, sql,null,true);

                await cmd.ExecuteNonQueryAsync();
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            finally
            {
                await Desconectar(con, cmd);
            }
        }

        /// <summary>executa o update na tabela correspondente ao parâmetro obj</summary>
        public static async Task UpdateTran<T>(NpgsqlConnection con, NpgsqlTransaction tran, T obj, string? parametros = null)
        {
            NpgsqlCommand cmd = new();

            try
            {
                string sql = $"{SqlUpdate(obj, parametros)}";

                cmd = ComandoSqlParametrizado(obj, con, sql,tran,true);

                await cmd.ExecuteNonQueryAsync();
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            finally
            {
                await cmd.DisposeAsync();
            }
        }

        /// <summary>monta e retorna um string com o comando Update, de forma customizada, onde no parâmetro camposUpdate, informamos, separados por vírgulas, o nome das colunas que serão atualizadas</summary>
        public static string SqlUpdateCustom<T>(T obj, string camposUpdate, string? parametros = null)
        {
            string sql = $"Update {obj?.GetType().Name} Set\n";

            PropertyInfo[] prop = obj.GetType().GetProperties();

            List<string> colunas = Util.ListStringSplit(camposUpdate, ",");

            string pks = "";

            string valorChave = "";

            if (Util.Nada(parametros))
            {
                foreach (PropertyInfo p in prop)
                {
                    if (p.CustomAttributes.Where(a => a.AttributeType.Name == "PrimaryKey").Any())
                    {
                        valorChave = $"@{p.Name}";

                        pks = !Util.Nada(pks) 
                            ? $"{pks} And {p.Name} = {valorChave}"
                            : $"{p.Name} = {valorChave}";
                    }
                }
            }

            foreach (string c in colunas)
            {
                sql = $"{sql}{c} = @{c},\n";
            }

            if (!Util.Nada(pks) || !Util.Nada(parametros))
            {
                sql = $"{sql} Where ";
                sql = sql.Replace(",\n Where", "\nWhere").
                    Replace(",\nWhere", "\nWhere").
                    Replace(", Where", "\nWhere").
                    Replace(",Where", "\nWhere");
            }

            if (sql.EndsWith(",\n")) sql = sql[..^2];

            return Util.Nada(parametros) ? $"{sql}{pks};" : $"{sql}{parametros};";
        }

        /// <summary>executa o update na tabela correspondente ao parâmetro obj, de forma customizada, 
        /// onde sofrerão alteração somente os campos correspondentes as colunas informadas em camposUpdate,
        /// separados por vírgula</summary>
        public static async Task UpdateCustom<T>(T obj, string camposUpdate, string? parametros = null)
        {
            NpgsqlConnection con = new();

            NpgsqlCommand cmd = new();

            try
            {
                string sql = $"{SqlUpdateCustom(obj, camposUpdate, parametros)}";

                con = await Conectar();

                cmd = ComandoSqlParametrizado(obj, con, sql,null,true);

                await cmd.ExecuteNonQueryAsync();
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            finally
            {
                await Desconectar(con, cmd);
            }
        }

        public static async Task UpdateCustomTran<T>(NpgsqlConnection con, NpgsqlTransaction tran, T obj, string camposUpdate, string? parametros = null)
        {
            NpgsqlCommand cmd = new();

            try
            {
                string sql = $"{SqlUpdateCustom(obj,camposUpdate, parametros)}";

                cmd = ComandoSqlParametrizado(obj, con, sql, tran,true);

                await cmd.ExecuteNonQueryAsync();
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            finally
            {
                await cmd.DisposeAsync();
            }
        }

        #endregion

        #region Delete

        public static string SqlDelete<T>(T obj, string? parametros = null)
        {
            string sql = $"Delete From {obj?.GetType().Name}";

            PropertyInfo[]? prop = obj?.GetType().GetProperties();

            string pks = "";

            foreach (PropertyInfo p in prop)
            {
                if (p.CustomAttributes.Where(a => a.AttributeType.Name == "PrimaryKey").Any())
                {
                    pks = !Util.Nada(pks)
                        ? $"{pks} And {p.Name} = @{p.Name}"
                        : $"{p.Name} = @{p.Name}";
                }
            }

            if (!Util.Nada(pks) || !Util.Nada(parametros))
            {
                sql = $"{sql} Where ";
            }

            sql = Util.Nada(parametros) ? $"{sql}{pks}" : $"{sql}{parametros}";

            return sql;
        }

        /// <summary>executa o delete na tabela correspondente ao parâmetro obj</summary>
        public static async Task Delete<T>(T obj, string? parametros = null)
        {
            string sql = SqlDelete(obj, parametros);

            NpgsqlConnection con = new();
            NpgsqlCommand cmd = new();

            try
            {
                con = await Conectar();

                cmd = ComandoSqlParametrizado(obj, con, sql,null,true);

                await cmd.ExecuteNonQueryAsync();
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            finally
            {
                await Desconectar(con, cmd);
            }
        }

        /// <summary>executa o delete na tabela correspondente ao parâmetro obj</summary>
        public static async Task DeleteTran<T>(NpgsqlConnection con, NpgsqlTransaction tran,T obj, string? parametros = null)
        {
            string sql = SqlDelete(obj, parametros);

            NpgsqlCommand cmd = new();

            try
            {
                cmd = ComandoSqlParametrizado(obj, con, sql, tran, true);

                await cmd.ExecuteNonQueryAsync();
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            finally
            {
                await cmd.DisposeAsync();
            }
        }
        #endregion

        #region Select

        /// <summary>monta o select de acordo com os atributos do objeto, ou utilizando o conteúdo
        /// que estiver no parâmetro query</summary>

        static string SqlSelect<T>(T obj, string? query = "", string parametros = "")
        {
            string sql = Util.Nada(query) ? "Select\n" : $"Select\n{query}\n";

            if (Util.Nada(query))
            {
                PropertyInfo[]? prop = obj?.GetType().GetProperties();

                foreach (PropertyInfo p in prop)
                {
                    if (p.CustomAttributes.Where(x => x.AttributeType.Name == "SqlIgnore").Any()) continue;

                    sql = $"{sql}{p.Name}, ";
                }
            }

            if (!sql.ToLower().Contains($"from {obj?.GetType().Name}"))
            {
                sql = $"{sql}From {obj?.GetType().Name}";

                sql = sql.Replace(",\nFrom", "\nFrom").Replace(",From", "\nFrom").Replace(", From", "\nFrom");
            }

            sql = !Util.Nada(parametros) && parametros.ToUpper() != "NULL" ? $"{sql}\nWhere {parametros}" : sql;
            
            return sql;
        }

        /// <summary>executa Select e retorna o resultado em um DataTable</summary>
        static async Task<DataTable> RetornoSelect(string sql)
        {
            NpgsqlConnection con = new();

            try
            {
                con = await Conectar();

                NpgsqlDataAdapter a = new(sql, con);

                DataTable d = new();

                d.BeginLoadData();

                await Task.FromResult(a.Fill(d));

                d.EndLoadData();

                a.Dispose();

                return d;
            }

            catch (Exception e)
            {
                throw new Exception($"RetornoSelect: {e.Message}");
            }

            finally
            {
                await Desconectar(con, new NpgsqlCommand());
            }
        }

        /// <summary>verifica se um registro existe de acordo com o valor de uma 
        /// determinada coluna de uma tabela</summary>
        public static async Task<bool> Existe<T>(T obj, string? coluna, object valor)
        {
            try
            {
                string sql = $"Select Exists(Select 1 From {obj?.GetType().Name} Where {coluna} = {valor})";

                DataTable d = await RetornoSelect(sql);

                return Util.DtOk(d) && Convert.ToBoolean(d.Rows[0][0]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>retorna o resultado do select como um objeto tipado</summary>
        public static async Task<T> Select<T>(T obj, string? query = "", string parametros = "")
        {
            try
            {
                string sql = SqlSelect(obj, query, parametros);

                DataTable d = await RetornoSelect(sql);

                return Util.ToObj<T>(d);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>retorna o resultado do select como uma lista de objetos tipados</summary>
        public static async Task<List<T>> SelectList<T>(T obj, string? query = "", string parametros = "")
        {
            try
            {
                string sql = SqlSelect(obj, query, parametros);
                
                DataTable d = await RetornoSelect(sql);

                return Util.ToList<T>(d);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
