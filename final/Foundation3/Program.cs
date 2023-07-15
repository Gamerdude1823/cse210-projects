using System;

class Address
{
    private string street;
    private string city;
    private string state;

    public Address(string street, string city, string state)
    {
        this.street = street;
        this.city = city;
        this.state = state;
    }

    public string GetAddress()
    {
        return $"{street}, {city}, {state}";
    }
}


class Event
{
    private string name;
    private DateTime date;
    private Address address;

    public Event(string name, DateTime date, Address address)
    {
        this.name = name;
        this.date = date;
        this.address = address;
    }

    public virtual string GetEventMessage()
    {
        return $"Join us for the {name} event on {date.ToShortDateString()} at {address.GetAddress()}!";
    }
}


class ConcertEvent : Event
{
    private string artist;

    public ConcertEvent(string name, DateTime date, Address address, string artist)
        : base(name, date, address)
    {
        this.artist = artist;
    }

    public override string GetEventMessage()
    {
        return $"{base.GetEventMessage()} Featuring {artist}!";
    }
}

class ConferenceEvent : Event
{
    private string topic;

    public ConferenceEvent(string name, DateTime date, Address address, string topic)
        : base(name, date, address)
    {
        this.topic = topic;
    }

    public override string GetEventMessage()
    {
        return $"{base.GetEventMessage()} Topic: {topic}";
    }
}

class SportsEvent : Event
{
    private string sport;

    public SportsEvent(string name, DateTime date, Address address, string sport)
        : base(name, date, address)
    {
        this.sport = sport;
    }

    public override string GetEventMessage()
    {
        return $"{base.GetEventMessage()} Sport: {sport}";
    }
}

class Program
{
    static void Main(string[] args)
    {
       
        Address address1 = new Address("123 Main St", "Cityville", "State1");
        ConcertEvent concertEvent = new ConcertEvent("Music Fest", DateTime.Now.AddDays(30), address1, "Artist1");

        Address address2 = new Address("456 Park Ave", "Townville", "State2");
        ConferenceEvent conferenceEvent = new ConferenceEvent("Tech Summit", DateTime.Now.AddDays(60), address2, "Technology");

        Address address3 = new Address("789 Stadium Rd", "Villageville", "State3");
        SportsEvent sportsEvent = new SportsEvent("Football Match", DateTime.Now.AddDays(90), address3, "Football");

    
        Console.WriteLine(concertEvent.GetEventMessage());
        Console.WriteLine(conferenceEvent.GetEventMessage());
        Console.WriteLine(sportsEvent.GetEventMessage());
    }
}