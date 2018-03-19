using Quartz;
using System;

namespace CA_CronJob
{
    public class Gorev: IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("5 Saniyede Bir Sonsuza kadar çalışacak.");
        }
    }
}