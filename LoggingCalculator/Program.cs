using System;

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


    class Program
    {



        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
