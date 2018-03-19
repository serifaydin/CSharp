using Quartz;
using System;

namespace CA_CronJob
{
    public static class GorevleriTetikle
    {
        public static void Gorev1Tetikle()
        {
            IScheduler sched = MyStartScheduler.Baslat();

            IJobDetail Gorev = JobBuilder.Create<Gorev>().WithIdentity("Gorev", null).Build();

            ISimpleTrigger triggerGorev = (ISimpleTrigger)TriggerBuilder.Create().WithIdentity("Gorev").StartAt(DateTime.UtcNow).WithSimpleSchedule(x => x.WithIntervalInSeconds(5).RepeatForever()).Build();
            sched.ScheduleJob(Gorev, triggerGorev);

        }

        public static void Gorev2Tetikle()
        {
            IScheduler sched = MyStartScheduler.Baslat();

            IJobDetail Gorev = JobBuilder.Create<YeniGorev>().WithIdentity("YeniGorev", null).Build();

            ISimpleTrigger triggerGorev = (ISimpleTrigger)TriggerBuilder.Create().WithIdentity("YeniGorev").StartAt(DateTime.UtcNow).WithSimpleSchedule(x => x.WithIntervalInMinutes(1).RepeatForever()).Build();
            sched.ScheduleJob(Gorev, triggerGorev);
        }
    }
}
