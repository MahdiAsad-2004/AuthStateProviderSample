namespace AuthStateProviderSample.Services
{
    public class SampleService : ISampleService
    {
        private readonly MYStateService _stateService;
        private readonly ILogger _logger;

        public SampleService(MYStateService stateService,ILogger<SampleService> logger)
        {
            _stateService = stateService;
            _logger = logger;
        }



        public async Task CreateEntity(string entityname)
        {
            //business

            Console.WriteLine($"Entity '{entityname}' Create By '{_stateService.Username}' .");
            _logger.LogTrace($"Entity {entityname} Create By '{_stateService.Username}'");
            _logger.LogInformation($"Entity {entityname} Create By '{_stateService.Username}'");
            _logger.LogCritical($"Entity {entityname} Create By '{_stateService.Username}'");
            _logger.LogDebug($"Entity {entityname} Create By '{_stateService.Username}'");
            _logger.LogError($"Entity {entityname} Create By '{_stateService.Username}'");
            _logger.LogWarning($"Entity {entityname} Create By '{_stateService.Username}'");
            await Console.Out.WriteLineAsync("Logger Type : " + _logger.GetType());
            _logger.Log(LogLevel.Debug, "dsfdsfdfdsfdfg;kmlkm");

            
        }

    }
}
