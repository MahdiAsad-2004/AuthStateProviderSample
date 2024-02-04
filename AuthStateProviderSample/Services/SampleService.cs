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
            _logger.LogWarning($"Entity {entityname} Create By '{_stateService.Username}'");
        }

    }
}
