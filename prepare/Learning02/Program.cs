using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1.jobName = "Warehouse Associate";
        job1.Company = "PetWish Pet Supply Co.";
        job1.Start = 2021;
        job1.End = 2021;

        Job job2 = new Job();
        job2.jobName = "Outdoor Associate";
        job2.Company = "Lowe's Home Improvement";
        job2.Start = 2018;
        job2.End = 2018;

        Job job3 = new Job();
        job3.jobName = "Mechanic's Assistant";
        job3.Company = "Sugar Hill Automotive";
        job3.Start = 2017;
        job3.End = 2017;

        Resume myResume = new Resume();
        myResume.Name = "Zack Williams";

        myResume.jobs.Add(job1);
        myResume.jobs.Add(job2);
        myResume.jobs.Add(job3);

        myResume.Display();
    }
}