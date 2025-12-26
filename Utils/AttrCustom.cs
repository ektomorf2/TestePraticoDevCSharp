namespace TestePraticoDevCSharp.Utils
{
    /// <summary>indica quando uma coluna chave primária</summary>
    [AttributeUsage(AttributeTargets.All)]
    public class PrimaryKey : Attribute { }

    /// <summary>indica quando uma coluna é de numeração automática</summary>
    [AttributeUsage(AttributeTargets.All)]
    public class Serial : Attribute { }

    /// <summary>se uma propriedade estiver registrada com este atributo, será desconsiderado 
    /// em qualquer que seja a operação com o banco de dados. Deve ser utilizado quando o objeto precisar de ler ou 
    /// armazenar temporariamente um valor que não existe no banco</summary>
    [AttributeUsage(AttributeTargets.All)]
    public class SqlIgnore : Attribute { }
}