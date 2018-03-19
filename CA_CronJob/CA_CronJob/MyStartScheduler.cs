using Quartz;
using Quartz.Impl;

namespace CA_CronJob
{
    public static class MyStartScheduler
    {
        public static IScheduler Baslat()
        {
            ISchedulerFactory schedFact = new StdSchedulerFactory();
            IScheduler sched = schedFact.GetScheduler();
            if (!sched.IsStarted)
                sched.Start();

            return sched;
        }
    }
}