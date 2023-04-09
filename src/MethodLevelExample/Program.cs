var demoClass = new DemoClass();
demoClass.Method1();
demoClass.Method2();

class DemoClass
{
    string Variable = "Hello galaxy!";

    public DemoClass()
    {
        string Variable = "Hello planet earth!";
        Console.WriteLine($"Constructor: {Variable}");
    }

    public void Method1()
    {
        string Variable = "Hello world!";
        int year = 2023;
        Console.WriteLine($"Method1: {Variable} - {year}");
    }

    public void Method2()
    {
        string Variable = "Hello universe!";
        Console.WriteLine($"Method2: {Variable}");
        Console.WriteLine($"Method2 class level: {this.Variable}");
    }
}
