using System;

namespace On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinutes = int.Parse(Console.ReadLine());

            int examAllMinutes = (examHour * 60) + examMinutes;
            int arrivalAllMinutes = (arrivalHour * 60) + arrivalMinutes;
            int minutesLate = 0;
            int hourLate = 0;
            int minutesBefore = 0;
            int hourBefore = 0;

            if (examAllMinutes < arrivalAllMinutes)
            {
                Console.WriteLine("Late");
                minutesLate = arrivalAllMinutes - examAllMinutes;
                if (minutesLate >=60)
                {
                    hourLate = minutesLate / 60;
                    minutesLate = minutesLate % 60;
                    Console.WriteLine($"{hourLate}:{minutesLate:d2} hours after the start");
                }
                else
                {
                    Console.WriteLine($"{minutesLate} minutes after the start");
                }
            }
            else if (examAllMinutes == arrivalAllMinutes || ((examAllMinutes - arrivalAllMinutes) <= 30 && (examAllMinutes - arrivalAllMinutes) > 0))
            {
                Console.WriteLine("On time");
                if (examAllMinutes != arrivalAllMinutes)
                {
                    minutesBefore = examAllMinutes - arrivalAllMinutes;
                    Console.WriteLine($"{minutesBefore} minutes before the start");
                }
            }
            else
            {
                Console.WriteLine("Early");
                minutesBefore = examAllMinutes - arrivalAllMinutes;
                if (minutesBefore >=60)
                {
                    hourBefore = minutesBefore / 60;
                    minutesBefore = minutesBefore % 60;
                    Console.WriteLine($"{hourBefore}:{minutesBefore:d2} hours before the start");
                }
                else
                {
                    Console.WriteLine($"{minutesBefore} minutes before the start");
                }
            }
        }
    }
}
