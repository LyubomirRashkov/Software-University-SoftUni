using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shedule = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "course start")
                {
                    break;
                }

                string[] parts = line
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);

                string lesson = parts[1];
                string exercise = lesson + "-Exercise";

                if (parts[0] == "Add")
                {
                    if (!shedule.Contains(lesson))
                    {
                        shedule.Add(lesson);
                    }
                }
                else if (parts[0] == "Insert")
                {
                    int index = int.Parse(parts[2]);

                    if (!shedule.Contains(lesson))
                    {
                        shedule.Insert(index, lesson);
                    }
                }
                else if (parts[0] == "Remove")
                {
                    shedule.Remove(lesson);
                    shedule.Remove(exercise);
                }
                else if (parts[0] == "Swap")
                {
                    string otherLesson = parts[2];
                    string exerciseOfOtherLesson = otherLesson + "-Exercise";

                    if (shedule.Contains(lesson) && shedule.Contains(otherLesson))
                    {
                        int indexOfLesson = shedule.IndexOf(lesson);
                        int indexOfOtherLesson = shedule.IndexOf(otherLesson);

                        string lessonToDelete = shedule[indexOfLesson];

                        shedule.RemoveAt(indexOfLesson);                       
                        shedule.Insert(indexOfLesson, otherLesson);
                        shedule.RemoveAt(indexOfOtherLesson);
                        shedule.Insert(indexOfOtherLesson, lessonToDelete);

                        if (shedule.Contains(exercise) && shedule.Contains(exerciseOfOtherLesson))
                        {
                            int indexOfExercise = shedule.IndexOf(exercise);
                            int indexOfExerciseOfOtherLesson = shedule.IndexOf(exerciseOfOtherLesson);

                            string exerciseToDelete = shedule[indexOfExercise];

                            shedule.RemoveAt(indexOfExercise);
                            shedule.Insert(indexOfExercise, exerciseOfOtherLesson);
                            shedule.RemoveAt(indexOfExerciseOfOtherLesson);
                            shedule.Insert(indexOfExerciseOfOtherLesson, exerciseToDelete);
                        }
                        else if (shedule.Contains(exercise))
                        {
                            int indexOfExercise = shedule.IndexOf(exercise);
                            int newIndexOfLesson = shedule.IndexOf(lesson);
                            shedule.Insert(newIndexOfLesson + 1, exercise);
                            shedule.RemoveAt(indexOfExercise);

                        }
                        else if (shedule.Contains(exerciseOfOtherLesson))
                        {
                            int indexOfExerciseOfOtherLesson = shedule.IndexOf(exerciseOfOtherLesson);
                            int newIndexOfOtherLesson = shedule.IndexOf(otherLesson);
                            shedule.Insert(newIndexOfOtherLesson + 1, exerciseOfOtherLesson);
                            shedule.RemoveAt(indexOfExerciseOfOtherLesson + 1);
                        }
                    }
                }
                else
                {
                    if (!shedule.Contains(lesson))
                    {
                        shedule.Add(lesson);
                        shedule.Add(exercise);
                    }
                    else
                    {
                        if (!shedule.Contains(exercise))
                        {
                            int indexOfLesson = shedule.IndexOf(lesson);

                            shedule.Insert(indexOfLesson + 1, exercise);
                        }
                    }
                }
            }

            for (int i = 0; i < shedule.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{shedule[i]}");
            }
        }
    }
}
