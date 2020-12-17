using System;
using System.Collections.Generic;
namespace Sahaj.Wiki
{
    public abstract class WikiTemplate
    {
        protected string pattern = "[\\w-]*\\w+|\".+\"";
        protected string[] wordstoIgnore = { "whose", "which", "why" };
        public virtual SortedList<int, Answer> Result { get; set; }
        protected List<Sentence> DatasetSentence;
        protected List<Question> DatasetQuestion;
        protected List<Answer> DatasetAnswer;
        public virtual string Sentences { get; set; }
        public virtual string Questions { get; set; }
        public virtual string Answers { get; set; }
        public abstract bool ExtractSentences();
        public abstract bool ExtractQuestions();
        public abstract bool ExtractAnswers();
        public abstract bool ApplyAlgorithm();
        public abstract void Clean();
        public void Run()
        {
            if (ExtractSentences())
            {
                if (ExtractQuestions())
                {
                    if (ExtractAnswers())
                    {
                        ApplyAlgorithm();
                        Clean();
                    }
                }
            }
        }
    }
}
