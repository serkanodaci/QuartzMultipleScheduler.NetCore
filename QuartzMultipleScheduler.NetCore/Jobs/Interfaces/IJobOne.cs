using System.Threading.Tasks;
using Quartz;

namespace QuartzMultipleScheduler.NetCore.Jobs.Interfaces
{
   public interface IJobOne
    {
       Task Execute(IJobExecutionContext context);
   }
}
