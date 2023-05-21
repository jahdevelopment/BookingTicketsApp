Duck mallard = new Mallard();

Duck rubberDuck = new RubberDuck();

mallard.PerformFlyBehaviour();
mallard.PerformQuackBehaviour();
// mallard duck gets tired
mallard.FlyBehaviour = new FlyForTwoMinutes();
mallard.PerformFlyBehaviour();

rubberDuck.PerformFlyBehaviour();
rubberDuck.PerformQuackBehaviour();

public abstract class Duck
{
    protected QuackBehaviour QuackBehaviour { get; set; }
    public FlyBehaviour FlyBehaviour { get; set; }

    public void PerformFlyBehaviour()
    {
        FlyBehaviour.Fly();
    }
    public void PerformQuackBehaviour()
    {
        QuackBehaviour.Quack();
    }


    public void Swim()
    {
        Console.WriteLine("The duck swims around.");
    }

    public abstract void Display();
}

public class Mallard : Duck
{
    public override void Display()
    {
        Console.WriteLine("This duck looks like a mallard.");
    }

    public Mallard()
    {
        FlyBehaviour = new FlyWithWings();
        QuackBehaviour = new QuackLikeADuck();
    }
}

// Redheads can only fly for two minutes
public class RedHead : Duck
{
    public override void Display()
    {
        Console.WriteLine("This duck looks like a redhead.");
    }

    public RedHead()
    {
        FlyBehaviour = new FlyForTwoMinutes();
        QuackBehaviour = new QuackLikeADuck();
    }

}

public class RubberDuck : Duck
{
    public override void Display()
    {
        Console.WriteLine("Looks like a rubber duck.");
    }

    public RubberDuck()
    {
        FlyBehaviour = new FlyFlightless();
        QuackBehaviour = new QuackSqueak();
    }
}

public class WoodenDecoyDuck : Duck
{
    public override void Display()
    {
        Console.WriteLine("Looks like a real duck but made of wood.");
    }

    public WoodenDecoyDuck()
    {
        FlyBehaviour = new FlyFlightless();
        QuackBehaviour = new QuackMute();
    }
}

// FLY BEHAVIOUR
public interface FlyBehaviour
{
    public void Fly();
}
public class FlyWithWings : FlyBehaviour
{
    public void Fly()
    {
        Console.WriteLine("The duck flaps its wings and flies around");
    }
}
public class FlyFlightless : FlyBehaviour
{
    public void Fly()
    {
        Console.WriteLine("This duck cannot fly.");
    }
}
public class FlyForTwoMinutes : FlyBehaviour
{
    public void Fly()
    {
        Console.WriteLine("The duck flies for two minutes at most.");
    }
}

// QUACK BEHAVIOUR
public interface QuackBehaviour
{
    public void Quack();
}
public class QuackLikeADuck : QuackBehaviour
{
    public void Quack()
    {
        Console.WriteLine("The duck makes the sound that most living ducks will make.");
    }
}
public class QuackSqueak : QuackBehaviour
{
    public void Quack()
    {
        Console.WriteLine("Squeak squeak!");
    }
}
public class QuackMute : QuackBehaviour
{
    public void Quack()
    {
        Console.WriteLine(". . .");
    }
}
