using Covid.WorkerService.Configuration;
using log4net;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Covid.WorkerService.EventListeners
{
    sealed class TemplateEventListener1
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(TemplateEventListener1));
        private readonly Random rnd = new Random();
        private readonly HttpClient _client;
        private readonly Api _api;

        public TemplateEventListener1(Api api)
        {
            if (api == null)
                throw new ArgumentNullException(nameof(api));

            _client = new HttpClient();
            _api = api;
        }


        public async Task Run(CancellationToken cancellationToken)
        {
            try
            {
                var resourceUri = $"{_api.RootUri}Home";

                int cnt = 0;
                while (!cancellationToken.IsCancellationRequested && cnt < 500)
                {
                    var response = await _client.GetAsync(resourceUri).ConfigureAwait(false);
                    var t = response.Content.ReadAsStringAsync();

                    _logger.Info($"Listener '{nameof(TemplateEventListener1)}' - response from '{resourceUri}' - '{t.Result}' - '{DateTime.UtcNow.ToString("yyyy/MM/dd hh:mm:ss")}'");

                    await Task.Delay(rnd.Next(1, 10) * 1000);
                    cnt++;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"An unexpected exception occurred - '{ex.Message}'.", ex);
            }
        }
    }
}
