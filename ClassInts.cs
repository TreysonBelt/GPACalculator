namespace GPACalculator;
public class ClassInts
{
    public int credits {get; set; }
    public double classNum {get; set; }
    public ClassInts(int classCredits, string grade)
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
}