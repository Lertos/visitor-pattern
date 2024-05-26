using System.Threading.Channels;

namespace visitor_pattern
{
    //A demonstration of the Visitor pattern in C#
    internal class Program
    {
        static void Main(string[] args)
        {
            Home home = new Home();
            Park park = new Park();

            Person person = new Person();
            Robber robber = new Robber();

            person.VisitPark(park);
            person.VisitHome(home);

            robber.VisitPark(park);
            robber.VisitHome(home);

            /* OUTPUT: 
             
                You swing on the swings
                You go to sleep
                You steal a bike
                You steal jewelry
             
             */
        }
    }

    public abstract class Place
    {
        public abstract void Visit(Visitor visitor);
    }

    public abstract class Visitor
    {
        public abstract void VisitPark(Park park);
        public abstract void VisitHome(Home home);
    }

    public class Home : Place
    {
        public override void Visit(Visitor visitor)
        {
            visitor.VisitHome(this);
        }
    }

    public class Park : Place
    {
        public override void Visit(Visitor visitor)
        {
            visitor.VisitPark(this);
        }
    }

    public class Person : Visitor
    {
        public override void VisitPark(Park park)
        {
            Console.WriteLine("You swing on the swings");
        }

        public override void VisitHome(Home home)
        {
            Console.WriteLine("You go to sleep");
        }
    }

    public class Robber : Visitor
    {
        public override void VisitPark(Park park)
        {
            Console.WriteLine("You steal a bike");
        }

        public override void VisitHome(Home home)
        {
            Console.WriteLine("You steal jewelry");
        }
    }
}

