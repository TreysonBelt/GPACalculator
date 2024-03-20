using System.Security.Cryptography.X509Certificates;

namespace GPACalculator;
public class ClassInts
{
    public double credits {get; set; }
    public double classNum {get; set; }
    public ClassInts()
    {
        credits = 0;
        classNum = 0;
    }
    public ClassInts(double classCredits, double num)
    {
        credits = classCredits;
        classNum = num;
    }
    public ClassInts(double classCredits, string? grade)
    {
        credits = classCredits;
        switch (grade)
        {
            case "a":
                classNum = 4;
                break;
            case "a-":
                classNum = 3.7;
                break;
            case "b+":
                classNum = 3.3;
                break;
            case "b":
                classNum = 3;
                break;
            case "b-":
                classNum = 2.7;
                break;
            case "c+":
                classNum = 2.3;
                break;
            case "c":
                classNum = 2;
                break;
            case "c-":
                classNum = 1.7;
                break;
            case "d+":
                classNum = 1.3;
                break;
            case "d":
                classNum = 1;
                break;
            case "d-":
                classNum = 0.7;
                break;
            case "f":
                classNum = 0;
                break;
            default:
                break;
        }
    }
    public ClassInts(int credits, double num)
    {
        this.credits = credits;
        classNum = num;
    }
}