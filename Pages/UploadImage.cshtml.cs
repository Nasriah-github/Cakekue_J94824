using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace Cakekue_J94824.Pages
{
    public class UploadImageModel : PageModel
    {
        private readonly ILogger<UploadImageModel> _logger;
        private readonly IHostEnvironment _environment;

        [BindProperty]
        public IFormFile UploadedFile { get; set; }

        public UploadImageModel(ILogger<UploadImageModel> logger,
            IHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public async Task OnPostAsync()
        {
            if (UploadedFile == null || UploadedFile.Length == 0)
            {
                return;
            }
            _logger.LogInformation($"Uploading {UploadedFile.FileName}.");
            var id = Request.Query["id"];
            string extension = Path.GetExtension(UploadedFile.FileName);
            string newFileName = id + extension;
            string targetFileName = $"{_environment.ContentRootPath}/wwwroot/images/{newFileName}";

            using (var stream = new FileStream(targetFileName, FileMode.Create))
            {
                await UploadedFile.CopyToAsync(stream);
            }
        }
    }
}


