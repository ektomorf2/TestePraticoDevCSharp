# Projeto .NET 9 com PostgreSQL

## 📐 Arquitetura Adotada
- Plataforma: **.NET 9**
- Linguagem: **C#**
- Interface gráfica: **Windows Forms**
- Padrões utilizados:
  - **Injeção de Dependência (DI)** para desacoplamento e melhor manutenção.
  - **Interfaces** para abstração da camada de acesso a dados.
- Banco de dados: **PostgreSQL 18.1**

---

## ⚙️ Decisões Técnicas
- Implementação da classe **`Db`**, que funciona de forma semelhante a um **ORM**, simplificando:
  - Montagem de comandos SQL.
  - Execução de consultas e operações no banco.
- Utilização da biblioteca **Npgsql** para conexão com o PostgreSQL.
- As classes de entidade (**Models**) foram nomeadas em **lowercase**, seguindo a padronização de nomes do PostgreSQL, o que facilita o mapeamento direto entre objetos e tabelas.

---

## 🗄️ Configuração do Banco
1. Instale o **PostgreSQL 18.1**.
2. Crie o banco de dados para o projeto:
   ```sql
   CREATE DATABASE testepraticodevcsharp;

3.Configure as credenciais de acesso (usuário e senha) no arquivo de configuração do projeto (appsettings.json).

4. Execute os scripts SQL abaixo para criar as tabelas necessárias.

-- Versão do PostgreSQL utilizada: 18.1

CREATE TABLE cliente (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(200) NOT NULL,
    telefone VARCHAR(30) NOT NULL,
    CONSTRAINT uq_cliente_email UNIQUE (email)
);

CREATE INDEX idx_cliente_nome ON cliente (nome);

CREATE TABLE produto (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    descricao VARCHAR(200) NOT NULL,
    preco NUMERIC(10,2) NOT NULL,
    estoque NUMERIC(10,2) NOT NULL,
    CONSTRAINT chk_produto_preco CHECK (preco > 0),
    CONSTRAINT chk_produto_estoque CHECK (estoque >= 0)
);

CREATE UNIQUE INDEX uq_produto_nome ON produto (nome);

CREATE TABLE venda (
    id SERIAL PRIMARY KEY,
    idcliente INTEGER NOT NULL REFERENCES cliente(id),
    datahora TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    total NUMERIC(10,2) NOT NULL
);

CREATE INDEX idx_venda_cliente ON venda (idcliente);
CREATE INDEX idx_venda_data ON venda (datahora);

CREATE TABLE vendaitem (
    id SERIAL PRIMARY KEY,
    idvenda INTEGER NOT NULL REFERENCES venda(id) ON DELETE CASCADE,
    idproduto INTEGER NOT NULL REFERENCES produto(id),
    quantidade NUMERIC(10,2),
    precounitario NUMERIC(10,2) NOT NULL,
    total NUMERIC(10,2) NOT NULL,
    CONSTRAINT chk_item_quantidade CHECK (quantidade > 0)
);

CREATE INDEX idx_vendaitem_venda ON vendaitem (idvenda);
CREATE INDEX idx_vendaitem_produto ON vendaitem (idproduto);
