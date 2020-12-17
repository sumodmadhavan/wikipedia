using System;
using System.Collections.Generic;
namespace Sahaj.Wiki
{
    public abstract class WikiTemplate
    {
        //private readonly string[] wordstoIgnore = { "whose", "which", "why" };
        //abstract public string[] WordstoIgnore { get { return wordstoIgnore}; set; }
        
        private readonly string pattern = "[\\w-]*\\w+|\".+\"";
        public virtual string Expression { get { return pattern; } }

        private readonly string[] wordstoIgnore = { "whose", "which", "why" };
        public virtual string[] WordstoIgnore { get { return wordstoIgnore; } }

        public virtual SortedList<int, string> Result { get; set; }
        
        protected List<Sentence> DatasetSentence;
        protected List<Question> DatasetQuestion;
        protected List<Answer> DatasetAnswer;
        protected string Sentences;
        protected string Questions;
        protected string Answers;
        public abstract void ExtractSentences();
        public abstract void ExtractQuestions();
        public abstract void ExtractAnswers();
        public abstract void ApplyAlgorithm();
        public abstract void Clean();
        public void Run()
        {
            ExtractSentences();
            ExtractQuestions();
            ExtractAnswers();
            ApplyAlgorithm();
            Clean();
        }
    }
}
