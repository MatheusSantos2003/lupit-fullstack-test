# Lupit FullStack Test

Application created for the Lupit Fullstack test, built with Angular and .NET, using PostgreSQL database.

## Getting Started:

### Database:

The application uses PostgreSQL version 14 for the database. An exported version of the database can be found in the `lupit-backup.sql` file. If needed, the connection string between the backend and the database is located in the file `backend/LupitBackEnd/Repositories/Connection/DatabaseConnection.cs`, at line 20, as shown below:

```csharp
this.Connection = new NpgsqlConnection("Host=localhost;Database=lupit;Username=postgres;Password='root'");
```

# Backend:
To start the backend, open the solution in Visual Studio (developed using the 2019 edition). If you need to change any port settings, you can find them in the file:
backend/LupitBackEnd/Properties/launchSettings.json

The default port for the application is 2797. You can access the application at http://localhost:2797/swagger/index.html, and API requests are made to the base URL http://localhost:2797/api/.

# Frontend:
The frontend was developed using Angular version 13. To run it, navigate to the frontend/lupit-times folder, install the dependencies using npm install, and start the application using ng serve. If you need to change the backend port, update the value of the port in the files Jogadores.service.ts and times.service.ts, at lines 15 and 11 respectively, as shown below:
```ts
// original: private apiUrl = "http://localhost:2797/api";
// updated: private apiUrl = "http://localhost:{newport}/api";
```
