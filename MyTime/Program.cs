using System;

namespace MyTime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hour = ");
            int h = int.Parse(Console.ReadLine());
            Console.Write("Minute = ");
            int m = int.Parse(Console.ReadLine());
            Console.Write("Second = ");
            int s = int.Parse(Console.ReadLine());
            MyTime myTime = new MyTime(h, m, s);
            myTime.TimeFormat();
            Console.WriteLine("Time - " + myTime);
            int t = myTime.TimeSinceMidnight();
            Console.WriteLine("Seconds after midnight - " + t);
            Console.WriteLine("Mytime format - " + myTime.TimeSinceMidnight(t));
            myTime.AddOneSecond();
            Console.WriteLine("Add one second - " + myTime);
            myTime.AddOneMinute();
            Console.WriteLine("Add one minute - " + myTime);
            myTime.AddOneHour();
            Console.WriteLine("Add one hour - " + myTime);
            Console.Write("Enter seconds = ");
            int addSeconds = int.Parse(Console.ReadLine());
            Console.WriteLine("Added seconds - " + myTime.AddSeconds(addSeconds));
            Random rand = new Random();
            MyTime newTime = new MyTime(rand.Next(0, 24), rand.Next(0, 60), rand.Next(0, 60));
            Console.WriteLine("Difference between " + myTime + " and " + newTime + " is " + myTime.Difference(newTime) + " sec");
            Console.WriteLine(myTime.WhatLesson());
            Console.ReadKey();
        }
    }
}
