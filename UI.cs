using System;
using System.Collections.Generic;
using System.Text;

namespace QuizMaker
{
    public class UI
    {
        public static void PrintQuestion(Question question)
        {
            Console.WriteLine(question.question);
            foreach (string i in question.possibleOptions)
            {
                Console.WriteLine($"{i} ");
            }
        }
        public static Question CreateQuestion()
        {
            Question newQuestion = new Question();
            bool wantToAddOtherOption = true;
            string continueWithAddingOption = "y";
            Console.WriteLine("Please write the question, that you want to add to the quiz database.");
            newQuestion.question = Console.ReadLine();

            while (wantToAddOtherOption)
            {
                Console.WriteLine("Please add an option for a possible answer to the question prior. Add at least 3 options.");
                string answerOption = Console.ReadLine();
                newQuestion.possibleOptions.Add(answerOption);
                Console.WriteLine("Add another option? Type y to continue or n to proceed to the answer.");
                continueWithAddingOption = Console.ReadLine();
                if (continueWithAddingOption == "y")
                {
                    continue;
                }
                else
                {
                    wantToAddOtherOption = false;
                }
            }
            wantToAddOtherOption = true;
            while (wantToAddOtherOption)
            {
                Console.WriteLine("Please mark the correct answer(s) to that question by adding all the answers.");
                string answerOfQuestion = Console.ReadLine();
                newQuestion.answer.Add(answerOfQuestion);
                Console.WriteLine("Add another option? Type y to continue or n to proceed to the answer.");
                continueWithAddingOption = Console.ReadLine();
                if (continueWithAddingOption == "y")
                {
                    continue;
                }
                else
                {
                    wantToAddOtherOption = false;
                }
            }
            return newQuestion;
        }
    }
}
