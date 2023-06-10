using System;

class Program
{
    static void Main(string[] args)
    {
        Display_Welcome();

        string userName = PromptUser_Name();
        int userNum = PromptUser_Num();

        int squaredNum = Square_Num(userNum);

        Display_Result(userName, squaredNum);
    }

    static void Display_Welcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUser_Name()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    static int PromptUser_Num()
    {
        Console.Write("Please enter your favorite number: ");
        int num = int.Parse(Console.ReadLine());

        return num;
    }

    static int Square_Num(int num)
    {
        int square = num * num;
        return square;
    }

    static void Display_Result(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}