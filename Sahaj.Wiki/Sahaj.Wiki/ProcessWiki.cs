using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Sahaj.Wiki
{
    public class ProcessWiki : WikiTemplate
    {
        private Sentence _sentence;
        private Question _question;
        private Answer _answer;

        
        public override bool ExtractSentences()
        {
            try
            {
                string[] sentences = base.Sentences.Split('.');
                DatasetSentence = new List<Sentence>();
                foreach (string sentence in sentences)
                {
                    _sentence = new Sentence(sentence);
                    DatasetSentence.Add(_sentence);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public override bool ExtractQuestions()
        {
            try
            {
                string[] questions = base.Questions.Split(',');
                DatasetQuestion = new List<Question>();
                foreach (string question in questions)
                {
                    _question = new Question(question);
                    DatasetQuestion.Add(_question);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public override bool ExtractAnswers()
        {
            try
            {
                string[] answers = base.Answers.Split(';');
                DatasetAnswer = new List<Answer>();
                foreach (string answer in answers)
                {
                    _answer = new Answer(answer);
                    DatasetAnswer.Add(_answer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public override void Clean()
        {
            if (DatasetSentence.Count>0)
            {
                DatasetSentence = null;
            }
            if (DatasetQuestion.Count > 0)
            {
                DatasetQuestion = null;
            }
            if (DatasetAnswer.Count > 0)
            {
                DatasetAnswer = null;
            }
        }
        public override bool ApplyAlgorithm()
        {
            try
            {
                Result = new SortedList<int, Answer>();
                List<Answer> answerList = new List<Answer>(DatasetAnswer);
                int initalIndex = 1;
                foreach (Question question in DatasetQuestion)
                {

                    var totalWords = Regex.Matches(question.Data, pattern)
                                     .Cast<Match>()
                                     .Select(i => i.Value.ToLower())
                                     .Where(s => !wordstoIgnore.Any(i => i.Equals(s)));

                    int max = 0;
                    Answer answer = null;
                    for (int i = 0; i < DatasetSentence.Count; ++i)
                    {
                        var sentence = DatasetSentence[i].Data.ToLower();
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
                            foreach (Answer eachAnswer in DatasetAnswer)
                            {
                                if (sentence.Contains(eachAnswer.Data.ToLower()))
                                {
                                    answer = eachAnswer;
                                    max = score;
                                    break;
                                }
                            }
                        }
                    }
                    answer.Data = answer.Data.Trim();
                    Result.Add(initalIndex, answer);
                    Console.WriteLine(answer.Data);
                    answerList.Remove(answer);
                    initalIndex++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
    }
}
