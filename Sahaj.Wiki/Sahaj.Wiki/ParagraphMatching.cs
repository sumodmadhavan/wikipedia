using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Sahaj.Wiki
{
    public class ParagraphMatching
    {
        private readonly string[] wordstoIgnore = { "whose", "which", "why" };
        public ParagraphMatching()
        {
        }
        //brute force implementation. Need improvement on Algo
        //ref : https://en.wikipedia.org/wiki/Hungarian_algorithm
        //TODO: read and give assignments
        //Time O(n2) Space O(n2)
        public SortedList<int,string> AnalyzeText(string[] sentences, string[] questions, string[] answers)
        {
            SortedList<int, string> sortedList = new SortedList<int, string>() ;
            List<string> answerList = new List<string>(answers);
            int initalIndex = 1;
            foreach (string eachQuestion in questions)
            {
                var totalWords = Regex.Matches(eachQuestion, "[\\w-]*\\w+|\".+\"")
                                 .Cast<Match>()
                                 .Select(i => i.Value.ToLower())
                                 .Where(s => !wordstoIgnore.Any(i => i.Equals(s)));

                int max = 0;
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
                    if (score > max)
                    {
                        foreach (var a in answerList)
                        {
                            if (sentence.Contains(a.ToLower()))
                            {
                                answer = a;
                                max = score;
                                break;
                            }
                        }
                    }
                }
                sortedList.Add(initalIndex, answer.Trim());
                Console.WriteLine(answer);
                answerList.Remove(answer);
                initalIndex++;
            }
            return sortedList;
        }
    }
}
