using System;

#region ConcreteClasses
public abstract class Client
{
    protected AccessHandler _accessHandler { get; set; }

    public string Name { get; set; }
    public string Email { get; set; }
    public int? Age { get; set; }
    public bool AccessDisabled { get; set; }

    public virtual void HandleAccess()
    {
        bool access = _accessHandler.GetAccess();
        Console.WriteLine($"Access granted: {access}");
    }
}

public class User : Client
{
    private int _reputation;

    public int Reputation
    {
        get { return _reputation; }
        set { _reputation = value; }
    }

    public override void HandleAccess()
    {
        _accessHandler = new HasReputation();
        base.HandleAccess();
    }
}

public class Manager : Client
{
    public Manager()
    {
        _accessHandler = new HasAccessAutomatic();
    }
}

public class Admin : Client
{
    public Admin()
    {
        _accessHandler = new HasAccessAutomatic();
    }
}
#endregion

#region Behaviours

public interface AccessHandler
{
    bool GetAccess(int? reputation = 0, bool accessDisabled = false);
}

public class HasReputation : AccessHandler
{
    public bool GetAccess(int? reputation = 0, bool accessDisabled = false)
    {
        return reputation > 20 && !accessDisabled;
    }
}

public class HasAccessAutomatic : AccessHandler
{
    public bool GetAccess(int? reputation = 0, bool accessDisabled = false)
    {
        return !accessDisabled;
    }
}

#endregion

public class Program
{
    public static void Main(string[] args)
    {
        User userOne = new User();
        userOne.Reputation =1;
        userOne.AccessDisabled = true;
        Console.WriteLine(userOne.Reputation);
        Console.WriteLine(userOne.AccessDisabled);
        userOne.HandleAccess();
        Console.WriteLine();

        Manager managerOne = new Manager();
        managerOne.AccessDisabled = true;
        Console.WriteLine(managerOne.AccessDisabled);
        managerOne.HandleAccess();
        Console.WriteLine();

        Admin adminOne = new Admin();
        adminOne.AccessDisabled = true;
        Console.WriteLine(adminOne.AccessDisabled);
        adminOne.HandleAccess();

        Console.ReadLine();
    }
}
