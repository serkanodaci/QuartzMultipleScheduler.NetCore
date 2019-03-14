using System;
using System.Threading.Tasks;
using Quartz;
using QuartzMultipleScheduler.NetCore.Jobs.Interfaces;

namespace QuartzMultipleScheduler.NetCore.Jobs
{
    [DisallowConcurrentExecution]
    public class JobOne : IJobOne, IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"JobOne is started {DateTime.Now.Second}");
            Console.ResetColor();
        }
    }
}
