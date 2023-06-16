using System;

public class Job
{
    public string jobName;
    public string Company;
    public int Start;
    public int End;

    public void Display()
    {
        Console.WriteLine($"{jobName} ({Company}) {Start}-{End}");
    }
}