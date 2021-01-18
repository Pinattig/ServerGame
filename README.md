# ServerGame

## Descrição
API utilizada para salvar resultados de jogos e depois solicita-los em forma de Leaderboards.

## Características do projeto
- Este projeto foi desenvolvido utilizando Asp.Net Core na versão 3.1 no padrão MVC e o framework de mapeamento e persistencia de objetos relacionais EntityFramework Core na versão 5.0.
- Este framework foi utilizado pois na maioria dos casos ele abstrai e facilita a utilização das tecnologias ligadas ao ADO.NET para o desenvolvimento de aplicativos orientados a dados.

## Configuração

### O projeto conta com um arquivo de configuração appsettings.json onde são informados alguns parametros vitais para o funcionamento do sistema, são eles:
- Tipo do banco de dados : 
Na chave "DataBaseType" deverá ser informado qual o tipo do banco de dados que será utilizado, o projeto foi todo desenvolvido utilizando Sql Server e também tem suporte para banco de dados na memória que está definido como padrão (aconselhada a utilização apenas para testes rasos). Contúdo, este projeto está preparado para receber outras compatibilidades de outros bancos como PostgreSQL, Sqlite, MySql etc. Todos os bancos compativeis com essa aplicação podem ser consultados em sua integra neste link https://docs.microsoft.com/pt-br/ef/core/providers/?tabs=dotnet-core-cli https://docs.microsoft.com/pt-br/ef/core/providers/?tabs=dotnet-core-cli.

- ConnectionStrings/ApplicationDBContext:
Nesta chave a string de conexeção para o banco de dados escolhido precisa ser informada, se o tipo de banco escolhido for o em memória esta chave não precisa ser preenchida.

- TimeToPersistGamesResult:
Aqui será informado o intervalo de tempo que o timer do sistema executará a persistencia de dados no banco escolhido.

- TimeToAttLeaderboardsGames:
Aqui será informado o intervalo de tempo que os Leaderboards armazenados na memoria do sistema para deixar o acesso dos usuários mais rápido à esse recurso serão atualizados e pareados com os dados armazenados no banco de dados escolhido.

### Exemplo do appsettings.json preenchido:
``` 
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "DataBaseType": "sqlserver",
  "ConnectionStrings": {
    "ApplicationDBContext": "Server=localhost;Database=game_server_database;User Id=exemple; Password=exemple;"
  },
  "TimeToPersistGamesResult": "00:01:00",
  "TimeToAttLeaderboardsGames": "00:01:00"
}

```

## Execução

### Para executar o projeto os seguintes passos deverão ser seguidos:
- Clone o projeto no link https://github.com/Pinattig/ServerGame/
- (Execução com o Visual Studio) Abra o Visual Studio, clique em abrir solução e navegue até a pasta que o projeto foi clonado. Selecione o arquivo ServerGame.sln e clique em abrir.
- (Execução pelo console) Abra o console e navegue até a pasta que o projeto foi clonado. Em seguida execute o comando:
 
 ``` dotnet run ```


## IMPORTANTE: Quando qualquer outro banco que não seja o padrão for utilizado, executar a migração antes de rodar o projeto.
