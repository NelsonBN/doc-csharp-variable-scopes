var var0 = "Hello level0!";
Console.WriteLine($"L0 {var0}");

{
    var var1 = "Hello level1!";
    Console.WriteLine($"L1.1 {var1}");
    Console.WriteLine($"L1.1 {var0}");

    {
        var var2 = "Hello level2!";
        Console.WriteLine($"L2 {var2}");
        Console.WriteLine($"L2 {var1}");
        Console.WriteLine($"L2 {var0}");

        {
            var var3 = "Hello level3!";
            Console.WriteLine($"L3 {var3}");
            Console.WriteLine($"L3 {var2}");
            Console.WriteLine($"L3 {var1}");
            Console.WriteLine($"L3 {var0}");
        }
    }
}

{
    var var1 = "Hello level1.2!";
    Console.WriteLine($"L1.2 {var1}");
    Console.WriteLine($"L1.2 {var0}");
}