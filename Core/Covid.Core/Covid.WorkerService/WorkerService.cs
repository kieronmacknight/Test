using Covid.WorkerService.EventListeners;
using log4net;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Topshelf;

namespace Covid.WorkerService
{
    sealed class WorkerService : ServiceControl
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(WorkerService));
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private readonly IList<Task> _tasks = new List<Task>();
        private TemplateEventListener1 _templateEventListener1 = new TemplateEventListener1();
        private TemplateEventListener2 _templateEventListener2 = new TemplateEventListener2();

        public bool Start(HostControl hostControl)
        {
            _logger.Info($"Starting service '{nameof(WorkerService)}'");
            _tasks.Add(_templateEventListener1.Run(_cancellationTokenSource.Token));
            _tasks.Add(_templateEventListener2.Run(_cancellationTokenSource.Token));
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _logger.Info($"Stopping service '{nameof(WorkerService)}'");
            _cancellationTokenSource.Cancel();
            if (_tasks.Any())
            {
                Task.WhenAll(_tasks).GetAwaiter().GetResult();
            }
            _logger.Info($"Stopped service '{nameof(WorkerService)}'");
            return true;
        }
    }
}
