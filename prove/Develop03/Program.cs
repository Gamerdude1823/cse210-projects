using System;
using System.Collections.Generic;

public class Scripture
{
    private string reference;
    private string text;
    private List<Word> words;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.text = text;
        words = new List<Word>();

        // Split the text into words
        string[] wordArray = text.Split(' ');

        // Create Word objects for each word in the scripture
        foreach (string word in wordArray)
        {
            words.Add(new Word(word));
        }
    }

    public string GetReference()
    {
        return reference;
    }

    public string GetText()
    {
        return text;
    }

    public bool IsAllHidden()
    {
        foreach (Word word in words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

    public void HideRandomWord()
    {
        Random random = new Random();
        int index = random.Next(words.Count);

        // If the word is already hidden, select another random word
        while (words[index].IsHidden())
        {
            index = random.Next(words.Count);
        }

        words[index].Hide();
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine($"{reference}:");
        foreach (Word word in words)
        {
            if (word.IsHidden())
            {
                Console.Write("___ ");
            }
            else
            {
                Console.Write($"{word.GetText()} ");
            }
        }
        Console.WriteLine();
    }
}

public class Reference
{
    private string reference;

    public Reference(string reference)
    {
        this.reference = reference;
    }

    public string GetReference()
    {
        return reference;
    }
}

public class Word
{
    private string text;
    private bool hidden;

    public Word(string text)
    {
        this.text = text;
        hidden = false;
    }

    public string GetText()
    {
        return text;
    }

    public bool IsHidden()
    {
        return hidden;
    }

    public void Hide()
    {
        hidden = true;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        // Create a new Scripture object
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world, that he gave his only Son");

        // Prompt the user until all words are hidden
        while (!scripture.IsAllHidden())
        {
            scripture.Display();
            Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine();
            
            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWord();
        }
    }
}