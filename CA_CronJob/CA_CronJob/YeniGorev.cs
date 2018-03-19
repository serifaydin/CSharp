using Quartz;
using System;

namespace CA_CronJob
{
    public class YeniGorev: IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("1 Dakikada Bir sonsuza kadar çalışacak");
        }
    }
}