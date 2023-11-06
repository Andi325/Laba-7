using System;

public class Calculator<T>
{
    public delegate T BinaryOperation(T a, T b);

    public BinaryOperation Add { get; set; }
    public BinaryOperation Subtract { get; set; }
    public BinaryOperation Multiply { get; set; }
    public BinaryOperation Divide { get; set; }

    public Calculator(BinaryOperation add, BinaryOperation subtract, BinaryOperation multiply, BinaryOperation divide)
    {
        Add = add;
        Subtract = subtract;
        Multiply = multiply;
        Divide = divide;
    }
}

class Program
{
    static void Main()
    {

        Calculator<int> intCalculator = new Calculator<int>(
            (a, b) => a + b,
            (a, b) => a - b,
            (a, b) => a * b,
            (a, b) => a / b
        );

        int result1 = intCalculator.Add(5, 3);
        int result2 = intCalculator.Subtract(8, 3);
        int result3 = intCalculator.Multiply(4, 2); 
        int result4 = intCalculator.Divide(10, 2);

        Console.WriteLine($"Integer calculations: {result1}, {result2}, {result3}, {result4}");
        
        Calculator<double> doubleCalculator = new Calculator<double>(
            (a, b) => a + b,
            (a, b) => a - b,
            (a, b) => a * b,
            (a, b) => a / b
        );

        double result5 = doubleCalculator.Add(2.5, 3.5);
        double result6 = doubleCalculator.Subtract(8.0, 3.5);
        double result7 = doubleCalculator.Multiply(2.5, 2.0); 
        double result8 = doubleCalculator.Divide(10.0, 2.0);   

        Console.WriteLine($"Double calculations: {result5}, {result6}, {result7}, {result8}");
    }
}