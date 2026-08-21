using System;
using System.Collections.Generic;
using System.Text;

namespace QuizMaker
{
    public class UI
    {        
        public static void PrintQuestion(Question question)
        {
            int indexOfList = 0;
            Console.WriteLine(question.question);
            foreach (string i in question.possibleOptions)
            {
                Console.WriteLine($"{i} ");
                
            }
            foreach (string i in question.possibleOptions)
            {                
                Console.Write($"Press {indexOfList} for {i}, ");
                indexOfList++;
            }
            
        }
        /// <summary>
        /// asks user which mode he wants to use:
        /// Create questions
        /// or play the quiz
        /// </summary>
        /// <returns>mode: add question or play quiz</returns>
        public static int AskUserWhatModeToUse()
        {
            Console.WriteLine($"What mode to you want to use?\nPress {(int)Enums.Mode.ExpandQuizDatabase} for creating more questions for the quiz.");
            Console.WriteLine($"Or press {(int)Enums.Mode.PlayQuiz} to play the quiz game");
            int.TryParse(Console.ReadLine(), out int mode);
            while (mode != (int)Enums.Mode.ExpandQuizDatabase && mode != (int)Enums.Mode.PlayQuiz)
            {
                Console.WriteLine($"Mode not found. Please press only {(int)Enums.Mode.ExpandQuizDatabase} or {(int)Enums.Mode.PlayQuiz}");
                int.TryParse(Console.ReadLine(), out mode);
                if (mode == (int)Enums.Mode.ExpandQuizDatabase || mode == (int)Enums.Mode.ExpandQuizDatabase)
                {
                    break;
                }
            }
            return mode;
        }
        /// <summary>
        /// method to ask user to state a question.
        /// choose possible answer options and
        /// mark the right answers
        /// </summary>
        /// <returns>Question object</returns>
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
                if (continueWithAddingOption != "y" && countOptions < Constants.AT_LEAST_NEEDED_OPTIONS)
                {
                    Console.WriteLine("You need at least 3 options for that questions. Add another one");
                    continue;
                }
                if (countOptions >= Constants.AT_LEAST_NEEDED_OPTIONS && continueWithAddingOption != "y")
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
        /// <summary>
        /// ask user, if he wants to add another questions in the mode ExpandQuizDatabase
        /// </summary>
        /// <returns>bool value for continue</returns>
        public static bool AskUserToAddAnotherQuestion()
        {
            bool choice = true;
            Console.WriteLine("Do you want to add another question to the database?\nPress y or n.");
            string choiceToAddOtherQuestions = Console.ReadLine();
            choice = choiceToAddOtherQuestions == "y" ? true : false;
            return choice;
        }
    }
}
