using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace MyFunctionApp
{
    public class TimerTriggerFunction
    {
        private readonly ILogger _logger;

        public TimerTriggerFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<TimerTriggerFunction>();
        }

        [Function("TimerTriggerFunction")]
        public void Run([TimerTrigger("0 */30 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"C# Timer trigger function executed at: {DateTime.Now}");

            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
                Console.WriteLine($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
            Console.WriteLine("###########################################################");
        }
    }
}
