# Rota de Viagem

### Escolha a rota de viagem mais barata independente da quantidade de conexões


### 1. Tecnologias

As seguintes tecnologias foram usadas na construção do projeto:

- [C#](https://docs.microsoft.com/pt-br/dotnet/csharp/)
- [.NET8](https://dotnet.microsoft.com/pt-br/)
- [Entity Framework](https://docs.microsoft.com/pt-br/ef/)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- [Connection Strings](https://www.connectionstrings.com/)


### 2. Funcionalidades

* O projeto 'Rota de Viagem' implementa um serviço otimizado de busca de rotas para uma viagem. Com o foco em identificar o trajeto mais econômico entre dois pontos, independentemente do número de conexões.

* Utilizando um design robusto e uma API REST, permite gerenciar e consultar rotas de forma eficiente, garantindo performance e escalabilidade.

* O projeto oferece um conjunto de endpoints para a gestão das rotas disponíveis. Sendo possível adicionar, atualizar e excluir as rotas.
  * Adicionar:
    * [POST] api/rota/
      
  * Atualizar:
    * [PUT] api/rota/
      
  * Excluir:
    * [DELETE] api/rota/
      

* Existem também três endpoints de consulta de dados, uma para listar todas as rotas, um para buscar uma determinada rota por ID e um para buscar o trajeto mais econômico entre dois pontos.
  * Buscar todos:
    * [GET] api/rota/
      
  * Buscar por ID:
    * [GET] api/rota/{id}
      
  * Buscar melhor rota:
    * [GET] api/rota/melhor-rota/{origem}/{destino}
      

* Os dados são persistidos no SQL Server, mas com a arquitetura de projeto escolhida, e com o auxilio do Entity Framework, é possível modificar o tipo de persistência facilmente.


### 3. Pré-requisitos

  - .NET 8 SDK
  - Ambiente de desenvolvimento (Visual Studio, VS Code)
  - Banco de dados SQL Server


### 4. Como Configurar e Executar o Projeto

* Clonar o Repositório
```bash
    git clone https://github.com/marcosdv/RotaViagem.git
```

* Abrir Pasta do Projeto
```bash
    cd RotaViagem
```

* Restaurar Pacotes
```bash
    dotnet restore
```

* Configurar a String de Conexão do Banco de Dados (ConnectionString)
    * Abra o arquivo 'appsettings.json' dentor do projeto 'RotaViagem.Api' e atualize a string de conexão para apontar para o seu banco de dados local.

    * Exemplo:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server={NOME-SERVER};Database={NOME-BANCO};Trusted_Connection=True;Integrated Security=true;Encrypt=False;"
      }
    }
    ```
    * (Substituir {NOME-SERVER} pelo nome do servidor do SQL Server)
    * (Substituir {NOME-BANCO} pelo nome desejado para o Banco de Dados)
    * (Caso o bando de dados utilize usuário e senha, adicionar as informações de Login no lugar do paramêtro: Integrated Security)


* Rodar as Migrações (EF Core)
```bash
    dotnet ef database update
```

* Iniciar o Projeto
```bash
    dotnet run
```

* Carga de Dados Inicial (Opcional)
  * Descomentar o método 'CargaInicialAsync', localidado dentro de:
    * RotaViagem.Api/Controllers/RotaController.cs
  * Executar o projeto e executar o endpoint: api/rota/cargaInicial

 
![Badge](https://img.shields.io/badge/Marcos%20Dias%20Vendramini-ASP.NET%20C%23-red)
