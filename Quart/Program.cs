using Quartz;
using Quartz.Impl;
using Quartz.Impl.Calendar;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Quart
{
    class Program
    {
        static  void  Main(string[] args)
        {
            try {
                Run();
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }


            AutoResetEvent ev = new AutoResetEvent(false);
            ev.WaitOne();
        }

        public static async void Run()
        {
            Console.WriteLine("------- Initializing ----------------------");

            // First we must get a reference to a scheduler
            var properties = new NameValueCollection
            {
                ["quartz.scheduler.instanceName"] = "XmlConfiguredInstance",
                ["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz",
                ["quartz.threadPool.threadCount"] = "10",
                ["quartz.plugin.xml.type"] = "Quartz.Plugin.Xml.XMLSchedulingDataProcessorPlugin, Quartz.Plugins",
                ["quartz.plugin.xml.fileNames"] = "~/quartz_jobs.xml",
                // this is the default
                ["quartz.plugin.xml.FailOnFileNotFound"] = "true",
                // this is not the default
                ["quartz.plugin.xml.failOnSchedulingError"] = "true"
            };

            // set thread pool info

            // job initialization plugin handles our xml reading, without it defaults are used

            ISchedulerFactory sf = new StdSchedulerFactory(properties);
            IScheduler sched = await sf.GetScheduler();

            // we need to add calendars manually, lets create a silly sample calendar
            //var dailyCalendar = new DailyCalendar("00:01", "23:59");
            //dailyCalendar.InvertTimeRange = true;
            //await sched.AddCalendar("cal1", dailyCalendar, false, false);

            Console.WriteLine("------- Initialization Complete -----------");

            // all jobs and triggers are now in scheduler

            // Start up the scheduler (nothing can actually run until the
            // scheduler has been started)
            await sched.Start();
            Console.WriteLine("------- Started Scheduler -----------------");

            // wait long enough so that the scheduler as an opportunity to
            // fire the triggers
            Console.WriteLine("------- Waiting 30 seconds... -------------");

            await Task.Delay(30 * 1000);

            // shut down the scheduler
            Console.WriteLine("------- Shutting Down ---------------------");
            await sched.Shutdown(true);

            Console.WriteLine("------- Shutdown Complete -----------------");
        }
    }
}
