# RedisCache
### Built With

This section should list any major tools/libraries used for this project.

* [![Redis][Redis]][Redis-url]
* [![Docker][Docker]][DockerRedis-url]

## Setting up Redis
[port number] = 5004
Pull and Run the redis image, feel free to declare the name and port number available on your machine.

```sh
docker run --name [image name] -p [port number]:6379 -d redis
  ```

On appsettings.json Declare the redis endpoint, in my Project I had localhost:[port number].

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
```
<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[Redis]: https://img.shields.io/badge/Redis-4A4A55?style=for-the-badge&logo=redis&logoColor=FF3E00
[Redis-url]: https://redis.com
[Docker]: https://img.shields.io/badge/Docker-086DD7?style=for-the-badge&logo=docker&logoColor=FAFAFA
[DockerRedis-url]: https://hub.docker.com/_/redis
