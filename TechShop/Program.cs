// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//MAIN CODE
TechShop shopDNS = new DNS();
Client client1 = new Client(shopDNS);
Console.WriteLine("Client 1 DONE");

TechShop shopEldorado = new Eldorado();
Client client2 = new Client(shopEldorado);
Console.WriteLine("Client 2 DONE");

Console.ReadKey();

//pattern
abstract class TechShop
{
    public abstract PCSetup getPCItem();
    public abstract TVSetup getTVItem();
}


class DNS : TechShop
{
    public override PCSetup getPCItem()
    {
        return new Monitor();
    }
    public override TVSetup getTVItem()
    {
        return new TV();
    }
}


class Eldorado : TechShop
{
    public override PCSetup getPCItem()
    {
        return new PC();
    }
    public override TVSetup getTVItem()
    {
        return new Speaker();
    }
}


abstract class PCSetup
{
    public abstract void getItem();
}


abstract class TVSetup
{
    public abstract void getItem();
}


class Monitor : PCSetup
{
    public override void getItem()
    {
        Console.WriteLine("Got Monitor");
    }
}


class TV : TVSetup
{
    public override void getItem()
    {
        Console.WriteLine("Got TV");
    }
}


class PC : PCSetup
{
    public override void getItem()
    {
        Console.WriteLine("Got PC");
    }
}


class Speaker : TVSetup
{
    public override void getItem()
    {
        Console.WriteLine("Got Speaker");
    }
}

class Consultant //Facade
{
    
    private PCSetup pc;
    private TVSetup tv;

    // Constructor
    public Consultant(TechShop factory)
    {
        tv = factory.getTVItem();
        pc = factory.getPCItem();
    }

    public void Run()
    {
        pc.getItem();
        tv.getItem();
    }
}

class Client//т.к. мы используем фасад, клиент взаимодействует только с ним. Он передаёт тот магазин, куда отправился
{
    Consultant consultant;
    public Client(TechShop shop)
    {
        consultant = new Consultant(shop);
        consultant.Run();
    }
}
