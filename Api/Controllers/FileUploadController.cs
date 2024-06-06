using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController :ControllerBase {
        private readonly IWebHostEnvironment _env;
        public FileUploadController(IWebHostEnvironment env) { 
            _env = env;
        }

        // 可使用List<IFormFile>、IFormCollection、Enumerable<IFormFile>
        [HttpPost]
        public void Post([FromForm]IEnumerable<IFormFile> files) {
            string rootRoot = _env.ContentRootPath + @"\wwwroot\";

            if (!Directory.Exists(rootRoot)) {
                Directory.CreateDirectory(rootRoot);
            }        
            
            foreach (var file in files) {
                if (file.Length > 0) {
                    string fileName = file.FileName;
                    using (var steam = System.IO.File.Create(rootRoot + fileName)) {
                        file.CopyTo(steam);
                    }
                }
            } 
        }

        /*
        // 一個一個上傳檔案
        [HttpPost]
        public void Post(IFormFile file1, IFormFile file2) {
            string rootRoot = _env.ContentRootPath + @"\wwwroot\";
            if (file1.Length > 0) {
                string fileName1 = file1.FileName;
                using (var steam = System.IO.File.Create(rootRoot + fileName1)) {
                    file1.CopyTo(steam);
                }
            }
            if (file2.Length > 0) {
                string fileName2 = file2.FileName;
                using (var steam = System.IO.File.Create(rootRoot + fileName2)) {
                    file2.CopyTo(steam);
                }
            }
        }
        */
    }
}
