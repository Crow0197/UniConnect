using Repo.Ef;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
using Repo.Ef.Models;
using Repo.Ef.Repository;
using Models;

namespace UniConnect.BLL.Service
{
    public class FileUploadService
    {
        private readonly IRepository<FileStorage> _repository;
        private readonly IRepositoryFile _repositoryFile;


        public FileUploadService(IRepositoryFile repositoryFile, IRepository<FileStorage> repository)
        {
            _repository = repository;
            _repositoryFile = repositoryFile;
        }

        public async Task<UtilityFile> UploadFileAsync(string base64File, string nameFile)
        {
            if (!string.IsNullOrEmpty(base64File))
            {
                var base64Parts = base64File.Split(',');
                if (base64Parts.Length == 2)
                {
                    var base64Data = base64Parts[1];

                    // Estrai l'estensione dal tipo MIME nel base64 (ad esempio, "data:image/png;base64")
                    var mimeType = base64Parts[0].Split(':')[1].Split(';')[0];
                    var fileExtension = mimeType;

                    var fileBytes = Convert.FromBase64String(base64Data);

                    var fileName = nameFile;
                    var uploadPath = @"C:\UniconnectData"; // Imposta il percorso di caricamento dal file appsettings.json
                    var filePath = Path.Combine(uploadPath, fileName );

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await stream.WriteAsync(fileBytes, 0, fileBytes.Length);
                    }

                    return new UtilityFile()
                    {
                        FileExtension = fileExtension,
                        FileName = fileName,
                        FilePath = filePath,
                    };
                }
                else
                {
                    throw new ArgumentException("Il formato del base64 non è valido");
                }
            }

            throw new ArgumentException("Il file è vuoto");
        }

        //public async Task<List<int>> UploadMultipleFilesAsync(List<string> base64Files)
        //{
        //    var fileIds = new List<int>();

        //    foreach (var base64File in base64Files)
        //    {
        //        var fileId = await UploadFileAsync(base64File);
        //        fileIds.Add(fileId);
        //    }

        //    return fileIds;
        //}

        private async Task<int> SaveFileToDatabase(string fileName, string fileExtension, string filePath)
        {
            var fileEntity = new FileStorage
            {
                FileName = fileName,
                FilePath = filePath,
                FileType = fileExtension
            };

            return await _repositoryFile.AddAsync(fileEntity);
        }


        public async Task<int> SaveFileToDatabasePost(UtilityFile file, Post post)
        {
            var fileEntity = new FileStorage
            {
                FileName = file.FileName,
                FilePath = file.FilePath,
                FileType = file.FileExtension,
                Post = post
            };

            return await _repositoryFile.AddAsync(fileEntity);
        }



        public async Task<string> GetBase64FileAsync(int fileId)
        {
            var fileEntity = await _repository.GetByIdAsync(fileId);

            if (fileEntity != null)
            {
                using (var stream = new FileStream(fileEntity.FilePath, FileMode.Open))
                {
                    var fileBytes = new byte[stream.Length];
                    await stream.ReadAsync(fileBytes, 0, (int)stream.Length);
                    var base64Data = Convert.ToBase64String(fileBytes);
                    return $"data:{fileEntity.FileType};base64,{base64Data}";
                }
            }

            throw new ArgumentException($"File con ID {fileId} non trovato");
        }

        public async Task<FileStorage> GetFileByIdAsync(int fileId)
        {
            return await _repository.GetByIdAsync(fileId);
        }


        private string GetFileExtensionFromMimeType(string mimeType)
        {
            switch (mimeType)
            {
                case "image/jpeg":
                    return ".jpg";
                case "image/png":
                    return ".png";
                case "image/gif":
                    return ".gif";
                case "application/pdf":
                    return "application/pdfpdf";
                case "application/zip":
                    return ".zip";
                case "application/rar":
                    return ".rar";
                // Aggiungi altri tipi di file supportati qui
                default:
                    return ".bin"; // Estensione predefinita in caso di tipo MIME sconosciuto
            }
        }

    }
}