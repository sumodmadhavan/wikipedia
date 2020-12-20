using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sahaj.Wiki.Test
{
    [TestClass]
    public class ParagraphMatchTest
    {


        [TestMethod]
        [DataRow
           ("Zebras are several species of African equids (horse family) united by their distinctive black and white stripes." +
           " Their stripes come in different patterns, unique to each individual. " +
           "They are generally social animals that live in small harems to large herds." +
           " Unlike their closest relatives, horses and donkeys, zebras have never been truly domesticated." +
           " There are three species of zebras: the plains zebra, the Grévy's zebra and the mountain zebra. " +
           "The plains zebra and the mountain zebra belong to the subgenus Hippotigris, but Grévy's zebra is the sole species of subgenus Dolichohippus. " +
           "The latter resembles an ass, to which it is closely related, while the former two are more horse-like. All three belong to the genus Equus, along with other living equids." +
           " The unique stripes of zebras make them one of the animals most familiar to people. " +
           "They occur in a variety of habitats, such as grasslands, savannas, woodlands, thorny scrublands, mountains, and coastal hills. However, various anthropogenic factors have had a severe impact on zebra populations, in particular, hunting for skins and habitat destruction. " +
           "Grévy's zebra and the mountain zebra are endangered. While plains zebras are much more plentiful, one subspecies - the Quagga - became extinct in the late 19th century. Though there is currently a plan, called the Quagga Project, that aims to breed zebras that are phenotypically similar to the Quagga, in a process called breeding back​.",
           DisplayName = " should pass for sentence extraction")]
        public void Test_if_Sentence_Extraction_Pass(string sentencesString)
        {
            ProcessWiki processWiki = new ProcessWiki
            {
                Sentences = sentencesString
            };
            bool result = processWiki.ExtractSentences();
            Assert.IsTrue(result);
        }
        [TestMethod]
        [DataRow
           ("Zebras are several species of African equids (horse family) united by their distinctive black and white stripes." +
           " Their stripes come in different patterns, unique to each individual. " +
           "They are generally social animals that live in small harems to large herds." +
           " Unlike their closest relatives, horses and donkeys, zebras have never been truly domesticated." +
           " There are three species of zebras: the plains zebra, the Grévy's zebra and the mountain zebra. " +
           "The plains zebra and the mountain zebra belong to the subgenus Hippotigris, but Grévy's zebra is the sole species of subgenus Dolichohippus. " +
           "The latter resembles an ass, to which it is closely related, while the former two are more horse-like. All three belong to the genus Equus, along with other living equids." +
           " The unique stripes of zebras make them one of the animals most familiar to people. " +
           "They occur in a variety of habitats, such as grasslands, savannas, woodlands, thorny scrublands, mountains, and coastal hills. However, various anthropogenic factors have had a severe impact on zebra populations, in particular, hunting for skins and habitat destruction. " +
           "Grévy's zebra and the mountain zebra are endangered. While plains zebras are much more plentiful, one subspecies - the Quagga - became extinct in the late 19th century. Though there is currently a plan, called the Quagga Project, that aims to breed zebras that are phenotypically similar to the Quagga, in a process called breeding back​.",
           DisplayName = " Should fail for sentence extraction")]
        public void Test_if_Sentence_Extraction_Fail(string sentencesString)
        {
            ProcessWiki processWiki = new ProcessWiki
            {
                Sentences = ""
            };
            bool result = processWiki.ExtractSentences();
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DataRow
           (
           "Which Zebras are endangered?," +
           "What is the aim of the Quagga Project?," +
           "Which animals are some of their closest relatives?," +
           "Which are the three species of zebras?," +
           "Which subgenus do the plains zebra and the mountain zebra belong to?",
           DisplayName = " Should pass with correct questions as input")]
        public void Test_if_Question_Extraction_pass(string questionsString)
        {
            ProcessWiki processWiki = new ProcessWiki
            {
                Questions = questionsString,

            };
            var result = processWiki.ExtractQuestions();
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow
           (
           "Which Zebras are endangered?," +
           "What is the aim of the Quagga Project?," +
           "Which animals are some of their closest relatives?," +
           "Which are the three species of zebras?," +
           "Which subgenus do the plains zebra and the mountain zebra belong to?",
           DisplayName = " Should fail questions is null")]
        public void Test_if_Question_Extraction_Fail(string questionsString)
        {
            ProcessWiki processWiki = new ProcessWiki
            {
                Questions = null,

            };
            var result = processWiki.ExtractQuestions();
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DataRow
          ("subgenus Hippotigris; the plains zebra, the Grévy's zebra and the mountain zebra; horses and donkeys; aims to breed zebras that are phenotypically similar to the quagga; Grévy's zebra and the mountain zebra",
          DisplayName = " Should pass for answer extraction")]
        public void Test_if_Answer_Extraction_Pass(string answersString)
        {
            ProcessWiki processWiki = new ProcessWiki
            {
                Answers = answersString
            };
            var result = processWiki.ExtractAnswers();
            Assert.IsTrue(result);
        }
        [TestMethod]
        [DataRow
          ("subgenus Hippotigris; the plains zebra, the Grévy's zebra and the mountain zebra; horses and donkeys; aims to breed zebras that are phenotypically similar to the quagga; Grévy's zebra and the mountain zebra",
          DisplayName = "Should fail for answer extraction")]
        public void Test_if_Answer_Extraction_Fail(string answersString)
        {
            ProcessWiki processWiki = new ProcessWiki
            {
                Answers = null
            };
            var result = processWiki.ExtractAnswers();
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DataRow
           ("Zebras are several species of African equids (horse family) united by their distinctive black and white stripes." +
           " Their stripes come in different patterns, unique to each individual. " +
           "They are generally social animals that live in small harems to large herds." +
           " Unlike their closest relatives, horses and donkeys, zebras have never been truly domesticated." +
           " There are three species of zebras: the plains zebra, the Grévy's zebra and the mountain zebra. " +
           "The plains zebra and the mountain zebra belong to the subgenus Hippotigris, but Grévy's zebra is the sole species of subgenus Dolichohippus. " +
           "The latter resembles an ass, to which it is closely related, while the former two are more horse-like. All three belong to the genus Equus, along with other living equids." +
           " The unique stripes of zebras make them one of the animals most familiar to people. " +
           "They occur in a variety of habitats, such as grasslands, savannas, woodlands, thorny scrublands, mountains, and coastal hills. However, various anthropogenic factors have had a severe impact on zebra populations, in particular, hunting for skins and habitat destruction. " +
           "Grévy's zebra and the mountain zebra are endangered. While plains zebras are much more plentiful, one subspecies - the Quagga - became extinct in the late 19th century. Though there is currently a plan, called the Quagga Project, that aims to breed zebras that are phenotypically similar to the Quagga, in a process called breeding back​.",
           "Which Zebras are endangered?," +
           "What is the aim of the Quagga Project?," +
           "Which animals are some of their closest relatives?," +
           "Which are the three species of zebras?," +
           "Which subgenus do the plains zebra and the mountain zebra belong to?",
           "subgenus Hippotigris; the plains zebra, the Grévy's zebra and the mountain zebra; horses and donkeys; aims to breed zebras that are phenotypically similar to the quagga; Grévy's zebra and the mountain zebra",
           DisplayName = " Input from File - Should Pass")]
        public void Test_if_All_Parameters_Pass_Matching(string sentencesString, string questionsString, string answersString)
        {
            ProcessWiki processWiki = new ProcessWiki
            {
                Sentences = sentencesString,
                Questions = questionsString,
                Answers = answersString
            };
            ParagraphMatcher paragraphMatcher = new ParagraphMatcher(processWiki);
            var result = paragraphMatcher.Result();
            Assert.AreEqual("Grévy's zebra and the mountain zebra", result["Which Zebras are endangered?"].Data);
            Assert.AreEqual("aims to breed zebras that are phenotypically similar to the quagga", result["What is the aim of the Quagga Project?"].Data);
            Assert.AreEqual("horses and donkeys", result["Which animals are some of their closest relatives?"].Data);
            Assert.AreEqual("the plains zebra, the Grévy's zebra and the mountain zebra", result["Which are the three species of zebras?"].Data);
            Assert.AreEqual("subgenus Hippotigris", result["Which subgenus do the plains zebra and the mountain zebra belong to?"].Data);
        }

        [TestMethod]
        [DeploymentItem("input","TestData")]
        public void Test_for_Input_File_Match_TestcaseZebra()
        {
            ProcessWiki processWiki = new ProcessWiki();
            
            int counter = 1;
            string line;
            string filePath = $@"{Path.GetFullPath(@"TestData")}/input00.txt";
            List<string> questionList = new List<string>();
            System.IO.StreamReader file =
    new System.IO.StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
                switch (counter)
                {
                    case 1:
                        processWiki.Sentences = line.ToString();
                        break;
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                        questionList.Add(line.ToString().Trim());
                        break;
                    case 7:
                        processWiki.Answers = line.ToString().Trim();
                        break;
                }
                counter++;
            }
            processWiki.Questions = string.Join(",",questionList);
            file.Close();
            ParagraphMatcher paragraphMatcher = new ParagraphMatcher(processWiki);
            var result = paragraphMatcher.Result();
            Assert.AreEqual("Grevy's zebra and the mountain zebra", result["Which Zebras are endangered?"].Data);
            Assert.AreEqual("aims to breed zebras that are phenotypically similar to the quagga", result["What is the aim of the Quagga Project?"].Data);
            Assert.AreEqual("horses and donkeys", result["Which animals are some of their closest relatives?"].Data);
            Assert.AreEqual("the plains zebra, the Grevy's zebra and the mountain zebra", result["Which are the three species of zebras?"].Data);
            Assert.AreEqual("subgenus Hippotigris", result["Which subgenus do the plains zebra and the mountain zebra belong to?"].Data);
        }

    }
}
