using System;

namespace MyTime
{
    class MyTime
    {
        private int hour, minute, second;
        public MyTime(int hour_, int minute_, int second_)
        {
            hour = hour_;
            minute = minute_;
            second = second_;
        }

        public override string ToString()
        {
            return string.Format(hour + ":" + minute.ToString("00") + ":" + second.ToString("00"));
        }

        public void TimeFormat()
        {
            int t = TimeSinceMidnight();
            int secPerDay = 60 * 60 * 24;
            t = ((t % secPerDay) + secPerDay) % secPerDay;
            hour = t / 3600;
            minute = (t / 60) % 60;
            second = t % 60;
        }

        public int TimeSinceMidnight()
        {
            return hour * 3600 + minute * 60 + second;
        }

        public MyTime TimeSinceMidnight(int t)
        {
            hour = t / 3600;
            minute = (t / 60) % 60;
            second = t % 60;
            TimeFormat();
            return new MyTime(hour, minute, second);
        }


        public MyTime AddOneSecond()
        {
            second++;
            TimeFormat();
            return new MyTime(hour, minute, second);
        }
        public MyTime AddOneMinute()
        {
            minute++;
            TimeFormat();
            return new MyTime(hour, minute, second);
        }
        public MyTime AddOneHour()
        {
            hour++;
            TimeFormat();
            return new MyTime(hour, minute, second);
        }

        public MyTime AddSeconds(int t)
        {
            second += t;
            int timeInSeconds = hour * 3600 + minute * 60 + second;
            return TimeSinceMidnight(timeInSeconds);
        }

        public int Difference(MyTime mt1)
        {
            return (TimeSinceMidnight() - mt1.TimeSinceMidnight());
        }

        public string WhatLesson()
        {
            int firstLesson = new MyTime(8, 0, 0).TimeSinceMidnight();
            int lastLesson = new MyTime(17, 40, 0).TimeSinceMidnight();
            int break_ = new MyTime(0, 20, 0).TimeSinceMidnight();
            int lessonInSecond = new MyTime(0, 80, 0).TimeSinceMidnight();
            int setTime = TimeSinceMidnight();
            int lesson = 0;
            if (hour < 8)
            {
                return "пари ще не почалися";
            }
            else
            {
                for (int i = firstLesson; i < lastLesson; i += lessonInSecond + break_)
                {
                    lesson++;
                    if ((setTime > i + lessonInSecond && setTime < i + lessonInSecond + break_) && setTime <= lastLesson)
                    {
                        return "перерва мiж " + lesson + "-ю та " + (lesson + 1) + "-ю парами";
                    }
                    else if (setTime >= i && setTime <= i + lessonInSecond)
                    {
                        return lesson + "-а пара";
                    }
                }
                return "пари вже скiнчилися";
            }
        }
    }
}
