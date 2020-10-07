using System; 

namespace PredicateDecorator
{
    class Program
    {
        delegate int DoTheDo(int x);
        static void Main(string[] args)
        {
            int y = 3;
            Do((int x) => { Console.WriteLine(y); return 2; });
        }


        static void Do(DoTheDo doit) {
            doit.Invoke(2);

        }
    }

    public class DateTester {

        public bool TodayIsAnEvenDayOfTheMonth
        {

            get {

                return DateTime.Now.Day % 2 == 0;
            }

        }

    }


    public interface IComponent {


        void Something();

    }
    public class PredicateDecoratorExample {
        IComponent component;
        public PredicateDecoratorExample(IComponent component)
        {
            this.component = component;
        }
        public void Run(DateTester dateTester)
        {
             
            if (dateTester.TodayIsAnEvenDayOfTheMonth)
            {
                component.Something();

            }


        }

    }

    public interface IPredicate {

        bool Test();

    }

    public class PredicateDecoratorExample2:IComponent
    {
        IComponent component;
        IPredicate predicate;
        public PredicateDecoratorExample2(IComponent component,IPredicate predicate)
        {
            this.component = component;
            this.predicate = predicate;
        }
       

        public void Something()
        {
            if (predicate.Test())
            {
                component.Something();


            }
        }
    }

    public class TodayIsAnEvenDayOfTheMonthPredicate : IPredicate
    {
        private readonly DateTester dateTester;
        public TodayIsAnEvenDayOfTheMonthPredicate(DateTester tester)
        {
            this.dateTester = tester;

        }
        public bool Test()
        {
            return dateTester.TodayIsAnEvenDayOfTheMonth;
        }
    }


    public class BranchedComponent : IComponent
    {
        private IComponent trueComponent;
        private IComponent falseComponent;
        private IPredicate predicate;

        public BranchedComponent(IComponent trueComponent, IComponent falseComponent, IPredicate predicate)
        {
            this.trueComponent = trueComponent;
            this.falseComponent = falseComponent;
            this.predicate = predicate;
        }
        public void Something()
        {
            if (predicate.Test())
            {

                trueComponent.Something();

            }
            else {

                falseComponent.Something();
            }
        }
    }

    public class ComponentClient :IComponent{
        private readonly Lazy<IComponent> LazyComponent;
        public ComponentClient(Lazy<IComponent> component)
        {
            this.LazyComponent = component;
            
            
        }

        public void Something()
        {
            LazyComponent.Value.Something();
        }
    }
}
