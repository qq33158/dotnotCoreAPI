namespace Api.Service
{
    public class DITestService
    {
        private readonly TransientService _transientService;
        private readonly SingletonService _singletonService;
        private readonly ScopedService _scopedService;
        // 注入DI
        public DITestService(
            TransientService transientService,
            SingletonService singletonService,
            ScopedService scopedService)
        {
            _transientService = transientService;
            _singletonService = singletonService;
            _scopedService = scopedService;
        }

        public void RunDITest()
        {
            _transientService.CountAddOne();
            _singletonService.CountAddOne();
            _scopedService.CountAddOne();
        }
    }
}
