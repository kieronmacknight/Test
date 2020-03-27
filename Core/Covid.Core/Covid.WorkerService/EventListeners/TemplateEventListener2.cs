using log4net;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Covid.WorkerService.EventListeners
{
    sealed class TemplateEventListener2
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(TemplateEventListener2));
        private readonly Random rnd = new Random();

        public async Task Run(CancellationToken cancellationToken)
        {
            int cnt = 0;
            while (!cancellationToken.IsCancellationRequested && cnt < 500)
            {
                _logger.Info($"Listener '{nameof(TemplateEventListener2)}' logged at '{DateTime.UtcNow.ToString("yyyy/MM/dd hh:mm:ss")}'");
                await Task.Delay(rnd.Next(0, 5) * 1000);
                cnt++;
            }
        }
    }
}
