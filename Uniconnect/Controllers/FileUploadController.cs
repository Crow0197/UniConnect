using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniConnect.BLL.Service;

namespace UniConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly FileUploadService _fileUploadService;

        public FileUploadController(FileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadBase64File([FromBody] FileUploadRequest request)
        {
            try
            {
                if (!string.IsNullOrEmpty(request.Base64File))
                {
                    var fileId = await _fileUploadService.UploadFileAsync(request.Base64File,"upload");
                    return Ok(new { fileId });
                }

                return BadRequest("Il file è vuoto");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Errore interno del server: {ex.Message}");
            }
        }

        //[HttpPost("upload-multiple")]
        //public async Task<IActionResult> UploadMultipleBase64Files([FromBody] List<string> base64Files)
        //{
        //    try
        //    {
        //        if (base64Files != null && base64Files.Count > 0)
        //        {
        //            var fileIds = await _fileUploadService.UploadMultipleFilesAsync(base64Files);
        //            return Ok(new { fileIds });
        //        }

        //        return BadRequest("La lista dei file è vuota");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Errore interno del server: {ex.Message}");
        //    }
        //}
    }
}
