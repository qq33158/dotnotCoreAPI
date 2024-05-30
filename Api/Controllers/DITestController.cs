using Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DITestController : Controller
    {
        private readonly TransientService _transientService;
        private readonly ScopedService _scopedService;
        private readonly SingletonService _singletonService;      
        private readonly DITestService _testDIService;
        public DITestController(
            TransientService transientService,
            ScopedService scopedService,
            SingletonService singletonService,          
            DITestService testDIService)
        {
            _transientService = transientService;
            _scopedService = scopedService;
            _singletonService = singletonService;       
            _testDIService = testDIService;
        }
        [HttpGet]
        public runCount Get()
        {
            _testDIService.RunDITest();    

            _transientService.CountAddOne();
            _scopedService.CountAddOne();
            _singletonService.CountAddOne();           

            var result = new runCount
            {
                Transient = _transientService.count,
                Scoped = _scopedService.count,
                Singleton = _singletonService.count
            };
            return result;
        }


        public class runCount
        {
            public int Transient { set; get; }
            public int Scoped { set; get; }
            public int Singleton { set; get; }
        }
    }
}
