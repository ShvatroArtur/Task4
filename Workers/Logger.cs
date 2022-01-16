using System;
using System.Configuration;
using System.IO;


namespace Workers
{
    public class Logger
    {
        private string _path;
        private string _fileLog;
        public Logger()
        {
            _path = ConfigurationManager.AppSettings["PathNotProcessed"];
            _fileLog = ConfigurationManager.AppSettings["FileLog"];
        }

        public void RecordInFileLog(string typeObject, string nameObject, string idObject)
        {
            using (StreamWriter writer = new StreamWriter(_path + _fileLog, true))
            {
                writer.WriteLine(String.Format("{0} add {1}: Id = {2}; Name = {3}",
                    DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), typeObject, idObject, nameObject));
                writer.Flush();
            }
            Console.WriteLine(String.Format("{0} add {1}: Id = {2}; Name = {3}",
                    DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), typeObject, idObject, nameObject));
        }
        public void RecordInFileLog(string typeObject, string idObject, string idManager, string idClient, string idProduct)
        {
            using (StreamWriter writer = new StreamWriter(_path + _fileLog, true))
            {
                writer.WriteLine(String.Format("{0} add {1}: Id = {2}; IdManager = {3}; IdCient = {4}; IdProduct = {5}",
                    DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), typeObject, idObject, idManager, idClient, idProduct));
                writer.Flush();
            }
            Console.WriteLine(String.Format("{0} add {1}: Id = {2}; IdManager = {3}; IdCient = {4}; IdProduct = {5}",
                   DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), typeObject, idObject, idManager, idClient, idProduct));
        }


    }
}

