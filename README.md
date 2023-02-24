# RedisCache
### Built With

This section should list any major tools/libraries used for this project.

* [![Redis][Redis.io]][Redis-url]
* [![Docker][Docker.com]][Docker-Redis-url]
* [![Microsoft.Extensions.Caching.StackExchangeRedis][https://www.nuget.org/packages]][StackExchange-Redis-url]
* [![Microsoft.Extensions.Caching.StackExchangeRedis][https://www.nuget.org/packages]][Microsoft-Extensions-Caching-StackExchangeRedis-url]

## Setting up Redis
[port number] = 5004
Pull and Run the redis image, feel free to declare the name and port number available on your machine.
* npm
  ```sh
run --name [image name] -p [port number]:6379 -d redis
  ```

On `appsettings.json`Declare the redis endpoint, in my Project I had `localhost:[port number]`.
* npm
  ```sh
  {
    "ConnectionStrings": {
        ..
        ..
        "Redis": "localhost:[port number]"
    }
  }
  ```
  If you're using Azure Redis Cache
  Override `appsettings.json` with user secrets on `secrets.json` and it should look similar to the object below:
  ```sh
  {
    "ConnectionStrings": {
        "Redis": "[some name].redis.cache.windows.net:[port number],password=[azure generated password],"
    }
  }


[Redis-url]: https://redis.io/
[Docker-Redis-url]: https://hub.docker.com/_/redis
[StackExchange-Redis-url]:https://www.nuget.org/packages/StackExchange.Redis/
[Microsoft-Extensions-Caching-StackExchangeRedis-url]:https://www.nuget.org/packages/Microsoft.Extensions.Caching.StackExchangeRedis