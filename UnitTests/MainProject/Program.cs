namespace MainProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var class1 = new MyClass();
            Console.WriteLine(class1.GetGreeting(110));
            Console.WriteLine(class1.GetGreeting(120, 121));

            var class2 = new MyClass("Custom Class!");
            Console.WriteLine(class2.GetGreeting(210));
            Console.WriteLine(class2.GetGreeting(220, 221));

            var structure1 = new MyStructure();
            Console.WriteLine(structure1.GetGreeting(310));
            Console.WriteLine(structure1.GetGreeting(320, 321));


            var structure2 = new MyStructure("Custom Strucure!");
            Console.WriteLine(structure1.GetGreeting(410));
            Console.WriteLine(structure1.GetGreeting(420, 421));
        }
    }
}
