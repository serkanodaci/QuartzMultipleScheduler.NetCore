using System.Threading.Tasks;
using Quartz;

namespace QuartzMultipleScheduler.NetCore.Jobs.Interfaces
{
   public interface IJobBusy
    {
       Task Execute(IJobExecutionContext context);
   }
}
