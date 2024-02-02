# Bibliocine

Bibliocine é um mecanismo de busca de filmes e livros com autenticação de usuários e CRUD.

## Pré-requisitos

- [.NET SDK (NET core 7+)](https://dotnet.microsoft.com/download)
- [Node.js (v16.16+)](https://nodejs.org/) e [npm](https://www.npmjs.com/)
- [MySQL](https://www.mysql.com/)

<br>

## Variáveis de ambiente
Para fins de teste, as variáveis de ambiente e credenciais estarão diretamente no arquivo de configuração `appsettings`, sendo válidas durante 1 semana.

<br>

## Instalação

<br>

### 1. Clone o repositório:

   ```bash
   git clone https://github.com/marcosvmaximo/Bibliocine.git
   cd Bibliocine
   ```

<br>

### 2. Configurar back-end

   #### 2.1. Configurar o servidor .NET:

   ```bash
   dotnet restore
   ```
   
   #### 2.2. Configurar banco de dados da aplicação:
   
   Acesse o aquivo appsettings.json:
   
   ```bash
    cd src/Bibliocine.API/
    code appsettings.json 
   ```

   
   Então modifique a Connection String default para as credenciais locais do seu MYSQL:
   
   ```bash
   "ConnectionStrings": {
      "DefaultConnection": "Server=localhost; Port=3306; Database=bibliocine; Uid=root;Pwd=1234;"
     },
   ```

   Para:
   
   ```bash
   "ConnectionStrings": {
      "DefaultConnection": "Server={host}; Port={porta}; Database=bibliocine; Uid={usuario};Pwd={senha};"
     },
   ```

   Roda a migração criando as tabelas:

   - Volte para o diretório raiz Bibliocine:
   ```bash
   cd ../../
   ```

   - Acesse o diretório de Infraestrutura:
   ```bash
   cd src/Bibliocine.Infra  
   ```

   - Roda a migração
   ```bash
   dotnet ef database update -c ApplicationDbContext
   ```

   #### 2.3. Iniciar a API

   Acesse o diretório raiz: `$Bibliocine`

   Rode o projeto: `dotnet run --project src/Bibliocine.API`

<br>

### 3. Configurar front-end
