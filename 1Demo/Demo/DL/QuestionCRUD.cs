using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.bl.DI
{
    internal class QuestionCRUD
    {
        public static List<Question> ReadQuestionsFromFile(string filePath)
        {
            List<Question> questions = new List<Question>();

            StreamReader reader = new StreamReader(filePath);
            if(File.Exists(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length == 2)
                    {
                        string questionText = parts[0];
                        string answerText = parts[1];

                        Question question = new Question(questionText, answerText);
                        questions.Add(question);
                    }
                }
            }

            return questions;
        }
        public static void displayQuestion(string path)
        {           
            List<Question> questions = ReadQuestionsFromFile(path);

            // Select a random question
            Question randomQuestion = SelectRandomQuestion(questions);

            // Display the question to the user
            Console.WriteLine(randomQuestion.text);

            // Get the user's answer
            Console.Write("Your answer: ");
            string userAnswer = Console.ReadLine();

            // Check if the answer is correct
            if (CheckAnswer(randomQuestion, userAnswer))
            {
                Console.WriteLine("Correct Answer!\nYou Won 150MB".ToUpper());
            }
            else
            {
                Console.WriteLine("Incorrect Answer!\nTry Again Later".ToUpper());
            }

            Console.ReadLine();
        }
        public static Question SelectRandomQuestion(List<Question> questions)
        {
            Random random = new Random();
            int index = random.Next(questions.Count);
            return questions[index];
        }
        public static bool CheckAnswer(Question question, string answer)
        {
            return question.answer.ToLower() == answer.ToLower();
        }

    }
}
