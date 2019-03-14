using System;
using System.Threading.Tasks;
using Quartz;
using QuartzMultipleScheduler.NetCore.Jobs.Interfaces;

namespace QuartzMultipleScheduler.NetCore.Jobs
{
    [DisallowConcurrentExecution]
    public class JobTwo : IJobTwo, IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"JobTwo is started {DateTime.Now.Second}");
            Console.ResetColor();
        }
    }
}
