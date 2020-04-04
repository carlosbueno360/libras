# TecLibras App


## Configuração

Primeramente precisamos alterar o valor DefaultConnection no arquivo appsettings.json dos dois projetos.

**DefaultConnection**  valor da connection string para o banco de dados Sql Server com a Base de Dados **TecLibras**. 

Abaixo exemplo de como é a estrutura do appsetting.json

appsettings.json
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=localhost;Initial Catalog=TecLibras;User Id=COLOCARUSER;Password=COLOCARPASS;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "AppSettings": {
    "Secret": "CHANGETHISSECRETKEY",
    "Expiration": 2,
    "Issuer": "MyEnvironment",
    "ValidAt": "https://localhost"
  }
}


```

Após alterar a appsetings.json temos que correr as migrations dos banco de dados, as migrations são responsaveis pela criação da estrutura de dados que iremos precisar, respeitando os modelos de dados que criamos, deve ser corrido em 2 contextos, pois temos um ApplicationDbContext que é responsavel pelo conteste da Aplicação, no caso a parte de registro de usuários e autenticação e o TecLibrasContext que é resposavel pela parte da mecanica do jogo, no caso a tabela de pontos.

```console
C:\TecLibrasBackEnd\src\TecLibras.Services.Api> dotnet tool install --global dotnet-ef
You can invoke the tool using the following command: dotnet-ef
Tool 'dotnet-ef' (version '3.1.3') was successfully installed.

C:\TecLibrasBackEnd\src\TecLibras.Services.Api> dotnet ef database update  --context ApplicationDbContext
Build started...
Build succeeded.
Done.

C:\TecLibrasBackEnd\src\TecLibras.Services.Api> dotnet ef database update  --context TecLibrasContext
Build started...
Build succeeded.
Done.

```

## Documentação





