﻿using System;
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
                //base case
                if (string.IsNullOrEmpty(Sentences)) return false;
                string[] sentences = base.Sentences.Split('.');
                DatasetSentence = new List<Sentence>();
                foreach (string sentence in sentences)
                {
                    _sentence = new Sentence(sentence.Trim());
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
                if (string.IsNullOrEmpty(Questions)) return false;
                string[] questions = base.Questions.Split(',');
                DatasetQuestion = new List<Question>();
                foreach (string question in questions)
                {
                    _question = new Question(question.Trim());
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
                if (string.IsNullOrEmpty(Answers)) return false;
                string[] answers = base.Answers.Split(';');
                DatasetAnswer = new List<Answer>();
                foreach (string answer in answers)
                {
                    _answer = new Answer(answer.Trim());
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
                Result = new Dictionary<string, Answer>();
                List<Answer> answerList = new List<Answer>(DatasetAnswer);
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
                    Result.Add(question.Data, answer);
                    Console.WriteLine(answer.Data);
                    answerList.Remove(answer);
                    
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
