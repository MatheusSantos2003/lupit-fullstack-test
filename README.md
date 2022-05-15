# Lupit Teste FullStack

Aplicação feita no teste Fullstack da Lupit, feito com Angular e .NET, utilizando Banco dados PostgreSQL

## Como iniciar:

### Banco de dados:
 
 No Banco de dados foi-se utilizado a versão 14 do PostgreSQL, um export do banco está presente no arquivo `lupit-backup.sql`.
 Caso haja a necessidade, a string de conexão entre o backend e o Banco de dados está presente no arquivo `backend/LupitBackEnd/Repositories/Connection/DatabaseConnection.cs`, na linha 20, conforme abaixo:
 `this.Connection  =  new  NpgsqlConnection("Host=localhost;Database=lupit;Username=postgres;Password='root'");`

### BackEnd:
O Backend pode abrindo a sua solução no Visual Studio ( foi se utilizado no desenvolvimento a edição 2019), caso seja preciso alterar algum parâmetro de porta, está disponível no arquivo: 
`backend/LupitBackEnd/Properties/launchSettings.json`
 
 a porta padrão da aplicação é 2797, a aplicação se inicia no caminho `http://localhost:2797/swagger/index.html`, as requisições são feitas na url base `http://localhost:2797/api/`

### FrontEnd:

O Frontend foi desenvolvido com Angular na Versão 13, para executar, basta acessar a pasta `frontend/lupit-times`, instalar as dependencias com `npm install` e executar aplicação com `ng serve`. Caso haja a necessidade de trocar a porta do backend, alterar o valor da porta nos arquivos [Jogadores.service.ts](https://github.com/MatheusHenrique200302/lupit-teste-fullstack/blob/main/frontend/lupit-times/src/app/shared/services/jogadores.service.ts) e [times.service.ts](https://github.com/MatheusHenrique200302/lupit-teste-fullstack/blob/main/frontend/lupit-times/src/app/shared/services/times.service.ts), nas linhas 15 e 11, respectivamente, conforme abaixo: 
`antigo: private  apiUrl  =  "http://localhost:2797/api";`
`novo: private apiUrl = "http://localhost:{novaporta}/api";`
