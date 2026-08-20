using System;
using System.Collections.Generic;
using System.Text;

namespace QuizMaker
{
    public class UI
    {
        public const int AT_LEAST_NEEDED_OPTIONS = 3;
        public static void PrintQuestion(Question question)
        {
            Console.WriteLine(question.question);
            foreach (string i in question.possibleOptions)
            {
                Console.WriteLine($"{i} ");
            }
        }
        public static int AskUserWhatModeToUse()
        {
            Console.WriteLine($"What mode to you want to use?\nPress {(int)Enums.Mode.ExpandQuizDatabase} for creating more questions for the quiz.");
            Console.WriteLine($"Or press {(int)Enums.Mode.PlayQuiz} to play the quiz game");
            int.TryParse(Console.ReadLine(), out int mode);
            while(mode != 1 && mode!= 2)
            {
                Console.WriteLine($"Mode not found. Please press only {(int)Enums.Mode.ExpandQuizDatabase} or {(int)Enums.Mode.PlayQuiz}");
                int.TryParse(Console.ReadLine(), out mode);
                if (mode == 1 || mode == 2)
                {
                    break;
                }
            }
            return mode;
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
                int countOptions = newQuestion.possibleOptions.Count();
                Console.WriteLine("Add another option? Type y to continue or n to proceed to the answer.");
                continueWithAddingOption = Console.ReadLine();
                if (continueWithAddingOption == "y")
                {
                    continue;
                }
                if (continueWithAddingOption != "y" && countOptions < AT_LEAST_NEEDED_OPTIONS)
                {
                    Console.WriteLine("You need at least 3 options for that questions. Add another one");
                    continue;
                }
                if (countOptions >= AT_LEAST_NEEDED_OPTIONS && continueWithAddingOption != "y")
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
