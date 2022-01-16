using System.Configuration;
using System.IO;

namespace Workers
{
    public class MoveFile
    {

        private string _pathNotProcessed;
        private string _pathProcessed;
        private string _nameFile;
        public MoveFile(string nameFile)
        {
            _pathNotProcessed = ConfigurationManager.AppSettings["PathNotProcessed"];
            _pathProcessed = ConfigurationManager.AppSettings["PathProcessed"]; 
            _nameFile = nameFile;
        }
        public void MovedFile()
        {
            var fileNotProcessed = _pathNotProcessed + _nameFile;
            var fileProcessed = _pathProcessed + _nameFile;
            if (File.Exists(fileProcessed))
            {
                File.Delete(fileProcessed);
            }

            File.Move(fileNotProcessed, fileProcessed);
        }

    }
}
