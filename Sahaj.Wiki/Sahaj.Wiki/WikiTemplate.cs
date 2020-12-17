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
