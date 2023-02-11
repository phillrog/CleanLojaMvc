# CleanLojaMvc

### Objetivo
Implementar arquitetura clean em um pequeno projeto

![image](https://user-images.githubusercontent.com/8622005/218283112-ccce49d3-d9b8-4bc5-8020-a492d781121d.png)

### Premissa
Organizar o projeto com base na separarção dos princípios de responsabilidade de forma que ele seja fácil de entender, fácil de testar, fácil de manter e fácil de mudar conforme o projeto cresce. Ou seja, seguir a regra de depêndencia, que afirma que a depêndencia do código fornte só pode apontar para dentro do aplicativo.

# Libs

- AutoMapper
- MediatR
- Microsoft.AspNetCore.Authentication.JwtBearer
- Swashbuckle.AspNetCore
- Microsoft.AspNetCore.Identity
- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.EntityFrameworkCore

# CleanLojaMvc.Infra.Data
- Executar ```dotnet ef database update``` para subir os migrations

# Solução

![image](https://user-images.githubusercontent.com/8622005/218283282-1f3839e9-d858-4fb2-97b3-03ac6f02385f.png)

![image](https://user-images.githubusercontent.com/8622005/218283026-778f42a7-ac8e-4a14-adf4-69f31e2ba5f7.png)

# Organização

- CleanLojaMvc.Domain.csproj : Não possui nenhuma depêndencia
- CleanLojaMvc.Application.csproj : Depêndencia com o projeto >  Domain
- CleanLojaMvc.Infra.Data.csproj : Depêndencia com o projeto >  Domain
- CleanLojaMvc.Infra.IoC.csproj  : Depêndencia com o projeto >  Domain, Application, Data
- CleanLojaMvc.WebUI.csproj : Depêndencia com o projeto >  IoC
- CleanLojaMvc.Test.csproj : Depêndencia com o projeto >  IoC
- CleanLojaMvc.API.csproj : Depêndencia com o projeto >  Domain, Apllication

# Resultado
![image](https://user-images.githubusercontent.com/8622005/218283054-25d3f4b9-dcc0-4616-b089-2e17ce8f619a.png)

![image](https://user-images.githubusercontent.com/8622005/218283082-d8c10c4c-9d19-4f16-90e3-df3fd7cb8b89.png)

