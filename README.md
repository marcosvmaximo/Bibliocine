# Bibliocine
Bibliocine é um mecanismo de busca de filmes e livros com autenticação de usuários e operações CRUD.

Optei por unificar as buscas de filmes e livros sob a entidade "Obra", mantendo a distinção entre livros e filmes na interface. Utilizei APIs externas do Google e da TMDB para enriquecer os dados disponíveis.

- [API do Google Books](https://developers.google.com/books?hl=pt-br)
- [API da The Movie Database (TMDb)](https://developer.themoviedb.org/reference/intro/getting-started)

Na aplicação .NET, escolhi demonstrar algumas habilidades específicas, e a arquitetura reflete uma escolha mais voltada para fins de demonstração do que para um cenário real. Quanto ao Vue, optei por utilizar TypeScript para aproveitar minha experiência anterior com Angular, embora reconheça que não atingi o nível desejado no projeto Vue, devido à minha familiaridade limitada com o Vue.js.

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

Do diretório raiz, acesse esse diretório:
```bash
cd web
```

Rode a aplicação:
```bash
npm install
npm run dev
```


<br>

## Conclusão
Com isso, teremos o projeto Vue rodando na porta local: http://127.0.0.1:5173/ e o projeto .NET na porta: http://localhost:5211/. Importante ressaltar que, devido à falta de tempo, não consegui containerizar a aplicação, o que dificulta sua execução em máquinas externas à minha. Portanto, deve-se prestar atenção ao criar o banco de dados para garantir o funcionamento correto da aplicação.

A API possuí a interface do swagger, porém ela não está completamente documentada, então não deve ser considerada a risca.


