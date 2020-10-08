using System;
using System.Diagnostics;
using System.Threading;

namespace LoggingCalculator
{

    public interface ICalculator {


    }
    public class ConcreteCalculator:ICalculator {
        public int Add(int x, int y) {
            Console.WriteLine("Add(x={0}, y={1})",x,y);
            var addition = x + y;
            Console.WriteLine("result={0}",addition);
            return addition;

        }

    }

    public class LoggingCalculator : ICalculator
    {
        ICalculator calculator;
        public LoggingCalculator(ICalculator calculator)
        {
            this.calculator = calculator;
        }
        public int Add(int x, int y) {
            Console.WriteLine("Add(x={0}, y={1})", x, y);
            var addition = x + y;
            Console.WriteLine("result={0}", addition);
            return addition;

        }
    }

    public class ConcreteCalculator2 : ICalculator
    {
        public int Add(int x, int y) {

            return x + y;
        }


    }
    public interface IComponent {

          void Something();

    }
    public class SlowComponent : IComponent
    {
        public SlowComponent()
        {
            random = new Random((int)DateTime.Now.Ticks);
        }
        public void Something()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(random.Next(i)*10);

            }
            
        }
        private readonly Random random;
    }
    public class ProfilingComponent : IComponent
    {
        public ProfilingComponent(IComponent decoratedComponent,IStopWatch stopWatch)
        {
            this.decoratedComponent = decoratedComponent;
            this.stopWatch = stopWatch;
        }

        public void Something()
        {
            stopWatch.Start();
            decoratedComponent.Something();
            var elapsedMiliseconds = stopWatch.Stop();
            Console.WriteLine("The method took {0} seconds to complete");
            elapsedMiliseconds / 1000);
        }

        private readonly IComponent decoratedComponent;
        private readonly IStopWatch stopWatch;
    }

    public class LoggingStopWatch : IStopWatch
    {

        public LoggingStopWatch(IStopWatch decoratedStopWatch)
        {
            this.decoratedStopWatch = decoratedStopWatch;

        }
        public void Start()
        {
            decoratedStopWatch.Start();
            Console.WriteLine("StopWatch started");
        }

        public long Stop()
        {
            var elapsediliseconds = decoratedStopWatch.Stop();

            Console.WriteLine("StopWatch stopped after {0} seconds ",
                TimeSpan.FromMilliseconds(elapsediliseconds).TotalSeconds);
            return elapsediliseconds;
        }
        private readonly IStopWatch decoratedStopWatch;
    }


    public class StopWatchAdapter {
        private readonly Stopwatch stopwatch;
        public StopWatchAdapter(Stopwatch stopwatch)
        {
            this.stopwatch = stopwatch;
        }
        public void Start() {
            this.stopwatch.Start();

        }
        public long Stop() {
            this.stopwatch.Stop();
            var elapsedMiliSeconds = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
            return elapsedMiliSeconds;

        }
   


    }

    public interface IStopWatch
    {
        void Start();
        long Stop();
    }

    class Program
    {



        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
