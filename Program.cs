namespace GPACalculator;
public class Program
{
    public static void Main()
    {
        bool end = true;
        List<ClassInts> list = new List<ClassInts>();
        while (end)
        {
            System.Console.Write($"Please insert grade letter:");
            string? input = Console.ReadLine();
            if (input == "e")
            {
                end = false;
            }
            else
            {
                System.Console.Write($"Please insert number of credits for the {list.Count + 1} class:");
                int credits = int.Parse(Console.ReadLine());
                list.Add(new ClassInts(credits, input));
            }
        }
        new Calculator(list).Run();
        
    }
}