# ASP.NET Core WebAPI OpenTracing Sample

This is a small demonstration application (quite literally, it's the [sample webapi application](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-vsc?view=aspnetcore-2.1) from Microsoft's own documentation) that I've extended with the [OpenTracing .NET Core instrumentation](https://github.com/opentracing-contrib/csharp-netcore). 

This repository is intended to be a small demo of what you can do out of the box with the existing instrumentation packages out there.

# Installation and Use

To run this you'll need:
* [.NET Core SDK 2.1+](https://www.microsoft.com/net/download/dotnet-core/2.1)
* One of -
  * Jaeger running locally (see [this guide](https://www.jaegertracing.io/docs/1.7/getting-started/) on running Jaeger locally)
  * A LightStep Project Key

To use Jaeger, you'll simply launch the application -
```
dotnet run
```

To use LightStep, set the `LS_KEY` environment variable -
```
LS_KEY="whateverYourKeyIs" dotnet run
```

Once the application is up and running, you'll be able to use cURL, Postman, or HTTPie to hit the API, like so -

```
$ http --follow --verify=no :5000/api/todo
HTTP/1.1 200 OK
Content-Type: application/json; charset=utf-8
Date: Tue, 23 Oct 2018 19:07:59 GMT
Server: Kestrel
Transfer-Encoding: chunked

[
    {
        "id": 1,
        "isComplete": false,
        "name": "Item1"
    }
]
```

Meanwhile, in your tracer of choice, you should see spans and traces begin to appear.

Let me know if you run into any issues!
