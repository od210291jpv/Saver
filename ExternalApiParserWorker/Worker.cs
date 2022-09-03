namespace ExternalApiParserWorker
{
    public class ParserWorker : BackgroundService
    {
        private readonly ILogger<ParserWorker> _logger;

        private List<IHost> allHosts;

        public ParserWorker(ILogger<ParserWorker> logger)
        {
            _logger = logger;
        }

        public void AddHosts(params IHost[] hosts) 
        {
            foreach(var host in hosts) 
            {
                this.allHosts.Add(host);
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}