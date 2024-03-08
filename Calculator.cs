namespace GPACalculator;
public class Calculator
{
    public List<double> classNumbersList = new List<double>();
    public string filePath = "gradeInts.cvs";
    public double[] gradeInts;
    public Calculator(List<ClassInts> classIntsList)
    {
        string[] savedGradeInts = File.ReadAllLines(filePath);
        foreach (string item in savedGradeInts)
        {
            string[] toString = item.Split(",");
        }
        double[] intSavedGradeInts = savedGradeInts.Select(double.Parse).ToArray();
        int[]
        gradeInts = intSavedGradeInts.Concat(ints).ToArray();
    }
    public void StartNewCalculation()
    {
        File.WriteAllText(filePath, "0,");
    }
    public void SaveGradeInts()
    {
        List<string> saveList = new List<string>();
        foreach (var item in gradeInts)
        {
            saveList.Add($"{item},");
        }
        File.WriteAllLines(filePath, saveList);
    }
    public void CalculateGPA()
    {
        double num = 0;
        foreach (double item in gradeInts)
        {
            num = num + item;
        }
        num = num / gradeInts.Length;
        System.Console.WriteLine($"Your GPA is {num}");
    }
}