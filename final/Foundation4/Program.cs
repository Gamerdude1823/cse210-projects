using System;

public class Activity
{
    public string ActivityType { get; private set; }
    public int DurationMinutes { get; private set; }

    public Activity(string activityType, int durationMinutes)
    {
        ActivityType = activityType;
        DurationMinutes = durationMinutes;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public string GetSummary()
    {
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        string summary = $"Activity Type: {ActivityType}\n";
        summary += $"Duration (minutes): {DurationMinutes}\n";
        summary += $"Distance (km): {distance:F2}\n";
        summary += $"Distance (miles): {(distance * 0.62):F2}\n";
        summary += $"Speed (kph): {speed:F2}\n";
        summary += $"Speed (mph): {(speed * 0.62):F2}\n";
        summary += $"Pace (min/km): {pace:F2}\n";
        summary += $"Pace (min/mile): {(pace / 0.62):F2}\n";

        return summary;
    }
}

public class Running : Activity
{
    public double DistanceKm { get; private set; }

    public Running(int durationMinutes, double distanceKm) : base("Running", durationMinutes)
    {
        DistanceKm = distanceKm;
    }

    public override double GetDistance()
    {
        return DistanceKm;
    }

    public override double GetSpeed()
    {
        return (DistanceKm / DurationMinutes) * 60;
    }

    public override double GetPace()
    {
        return DurationMinutes / DistanceKm;
    }
}

public class Cycling : Activity
{
    public double DistanceKm { get; private set; }

    public Cycling(int durationMinutes, double distanceKm) : base("Cycling", durationMinutes)
    {
        DistanceKm = distanceKm;
    }

    public override double GetDistance()
    {
        return DistanceKm;
    }

    public override double GetSpeed()
    {
        return (DistanceKm / DurationMinutes) * 60;
    }

    public override double GetPace()
    {
        return DurationMinutes / DistanceKm;
    }
}

public class Swimming : Activity
{
    public int Laps { get; private set; }

    public Swimming(int durationMinutes, int laps) : base("Swimming", durationMinutes)
    {
        Laps = laps;
    }

    public override double GetDistance()
    {
        return Laps * 50 / 1000.0;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / DurationMinutes) * 60;
    }

    public override double GetPace()
    {
        return DurationMinutes / GetDistance();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Activity[] activities = {
            new Running(durationMinutes: 30, distanceKm: 5),
            new Cycling(durationMinutes: 45, distanceKm: 15),
            new Swimming(durationMinutes: 40, laps: 30)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine("--------------------");
        }
    }
}