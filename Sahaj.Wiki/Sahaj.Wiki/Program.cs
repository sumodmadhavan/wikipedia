﻿using System;

namespace Sahaj.Wiki
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ProcessWiki processWiki = new ProcessWiki();
            Console.WriteLine("Input Sentence");
            processWiki.Sentences = Console.ReadLine();
            Console.WriteLine("Input , Seperated Questions");
            processWiki.Questions = Console.ReadLine();
            Console.WriteLine("Input ; seperated Answers");
            processWiki.Answers = Console.ReadLine();

            ParagraphMatcher paragraphMatcher = new ParagraphMatcher(processWiki);
            var r = paragraphMatcher.Result();


        }
    }
}
