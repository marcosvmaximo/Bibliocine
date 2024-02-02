# Bibliocine

Bibliocine é um mecanismo de busca de filmes e livros com autenticação de usuários e CRUD.

## Pré-requisitos

- [.NET SDK (NET core 7+)](https://dotnet.microsoft.com/download)
- [Node.js (v16.16+)](https://nodejs.org/) e [npm](https://www.npmjs.com/)
- [MySQL]()

## Instalação

### 1. Clone o repositório:

   ```bash
   git clone https://github.com/marcosvmaximo/Bibliocine.git
   cd Bibliocine
   ```

### 2. Configurar back-end

   #### 2.1. Configurar o servidor .NET:

   ```bash
   dotnet restore
   ```
   
   #### 2.2. Configurar banco de dados:
   
   Acesse o aquivo appsettings.json:
   
   ```bash
    cd src/Bibliocine.API/
    code appsettings.json 
   ```

   <br>
   
   Então modifique a Connection String default para as credenciais locais do seu MYSQL:
   
   ```bash
   "ConnectionStrings": {
      "DefaultConnection": "Server=localhost; Port=3306; Database=bibliocine; Uid=root;Pwd=1234;"
     },
   ```
   <br>

   Para:
   
   ```bash
   "ConnectionStrings": {
      "DefaultConnection": "Server={host}; Port={porta}; Database=bibliocine; Uid={usuario};Pwd={senha};"
     },
   ```

<br>
   Roda a migração criando as tabelas:
   
   ```bash
   dotnet ef database update
   ```

   #### 2.3. Configurações de ambientes:
   
   ```bash
   dotnet ef database update
   ```

### 3. Configurar front-end
