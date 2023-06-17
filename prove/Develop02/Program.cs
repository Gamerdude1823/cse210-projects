using System;
using System.Collections.Generic;
using System.IO;

public class Entry
{
    public DateTime Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public Entry(DateTime date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }
}

public interface IJournal
{
    void WriteNewEntry();
    void DisplayJournal();
    void SaveJournal();
    void LoadJournal();
}

public class Journal : IJournal
{
    private List<Entry> entries;

    public Journal()
    {
        entries = new List<Entry>();
    }

    public void WriteNewEntry()
    {
        Console.WriteLine("Choose a prompt to write your journal entry:");
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Random random = new Random();
        int index = random.Next(prompts.Count);
        string prompt = prompts[index];

        Console.WriteLine("Prompt: " + prompt);
        Console.Write("Response: ");
        string response = Console.ReadLine();

        Entry entry = new Entry(DateTime.Now, prompt, response);
        entries.Add(entry);
    }

    public void DisplayJournal()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
            return;
        }

        foreach (Entry entry in entries)
        {
            Console.WriteLine("Date: " + entry.Date.ToString("yyyy-MM-dd HH:mm:ss"));
            Console.WriteLine("Prompt: " + entry.Prompt);
            Console.WriteLine("Response: " + entry.Response);
            Console.WriteLine("--------------------------------------------");
        }
    }

    public void SaveJournal()
    {
        Console.Write("Enter a filename to save the journal: ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in entries)
                {
                    writer.WriteLine(entry.Date.ToString("yyyy-MM-dd HH:mm:ss"));
                    writer.WriteLine(entry.Prompt);
                    writer.WriteLine(entry.Response);
                    writer.WriteLine("--------------------------------------------");
                }
            }

            Console.WriteLine("Journal saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving journal: " + ex.Message);
        }
    }

    public void LoadJournal()
    {
        Console.Write("Enter a filename to load the journal: ");
        string filename = Console.ReadLine();

        try
        {
            List<Entry> loadedEntries = new List<Entry>();

            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string dateStr = reader.ReadLine();
                    string prompt = reader.ReadLine();
                    string response = reader.ReadLine();
                    reader.ReadLine(); // Skip the separator line

                    DateTime date = DateTime.ParseExact(dateStr, "yyyy-MM-dd HH:mm:ss", null);
                    Entry entry = new Entry(date, prompt, response);
                    loadedEntries.Add(entry);
                }
            }

            entries = loadedEntries;
            Console.WriteLine("Journal loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading journal: " + ex.Message);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        IJournal journal = new Journal();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    journal.WriteNewEntry();
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    journal.SaveJournal();
                    break;
                case "4":
                    journal.LoadJournal();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}