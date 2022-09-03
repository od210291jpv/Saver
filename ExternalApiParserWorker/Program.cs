using ExternalApiParserWorker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<ParserWorker>();
    })
    .Build();

await host.RunAsync();
