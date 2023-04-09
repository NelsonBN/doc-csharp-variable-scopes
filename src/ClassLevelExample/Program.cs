var demoClass = new DemoClass();
demoClass.Method();
Console.WriteLine($"Outside: {demoClass.Variable}");

class DemoClass
{
    // This is a class level variable
    public string Variable = "Hello World!";

    public DemoClass()
    {
        Console.WriteLine($"Constructor: {Variable}");
    }

    public void Method()
    {
        Console.WriteLine($"Method: {Variable}");
    }
}
