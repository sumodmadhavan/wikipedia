using System;

namespace Sahaj.Wiki
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //Console.WriteLine("Input Sentence");
            //string[] sentences = Console.ReadLine().Split('.');
            //Console.WriteLine("Input 5 Questions");
            //string[] questions = new string[5];
            //for (int i = 0; i < 5; ++i)
            //    questions[i] = Console.ReadLine();
            //Console.WriteLine("Input ; seperated Answers");
            string[] answers = Console.ReadLine().Split(';');
            //ParagraphMatching paragraphMatching = new ParagraphMatching();
            //_ = paragraphMatching.AnalyzeText(sentences, questions, answers);

            ParagraphMatcher paragraphMatcher = new ParagraphMatcher(new ProcessWiki());


        }
    }
}
