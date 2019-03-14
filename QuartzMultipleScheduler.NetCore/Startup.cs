using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QuartzMultipleScheduler.NetCore.Jobs;
using QuartzMultipleScheduler.NetCore.Jobs.Interfaces;

namespace QuartzMultipleScheduler.NetCore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IJobOne, JobOne>();
            services.AddTransient<IJobTwo, JobTwo>();
            services.AddQuartz(new List<QuartzExtensions.QuartzJobs>
            {
                new QuartzExtensions.QuartzJobs
                {
                    JobType = typeof(JobOne),
                    CronExpression = Configuration["CronExpressionOne"]
                },
                new QuartzExtensions.QuartzJobs
                {
                    JobType = typeof(JobTwo),
                    CronExpression = Configuration["CronExpressionTwo"]
                },
                new QuartzExtensions.QuartzJobs
                {
                    JobType = typeof(JobBusy),
                    CronExpression = Configuration["CronExpressionBusy"]
                }
            });
            services.BuildServiceProvider().UseQuartz();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory logger)
        {
        }
    }
}
