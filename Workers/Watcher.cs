using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Configuration;

namespace Workers
{
    public class Watcher
    {
        private RecordsHandler _recordsHandler;
        private FileSystemWatcher _fileWatcher;      

        public Watcher()
        {
            _recordsHandler = new RecordsHandler();
            _fileWatcher = new FileSystemWatcher();  
            _fileWatcher.Path = ConfigurationManager.AppSettings["PathNotProcessed"];           
            _fileWatcher.Filter = "*.csv";
            _fileWatcher.NotifyFilter = NotifyFilters.FileName;       
            _fileWatcher.Created += new FileSystemEventHandler(OnChanged);
            _fileWatcher.EnableRaisingEvents = true;
        }
        
        public void OnChanged(object source, FileSystemEventArgs e)
        {            
            Task task = new Task(() => { CallParse(source, e);  });
            task.Start();
            Thread.Sleep(500);
        }
        public void CallParse(object source, FileSystemEventArgs e)
        {
                string path;
                MoveFile moveFile = new MoveFile("\\" + e.Name);
                path = e.FullPath;
                _recordsHandler.SaveRecords(path);
                moveFile.MovedFile();          
       
        }
        public void Dispose()
        {
            _fileWatcher.Dispose();
        }
    }
}
