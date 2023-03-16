// See https://aka.ms/new-console-template for more information

using System.Drawing;

Calculator my_calculator = new Calculator();
bool result = my_calculator.IsDifferenceEven(2006949, 114847);
Console.WriteLine(result);

public class Calculator
{
    public bool IsDifferenceEven(int Numbera, int Numberb)
    {
        int NewNumber = (Numbera - Numberb);
        bool NAB = IsEven(NewNumber);
        return NAB;
    }


    public bool IsEven(int Number)
    {
        double NewNumber = Number / 2.0;
        double remainder = NewNumber % 1;
        if (remainder == 0)
        {
            return true;
        }

        return false;

    }




    public Point GetUpPoint(Point currentPoint)
    {
        int X = currentPoint.X;
        int Y = currentPoint.Y;
        Y = Y - 1;
        if (Y == -1)
        {
            Y = 99;
        }
        Point newpoint = new Point(X, Y);
        return newpoint;
    }
}



