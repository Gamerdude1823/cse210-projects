using System;
using System.Collections.Generic;

public abstract class Goal
{
    public string Name { get; set; }
    public int Value { get; set; }
    public bool IsComplete { get; protected set; }

    public Goal(string name, int value)
    {
        Name = name;
        Value = value;
        IsComplete = false;
    }

    public abstract void RecordEvent();
    public abstract string GetStatus();
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value) : base(name, value)
    {
    }

    public override void RecordEvent()
    {
        IsComplete = true;
    }

    public override string GetStatus()
    {
        return IsComplete ? "[X] Completed" : "[ ] Incomplete";
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, int value) : base(name, value)
    {
    }

    public override void RecordEvent()
    {
        Value += Value; 
    }

    public override string GetStatus()
    {
        return $"Value: {Value}";
    }
}


public class ChecklistGoal : Goal
{
    private int completedCount;
    private int requiredCount;
    private int bonusValue;

    public ChecklistGoal(string name, int value, int requiredCount, int bonusValue) : base(name, value)
    {
        this.requiredCount = requiredCount;
        this.bonusValue = bonusValue;
    }

    public override void RecordEvent()
    {
        completedCount++;
        Value += Value;

        if (completedCount == requiredCount)
        {
            Value += bonusValue;
            IsComplete = true;
        }
    }

    public override string GetStatus()
    {
        return $"Completed: {completedCount}/{requiredCount} times";
    }
}

public class Program
{
    private static List<Goal> goals = new List<Goal>();

    public static void Main()
    {
        LoadGoals();

        while (true)
        {
            Console.WriteLine("===== Eternal Quest =====");
            Console.WriteLine("1. Add Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Show Goals");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddGoal();
                    break;
                case 2:
                    RecordEvent();
                    break;
                case 3:
                    ShowGoals();
                    break;
                case 4:
                    ShowScore();
                    break;
                case 5:
                    SaveGoals(); 
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private static void AddGoal()
    {
        Console.WriteLine("===== Add Goal =====");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter the goal type: ");
        int goalType = int.Parse(Console.ReadLine());

        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter the goal value: ");
        int value = int.Parse(Console.ReadLine());

        switch (goalType)
        {
            case 1:
                goals.Add(new SimpleGoal(name, value));
                break;
            case 2:
                goals.Add(new EternalGoal(name, value));
                break;
            case 3:
                Console.Write("Enter the required count: ");
                int requiredCount = int.Parse(Console.ReadLine());

                Console.Write("Enter the bonus value: ");
                int bonusValue = int.Parse(Console.ReadLine());

                goals.Add(new ChecklistGoal(name, value, requiredCount, bonusValue));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }

        Console.WriteLine("Goal added successfully.");
    }

    private static void RecordEvent()
    {
        Console.WriteLine("===== Record Event =====");
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        Console.WriteLine("Select a goal to record an event:");

        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name}");
        }

        Console.Write("Enter your choice: ");
        int choice = int.Parse(Console.ReadLine());

        if (choice < 1 || choice > goals.Count)
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        Goal selectedGoal = goals[choice - 1];
        selectedGoal.RecordEvent();

        Console.WriteLine("Event recorded successfully.");
    }

    private static void ShowGoals()
    {
        Console.WriteLine("===== Goals =====");
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        for (int i = 0; i < goals.Count; i++)
        {
            Goal goal = goals[i];
            Console.WriteLine($"{i + 1}. {goal.Name} - {goal.GetStatus()}");
        }
    }

    private static void ShowScore()
    {
        Console.WriteLine("===== Score =====");
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        int totalScore = 0;

        foreach (Goal goal in goals)
        {
            totalScore += goal.Value;
        }

        Console.WriteLine($"Total Score: {totalScore}");
    }
    private static void SaveGoals()
    {
        
        Console.WriteLine("Goals saved.");
    }

    private static void LoadGoals()
    {
    
        Console.WriteLine("Goals loaded.");
    }
}    
