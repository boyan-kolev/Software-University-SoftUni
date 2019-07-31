using System;
using System.Collections.Generic;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = new List<string>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries));

            while (true)
            {
                string[] commands = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "course start")
                {
                    break;
                }

                if (commands[0] == "Add")
                {
                    if (lessons.Contains(commands[1]) == false)
                    {
                        lessons.Add(commands[1]);
                    }
                }
                else if (commands[0] == "Insert")
                {
                    int index = int.Parse(commands[2]);
                    bool isValid = index >= 0 && index < lessons.Count;
                    if ((lessons.Contains(commands[1]) == false) && (isValid))
                    {
                        string title = commands[1];
                        lessons.Insert(index, title);
                    }
                }
                else if (commands[0] == "Remove")
                {
                    if (lessons.Contains(commands[1]))
                    {
                        lessons.Remove(commands[1]);
                        if (lessons.Contains($"{commands[1]}-Exercise"))
                        {
                            lessons.Remove($"{commands[1]}-Exercise");
                        }

                    }
                }
                else if (commands[0] == "Swap")
                {
                    string lessons1 = commands[1];
                    string lessons2 = commands[2];

                    if (lessons.Contains(lessons1) && lessons.Contains(lessons2))
                    {
                        int index1 = lessons.FindIndex(a => a == lessons1);
                        int index2 = lessons.FindIndex(a => a == lessons2);

                        string temp = lessons[index1];
                        lessons[index1] = lessons[index2];
                        lessons[index2] = temp;

                        if (lessons.Contains($"{lessons1}-Exercise"))
                        {
                            lessons.Remove($"{lessons1}-Exercise");
                            int index3 = lessons.FindIndex(a => a == lessons1);
                            lessons.Insert(index3 + 1, $"{lessons1}-Exercise");
                        }

                        if (lessons.Contains($"{lessons2}-Exercise"))
                        {
                            lessons.Remove($"{lessons2}-Exercise");
                            int index4 = lessons.FindIndex(a => a == lessons2);
                            lessons.Insert(index4 + 1, $"{lessons2}-Exercise");
                        }
                    }
                }
                else if (commands[0] == "Exercise")
                {
                    if (lessons.Contains(commands[1]) && (lessons.Contains($"{commands[1]}-Exercise") == false))
                    {
                        int index = lessons.FindIndex(a => a == commands[1]);
                        lessons.Insert(index + 1, $"{commands[1]}-Exercise");
                    }

                    if (lessons.Contains(commands[1]) == false)
                    {
                        lessons.Add(commands[1]);
                        lessons.Add($"{commands[1]}-Exercise");
                    }

                }

            }


            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lessons[i]}");
            }
        }
    }
}
