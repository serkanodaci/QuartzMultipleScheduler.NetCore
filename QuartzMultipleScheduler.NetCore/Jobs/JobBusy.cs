using System;
using System.Threading.Tasks;
using Quartz;
using QuartzMultipleScheduler.NetCore.Jobs.Interfaces;

namespace QuartzMultipleScheduler.NetCore.Jobs
{
    [DisallowConcurrentExecution]
    public class JobBusy : IJobBusy, IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"JobBusy is started. This job will not restart before the task is finished {DateTime.Now.Second}");
            Console.ResetColor();
            for (int i = 0; i < 20; i++)
            {
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
