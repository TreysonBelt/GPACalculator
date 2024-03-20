namespace GPACalculator;
public class Calculator
{
    public List<double> classNumbersList = new List<double>();
    public string filePath = "gradeInts.cvs";
    private List<ClassInts> classIntsList;
    private bool quit = false;
    private List<ClassInts> exceptions;
    public Calculator(List<ClassInts> classIntsList)
    {
        exceptions = classIntsList;
        this.classIntsList = classIntsList;
        string[] savedGradeInts = File.ReadAllLines(filePath);
        double[] savedGradeIntsDoubled = savedGradeInts
            .SelectMany(s => s.Split(',').Select(str => double.Parse(str.Trim())))
            .ToArray();
        if (savedGradeIntsDoubled.Length % 2 != 0)
        {
            Array.Resize(ref savedGradeIntsDoubled, savedGradeIntsDoubled.Length + 1);
            savedGradeIntsDoubled[savedGradeIntsDoubled.Length - 1] = 0;
        }
        if (savedGradeIntsDoubled.Length % 2 != 0)
        {
            throw new ArgumentException("Invalid input format. The number of values should be even.");
        }
        for (int i = 0; i < savedGradeIntsDoubled.Length; i += 2)
        {
            double credits = savedGradeIntsDoubled[i];
            double classNum = savedGradeIntsDoubled[i + 1];
            this.classIntsList.Add(new ClassInts(credits, classNum));
        }
    }
    public void Run()
    {
        while (!quit) {
            Console.Clear();
            ProcessUserInput();
        }
    }
    private void ProcessUserInput()
    {
        System.Console.Write("What would you like to do: ");
        switch (Console.ReadKey().KeyChar)
        {
            case '1':
                System.Console.WriteLine();
                DisplayCreditsAndGrades();
                break;
            case '2':
                System.Console.WriteLine();
                CalculateGPA();
                break;
            case '3':
                System.Console.WriteLine();
                StartNewCalculation();
                break;
            case '4':
                System.Console.WriteLine();
                SaveGradeInts();
                break;
            case '5':
                System.Console.WriteLine();
                SaveGradeIntsExceptions();
                break;
            case '6':
                System.Console.WriteLine();
                quit = true;
                break;
            default:
                System.Console.WriteLine();
                DisplayHelp();
                break;
        }
    }
    private void StartNewCalculation()
    {
        File.WriteAllText(filePath, "0,0,");
    }
    private void SaveGradeInts()
    {
        List<string> saveList = new List<string>();
        for (int i = 0; i < classIntsList.Count; i++)
        {
            saveList.Add($"{classIntsList[i].credits},{classIntsList[i].classNum},");
        }
        File.WriteAllLines(filePath, saveList);
    }
    private void SaveGradeIntsExceptions()
    {
        List<string> saveList = new List<string>(); 
        for (int i = exceptions.Count; i < classIntsList.Count; i++)
        {
            saveList.Add($"{classIntsList[i].credits},{classIntsList[i].classNum},");
        }
        File.WriteAllLines(filePath, saveList);
    }
    private void CalculateGPA()
    {
        double num = 0;
        double numCredits = 0;
        for (int i = 0; i < classIntsList.Count; i++)
        {
            num = num + (classIntsList[i].classNum * classIntsList[i].credits);
            numCredits = numCredits + classIntsList[i].credits;
        }
        num = num / numCredits;
        System.Console.WriteLine($"Your GPA is {num}");
        Console.Write("Please insert any key to continue... ");
        Console.ReadKey();
    }
    private void DisplayHelp()
    {
        System.Console.Write(@"Insert a number for what you want to do:
1 - Display credits and grades.
2 - Calculate GPA.
3 - Start new calculation.
4 - Save grades.
5 - Save grades but not test cases.
6 - End software.
Please insert any key to continue... ");
        Console.ReadKey();
    }
    private void DisplayCreditsAndGrades()
    {
        System.Console.WriteLine("The credits and grade amounts:");
        for (int i = 0; i < classIntsList.Count; i++)
        {
            System.Console.WriteLine($@"Credit number: {classIntsList[i].credits}. Grade number {classIntsList[i].classNum}.");
        }
        Console.Write("Please insert any key to continue... ");
        Console.ReadKey();
    }
}