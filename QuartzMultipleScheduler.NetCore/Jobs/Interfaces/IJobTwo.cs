using System.Threading.Tasks;
using Quartz;

namespace QuartzMultipleScheduler.NetCore.Jobs.Interfaces
{
    public interface IJobTwo
    {
        Task Execute(IJobExecutionContext context);
    }
}
