using System.Diagnostics;
using System.ServiceProcess;
using Workers;

namespace WindowsService
{
    public partial class ServiceShop : ServiceBase
    {
        private Watcher _watcher;     

        public ServiceShop()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            EventLog.WriteEntry("SericeShop started", EventLogEntryType.Information);
            _watcher = new Watcher();
        }

    }
}
