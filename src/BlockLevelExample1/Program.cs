var demoClass = new DemoClass();
demoClass.Method();

class DemoClass
{
    string Variable = "Hello class!";

    public void Method()
    {
        Console.WriteLine(Variable);
        if (true)
        {
            string Variable = "Hello block!";
            Console.WriteLine(Variable);
        }

        for(int i = 0; i < 2; i++)
        {
            string Variable = $"Hello {i}!";
            Console.WriteLine(Variable);
        }

        try
        {
            string Variable = "Hello try!";
            Console.WriteLine(Variable);
        }
        catch (Exception)
        {
            string Variable = "Hello catch!";
            Console.WriteLine(Variable);
        }
        finally
        {
            string Variable = "Hello finally!";
            Console.WriteLine(Variable);
        }
    }
}
