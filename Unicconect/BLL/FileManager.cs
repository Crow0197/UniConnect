using System.IO;

namespace UniConnect.BLL
{
    public class FileManager
    {
        private readonly string baseFolderPath;

        public FileManager()
        {
            // Specifica la cartella di base nel costruttore della classe.
            this.baseFolderPath = @"C:\UniconnectData"; // Sostituisci con il percorso desiderato.

            // Assicurati che la cartella base esista, altrimenti creala.
            if (!Directory.Exists(baseFolderPath))
            {
                Directory.CreateDirectory(baseFolderPath);
            }
        }

        public string SaveFile(byte[] fileData, string fileName)
        {
            // Componi il percorso completo del file.
            string filePath = Path.Combine(baseFolderPath, fileName);

            // Scrivi i dati del file sul disco.
            File.WriteAllBytes(filePath, fileData);

            return filePath;
        }

        public byte[] LoadFile(string filePath)
        {
            // Verifica se il file esiste.
            if (File.Exists(filePath))
            {
                // Carica i dati del file.
                return File.ReadAllBytes(filePath);
            }

            // Se il file non esiste, restituisci null o gestisci l'errore come preferisci.
            return null;
        }
    }
}
