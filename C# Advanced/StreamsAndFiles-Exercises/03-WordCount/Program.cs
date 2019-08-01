using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03_WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader streamReaderText = new StreamReader(@"../../../../text.txt"))
            {
                using (StreamReader streamReaderWords = new StreamReader(@"../../../../words.txt"))
                {

                    Dictionary<string, int> words = new Dictionary<string, int>();
                    string word;

                    while ((word = streamReaderWords.ReadLine()) != null)
                    {
                        if (words.ContainsKey(word) == false)
                        {
                            words.Add(word, 0);
                        }
                    }

                    string line;
                    while ((line = streamReaderText.ReadLine()) != null)
                    {
                        string[] wordsInText = Regex.Split(line.ToLower(), @"\W");

                        for (int counterWord = 0; counterWord < wordsInText.Length; counterWord++)
                        {
                            if (words.ContainsKey(wordsInText[counterWord]))
                            {
                                words[wordsInText[counterWord]]++;
                            }
                        }

                    }

                    using (StreamWriter streamWriter = new StreamWriter(@"../../../result.txt"))
                    {
                        foreach (var kvp in words.OrderByDescending(x => x.Value))
                        {
                            streamWriter.WriteLine($"{kvp.Key} - {kvp.Value}");
                        }
                    }


                }
            }
        }
    }
}
