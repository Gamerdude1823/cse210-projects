using System;
using System.Threading;

abstract class Activity
{
    protected string name;
    protected string description;
    protected int duration;

    public void Start()
    {
        Console.WriteLine($"Starting {name} activity...");
        Console.WriteLine(description);
        SetDuration();
        Console.WriteLine("Prepare to begin...");
        Pause(3);
        RunActivity();
        Finish();
    }

    protected void SetDuration()
    {
        Console.Write("Enter the duration in seconds: ");
        duration = int.Parse(Console.ReadLine());
    }

    protected void Pause(int seconds)
    {
        for (int i = seconds; i >= 0; i--)
        {
            Console.Write($"\rPausing... {i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected abstract void RunActivity();

    protected void Finish()
    {
        Console.WriteLine("Good job!");
        Console.WriteLine($"You have completed the {name} activity for {duration} seconds.");
        Pause(3);
        Console.WriteLine("Activity finished.");
    }
}

class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        name = "Breathing";
        description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    protected override void RunActivity()
    {
        int count = 0;
        while (count < duration)
        {
            Console.WriteLine("Breathe in...");
            Pause(3);
            Console.WriteLine("Breathe out...");
            Pause(3);
            count += 6;
        }
    }
}

class ReflectionActivity : Activity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
    {
        name = "Reflection";
        description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    protected override void RunActivity()
    {
        int count = 0;
        Random random = new Random();

        while (count < duration)
        {
            string prompt = prompts[random.Next(prompts.Length)];
            Console.WriteLine(prompt);
            Pause(3);

            foreach (string question in questions)
            {
                Console.WriteLine(question);
                Pause(3);
            }

            count += (3 * (questions.Length + 1));
        }
    }
}

class ListingActivity : Activity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        name = "Listing";
        description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    protected override void RunActivity()
    {
        int count = 0;
        Random random = new Random();

        while (count < duration)
        {
            string prompt = prompts[random.Next(prompts.Length)];
            Console.WriteLine(prompt);
            Pause(3);

            Console.WriteLine("Think about the prompt and list as many items as you can:");

            DateTime endTime = DateTime.Now.AddSeconds(duration - count);
            int itemsCount = 0;
            while (DateTime.Now < endTime)
            {
                string item = Console.ReadLine();
                itemsCount++;
            }

            Console.WriteLine($"You listed {itemsCount} items.");
            count += itemsCount;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());

            Activity activity;

            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity();
                    break;
                case 2:
                    activity = new ReflectionActivity();
                    break;
                case 3:
                    activity = new ListingActivity();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }

            Console.WriteLine();
            activity.Start();
            Console.WriteLine();
        }
    }
}