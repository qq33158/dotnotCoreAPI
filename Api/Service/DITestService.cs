namespace Api.Service
{
    public class DITestService
    {
        private readonly TransientService _transientService;
        private readonly ScopedService _scopedService;
        private readonly SingletonService _singletonService;       
        // 注入DI
        public DITestService(
            TransientService transientService,
            ScopedService scopedService,
            SingletonService singletonService
            )
        {
            _transientService = transientService;
            _scopedService = scopedService;
            _singletonService = singletonService;          
        }

        public void RunDITest()
        {
            _transientService.CountAddOne();
            _scopedService.CountAddOne();
            _singletonService.CountAddOne();         
        }
    }
}
