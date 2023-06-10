using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> nums = new List<int>();
        int userNum = -1;

        while (userNum != 0)
        {
            Console.Write("Enter a number (0 to quit): ");
            
            string userResponse = Console.ReadLine();
            userNum = int.Parse(userResponse);
            
            if (userNum != 0)
            {
                nums.Add(userNum);
            }            
        }

        int sum = 0;
        foreach (int num  in nums)
        {
            sum += num;
        }
        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / nums.Count;
        Console.WriteLine($"The average is: {average}");

        int max = nums[0];

        foreach (int num  in nums)
        {
            if (num > max)
            {
                max = num;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }
}