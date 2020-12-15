using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Sahaj.Wiki
{
    class Program
    {
        static readonly string[] wordstoIgnore = { "whose", "which", "why" };
        static void Main(string[] args)
        {
            string[] sentences = Console.ReadLine().Split('.');
            string[] questions = new string[5];
            for (int i = 0; i < 5; ++i)
                questions[i] = Console.ReadLine();

            string[] answers = Console.ReadLine().Split(';');

            ParagraphMatching(sentences, questions, answers);
        }
        //brute force implementation.
        //ref : https://en.wikipedia.org/wiki/Hungarian_algorithm
        //TODO: read and give assignments
        //Time O(n2) Space O(n2)
        static void ParagraphMatching(string[] sentences, string[] questions, string[] answers)
        {
            List<string> ans = new List<string>(answers);
            foreach (string eachQuestion in questions)
            {
                var totalWords = Regex.Matches(eachQuestion, "[\\w-]*\\w+|\".+\"")
                                 .Cast<Match>()
                                 .Select(i => i.Value.ToLower())
                                 .Where(s => !wordstoIgnore.Any(i => i.Equals(s)));

                int m = 0;
                string answer = "";
                for (int i = 0; i < sentences.Length; ++i)
                {
                    var sentence = sentences[i].ToLower();
                    int score = 0;
                    foreach (var word in totalWords)
                    {
                        if (sentence.IndexOf(word) >= 0)
                        {
                            score += word.Length;
                        }
                        // if plurals
                        else if (sentence.IndexOf(word.TrimEnd('s')) >= 0)
                        {
                            score += word.Length;
                        }
                    }
                    if (score > m)
                    {
                        foreach (var a in ans)
                        {
                            if (sentence.Contains(a.ToLower()))
                            {
                                answer = a;
                                m = score;
                                break;
                            }
                        }
                    }
                }
                Console.WriteLine(answer);
                ans.Remove(answer);
            }
        }
    }
}
