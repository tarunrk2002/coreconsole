using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mmmmmcore
{
    internal class GreetingService : IGreetingService
    {
        private readonly ILogger<GreetingService> _log;
        private readonly IConfiguration _config;

        public GreetingService(ILogger<GreetingService> log, IConfiguration config)
        {
            this._log = log;
            this._config = config;
        }

        public void Run()
        {
            for (int i = 0; i < _config.GetValue<int>("LoopTimes");)
            {
                _log.LogInformation("jhfurehfreu");
            }


        }
    }
}
