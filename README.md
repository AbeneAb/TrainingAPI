## Running The Project
We will need the following tools:

* [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/)
* [.Net Core 5 or later](https://dotnet.microsoft.com/download/dotnet-core/5)
* [Docker Desktop](https://www.docker.com/products/docker-desktop)

Follow these steps to get your development environment set up: (Before Running Start the Docker Desktop)
1. Clone the repository
. At the root directory which include **docker-compose.yml** files, run below command:
```
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```


 You can use:

* **Order API -> http://localhost:8000/swagger/index.html**
* **pgAdmin PostgreSQL -> http://localhost:5050**   -- admin@order.com password => admin1234
