using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using Repo.Ef;
using Repo.Ef.Models;
using Repo.Ef.Repository;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace UniConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<FileStorage> _repository;
        private readonly IRepositoryFile _repositoryFile;


        public FileUploadController(IRepositoryFile repositoryFile,IConfiguration configuration, IRepository<FileStorage> repository)
        {
            _configuration = configuration;
            _repository = repository;
            _repositoryFile = repositoryFile;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadBase64File([FromBody] FileUploadRequest request)
        {
            try
            {
                if (!string.IsNullOrEmpty(request.Base64File))
                {
                    var base64Data = request.Base64File.Split(',')[1]; // Rimuovi il prefisso "data:image/jpeg;base64,"
                    var fileBytes = Convert.FromBase64String(base64Data);

                    var fileName = Guid.NewGuid().ToString(); // Genera un nome univoco per il file
                    var fileExtension = ".png"; // Imposta l'estensione del file (puoi personalizzarla)
                    var uploadPath =  @"C:\UniconnectData\"; // Imposta il percorso di caricamento dal file appsettings.json

                    var filePath = Path.Combine(uploadPath, fileName + fileExtension);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await stream.WriteAsync(fileBytes, 0, fileBytes.Length); // Salva il file sul disco
                    }

                    // Ora puoi salvare l'ID del file e altre informazioni nel database
                    var fileId = await SaveFileToDatabase(fileName, fileExtension, filePath);

                    return Ok(new { fileId }); // Restituisci l'ID del file creato come risposta
                }

                return BadRequest("Il file è vuoto");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Errore interno del server: {ex.Message}");
            }
        }

        private async Task<int> SaveFileToDatabase(string fileName, string fileExtension, string filePath)
        {
            var fileEntity = new FileStorage
            {
                FileName = fileName,
                FilePath = filePath, // Sostituisci con il percorso reale del file
                FileType = fileExtension
            };
            var fileId = await _repositoryFile.AddAsync(fileEntity);

            return fileId; // Sostituisci con l'ID effettivo del file creato
        }

    }
}
