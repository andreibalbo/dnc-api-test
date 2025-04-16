### DNC

This is a project to test an integration between a .NET Core API using MongoDB as database   and a Vue.js frontend.

### Running the project

Run `docker compose up -d` to start all containers.

### API

1. Enter the container `docker exec -it api bash`  
2. Run `dotnet run` to start the API

### Frontend

1. Enter the container `docker exec -it app sh`
2. Run `yarn install` to install the dependencies
3. Run `yarn start` to start the frontend

### Accessing the application

1. Open the browser and access `http://localhost:8080`
2. You should see the application running

### DB inspection

You can use some of the MongoDB tools to inspect the database (e.g. MongoDB Compass).

Connect via `mongodb://mongodb:27017/blogdb`

