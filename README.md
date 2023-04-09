# Variable scopes in C#

Nowadays, this topic is confused with the lifecycle of the container of dependency injection because one of the lifecycles of the container is called "scope". But it's not the same thing, it is a concept that is related to the variables.

In C#, you have three types of scopes for variables:
* Class level
* Method level
* Block level



## Class level
A variable has class level when it is declared outside of any method or constructor.

* A variable declared with class level can be accessed inside a method or constructor;
* Non-static variables declared with class level only can be accessed by non-static methods or constructors inside the same class;
* Variables declared with class level can be accessed outside of the class depending on the access level. For example, public, internal, etc.

**Example:**
```csharp
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
```

**Output:**
```bash
Constructor: Hello World!
Method: Hello World!
Outside: Hello World!
```



## Method level

Variables declared inside a method or constructor have method level.

* Variables with scope method level also called local variables;
* Variables declared with method level can be accessed inside the same method or constructor. Outside the method or constructor will not be accessible;
* We can declare a variable with the same name as a class level inside a method or constructor and will be an independent variable. In this case we can use the keyword `this` to access the class level variable. For example: `this.Variable`;

**Example:**
```csharp
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
```

**Output:**
```bash
Constructor: Hello planet earth!
Method1: Hello world! - 2023
Method2: Hello universe!
Method2 class level: Hello galaxy!
```



## Block level

The previous two scopes I believe are easy to understand and that is not strange for anyone. In this last scope, everyone uses it, but few are aware of its real existence.

But what really is a block level? A block is a group of statements between braces `{}`. For example, the body of a `loop`, `if statement`, `try..catch`, `using`, etc. Or when we use only `{}`.

**Example:**
```csharp
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
```

**Output:**
```bash
Hello class!
Hello block!
Hello 0!
Hello 1!
Hello try!
Hello finally!
```

Who has never declared a variable outside the `try..catch` to be able to access it after executing it? Yeah, the reason for that is the block scope.

```csharp
string variable = null;
try
{
    variable = "Hello try!";
    // ...
}
catch (Exception)
{
    // ...
}
Console.WriteLine(variable);
```

One thing few people know is that we don't need to have a statement like a `loop` or `condition` to have a defined block. We can use only `{}`.

**Example:**
```csharp
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
```

**Output:**
```bash
L0 Hello level0!
L1.1 Hello level1!
L1.1 Hello level0!
L2 Hello level2!
L2 Hello level1!
L2 Hello level0!
L3 Hello level3!
L3 Hello level2!
L3 Hello level1!
L3 Hello level0!
L1.2 Hello level1.2!
L1.2 Hello level0!
```

To finalize, let's go to understand the allowed accesses of the block levels.
![Wrong block level](/media/wrong-block-level.png "Wrong block level")

> The previous code does not compile. It is only for we understand this examaple.

The nested blocks can access the variables of the upper blocks, but the upper blocks cannot access the variables of the nested blocks.
