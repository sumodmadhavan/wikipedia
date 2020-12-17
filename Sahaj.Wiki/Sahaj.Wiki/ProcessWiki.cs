using System;
using System.Collections.Generic;
namespace Sahaj.Wiki
{
    class ProcessWiki : WikiTemplate
    {
        private Sentence _sentence;
        private Question _question;
        private Answer _answer;
        public override void ExtractSentences()
        {
            string[] sentences = base.Sentences.Split('.');
            DatasetSentence = new List<Sentence>();
            foreach (string sentence in sentences)
            {
                _sentence = new Sentence(sentence);
                DatasetSentence.Add(_sentence);
            }
        }
        public override void ExtractQuestions()
        {
            string[] questions = base.Questions.Split(',');
            DatasetQuestion = new List<Question>();
            foreach (string question in questions)
            {
                _question = new Question(question);
                DatasetQuestion.Add(_question);
            }
        }
        public override void ExtractAnswers()
        {
            string[] answers = base.Answers.Split(';');
            DatasetAnswer = new List<Answer>();
            foreach (string answer in answers)
            {
                _answer = new Answer(answer);
                DatasetAnswer.Add(_answer);
            }
        }
        public override void Clean()
        {

        }
        public override void ApplyAlgorithm()
        {

        }
        
    }
}
