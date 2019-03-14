using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;

namespace QuartzMultipleScheduler.NetCore
{
    public static class QuartzExtensions
    {
        private static IServiceCollection _serviceCollection;
        public static List<QuartzJobs> _jobs;

        public static void AddQuartz(this IServiceCollection services, List<QuartzJobs> jobs)
        {
            _serviceCollection = services;
            _jobs = jobs;
        }

        public static void UseQuartz(this IServiceProvider app)
        {
            foreach (var j in _jobs)
            {
                IJobDetail jobDetail = JobBuilder.Create(j.JobType).Build();
                ITrigger trigger = TriggerBuilder.Create()
                    .StartNow()
                    .WithCronSchedule(j.CronExpression)
                    .Build();
                var schedulerFactory = new StdSchedulerFactory();
                IScheduler scheduler = schedulerFactory.GetScheduler().Result;
                scheduler.StartDelayed(TimeSpan.Zero);
                scheduler.Start().Wait();
                scheduler.ScheduleJob(jobDetail, trigger);
                _serviceCollection.AddSingleton<IScheduler>(scheduler);
            }
        }

        public class QuartzJobs
        {
            public Type JobType { get; set; }
            public string CronExpression { get; set; }
        }
    }
}