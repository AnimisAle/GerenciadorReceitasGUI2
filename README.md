# Gerenciador de Receitas

## 📌 Sobre o Projeto
O **Gerenciador de Receitas** é uma aplicação desenvolvida em **C# com Windows Forms** para ajudar usuários a organizar, cadastrar, editar e exportar receitas culinárias. Ele utiliza **Entity Framework Core** e **PostgreSQL** para armazenamento dos dados.

## 🛠 Tecnologias Utilizadas
- **C# (.NET 6 ou superior)**
- **Windows Forms**
- **Entity Framework Core**
- **PostgreSQL**
- **MaterialSkin** (para melhorar a interface gráfica)

## 🚀 Como Rodar o Projeto

### 📌 Pré-requisitos
Antes de iniciar, você precisará ter os seguintes itens instalados:
- [.NET SDK 6 ou superior](https://dotnet.microsoft.com/en-us/download)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Visual Studio](https://visualstudio.microsoft.com/) (recomendado)

### 🏗 Configuração do Banco de Dados
1. **Criar um banco de dados PostgreSQL**
   - Acesse o PostgreSQL e crie um banco de dados com o nome desejado.
   - Exemplo de comando SQL:
     ```sql
     CREATE DATABASE GerenciadorReceitas;
     ```

2. **Configurar a string de conexão**
   - No arquivo `appsettings.json` ou no código, configure a string de conexão para apontar para o seu banco de dados PostgreSQL:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Port=5432;Database=GerenciadorReceitas;Username=seu_usuario;Password=sua_senha"
     }
     ```

### 📦 Instalação de Dependências
Abra o **Gerenciador de Pacotes NuGet** no Visual Studio ou utilize o terminal para instalar os pacotes necessários:

```bash
# Entity Framework Core para PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore

dotnet add package Microsoft.EntityFrameworkCore.Design

dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

# MaterialSkin para UI
dotnet add package MaterialSkin.2
```

### 🏗 Criando o Banco de Dados
Após configurar a string de conexão e instalar os pacotes, execute os seguintes comandos para criar o banco de dados e aplicar as migrações:

```bash
# Criar uma migração inicial
 dotnet ef migrations add InitialCreate

# Aplicar as migrações e criar o banco de dados
 dotnet ef database update
```

### ▶️ Executando o Projeto
Após configurar o ambiente e o banco de dados, basta rodar o projeto no Visual Studio ou pelo terminal:

```bash
dotnet run
```

O sistema abrirá a interface gráfica e estará pronto para uso! 🎉

## 📝 Funcionalidades
✅ Cadastrar, editar e excluir receitas  
✅ Adicionar imagens às receitas  
✅ Organizar receitas por categoria  
✅ Exportar receitas para arquivo `.txt`  

## 📂 Estrutura do Código
- `Receita.cs`: Representa uma receita.
- `Ingrediente.cs`: Representa os ingredientes de uma receita.
- `Categoria.cs`: Representa categorias de receitas.
- `ReceitasContext.cs`: Classe de contexto do Entity Framework.
- `GerenciadorReceitas.cs`: Contém a lógica de manipulação de receitas.
- `Forms/AdicionarReceitaForm.cs`: Interface para adicionar novas receitas.

## 📜 Licença
Este projeto é de código aberto e pode ser utilizado livremente. 😊

