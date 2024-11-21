namespace MainProject;

public class MyClass
{
    private readonly string greeting;

    public MyClass(string greeting)
    {
        this.greeting = greeting;
    }

    public MyClass() : this("Default greeting!") { }

    public string GetGreeting(int arg)
    {
        return PrivateMethod(arg);
    }

    public string GetGreeting(int arg1, int arg2)
    {
        return PrivateMethod(arg1, arg2);
    }

    private string PrivateMethod(int arg)
    {
        return $"{this.greeting} Argument is {arg}";
    }

    private string PrivateMethod(int arg1, int arg2)
    {
        return $"{this.greeting} Argument #1 is {arg1}, argument #2 is {arg2}";
    }
}
