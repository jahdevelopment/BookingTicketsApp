using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

ElectricCar tesla = new ElectricCar();
Console.WriteLine(tesla.Description());
tesla.StartCar();
tesla.Accelerate();
tesla.RefuelCar();
tesla.Decelerate();

HyrbridCar Rav4 = new HyrbridCar();
Console.WriteLine(Rav4.Description());
Rav4.StartCar();
Rav4.Accelerate();
Rav4.RefuelCar();
Rav4.Decelerate();

#region ConcreteClasses
public abstract class Car
{
    protected IgnitionBehaviour _ignitionBehaviour;
    protected RefuellingBehaviour _refuellingBehaviour;
    public void StartCar()
    {
        _ignitionBehaviour.StartCar();
    }

    public void RefuelCar()
    {
        _refuellingBehaviour.RefuelCar();
    }

    public void Accelerate()
    {
        Console.WriteLine("The car goes faster");
    }

    public void Decelerate()
    {
        Console.WriteLine("The car slows down.");
    }

    public abstract string Description();
}

public class ElectricCar : Car
{
    public override string Description()
    {
        return "A car that runs solely on an electric battery.";
    }

    public ElectricCar()
    {
        _ignitionBehaviour = new EngineStartElectric();
        _refuellingBehaviour = new RechargeElectric();
    }

}
public class HyrbridCar : Car
{
    public override string Description()
    {
        return "A car that runs on a gasoline engine that also charges an electric battery that can also run the engine.";
    }

    public HyrbridCar()
    {
        _ignitionBehaviour = new EngineStartHybrid();
        _refuellingBehaviour = new RefuelGasoline();
    }
}
public class GasolineCar : Car
{
    public override string Description()
    {
        return "A car that uses gasoline as fuel for a combustion engine.";
    }

    public GasolineCar()
    {
        _ignitionBehaviour = new EngineStartGasoline();
        _refuellingBehaviour = new RefuelGasoline();
    }
}
public class DieselCar : Car
{
    public override string Description()
    {
        return "A car that uses diesel as fuel for a combustion engine.";
    }
}
public class HydrogenCar : Car
{
    public override string Description()
    {
        return "A car that uses hydrogen as fuel for a hydrogen engine.";
    }

    public HydrogenCar()
    {
        _ignitionBehaviour = new EngineStartHydrogen();
        _refuellingBehaviour = new RefuelHydrogen();
    }
}
public class NuclearFusionCar : Car
{
    public override string Description()
    {
        return "A car that uses hydrogen as fuel for a nuclear fusion engine.";
    }

    public NuclearFusionCar()
    {
        _refuellingBehaviour = new RefuelHydrogen();
        _ignitionBehaviour = new EngineStartFusion();
    }
}
#endregion


#region Behaviours

public interface IgnitionBehaviour
{
    public void StartCar();
}

public class EngineStartElectric : IgnitionBehaviour
{
    public void StartCar()
    {
        Console.WriteLine("The car doesn't need to be start, it's always ready to run.");
    }
}
public class EngineStartGasoline : IgnitionBehaviour
{
    public void StartCar()
    {
        Console.WriteLine("The car ignites its gasoline engine.");
    }
}
public class EngineStartHybrid : IgnitionBehaviour
{
    public void StartCar()
    {
        Console.WriteLine("The car ignites its gasoline engine and starts its electric motor.");
    }
}
public class EngineStartHydrogen : IgnitionBehaviour
{
    public void StartCar()
    {
        Console.WriteLine("The car starts its hydrogen engine.");
    }
}
public class EngineStartFusion : IgnitionBehaviour
{
    public void StartCar()
    {
        Console.WriteLine("The car somehow powers itself with nuclear fusion.");
    }
}




public interface RefuellingBehaviour
{
    public void RefuelCar();
}

public class RechargeElectric : RefuellingBehaviour
{
    public void RefuelCar()
    {
        Console.WriteLine("The car needs to be plugged to a DC electric connector.");
    }
}
public class RefuelGasoline : RefuellingBehaviour
{
    public void RefuelCar()
    {
        Console.WriteLine("The car can't be refuelled because the world ran out of gasoline :( ");
    }
}
public class RefuelHydrogen : RefuellingBehaviour
{
    public void RefuelCar()
    {
        Console.WriteLine("The car's fuel tank is filled with hydrogen.");
    }
}


#endregion
