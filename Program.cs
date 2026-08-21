namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create list to store alle the quiz questions
            var QuizList = new List<Question>();
            var CurrentQuizList = new List<Question>();
            int mode = 0; //init of mode var
            //read from a previous session created questions,
            //so when choosing mode ExpandQuizDatabase,
            //you would not start from zero
            QuizList = Logic.LoadQuestionsFromQuizDatabaseFile(QuizList);

            //ask user which mode to use: create questions for quizdatabase
            //or play the quiz
            mode = UI.AskUserWhatModeToUse();
            //mode selected for storing new questions in the quiz databse
            if (mode == (int)Enums.Mode.ExpandQuizDatabase)
            {
                do
                {
                    QuizList.Add(UI.CreateQuestion());
                }
                while (UI.AskUserToAddAnotherQuestion());

                Logic.StoreQuestionsToQuizDataBaseFile(QuizList);
            }
            if (mode == (int)Enums.Mode.PlayQuiz)
            {
                CurrentQuizList = QuizList;
                int scoreTracker = 0; // counter for correct answered questions
                int counterQuestionAsked = 0;
                Question nextQuestion = new Question();
                Random rng = new Random();
                int lowerBound = 0;
                int upperBound = CurrentQuizList.Count();
                int randomIndex = rng.Next(lowerBound, upperBound);
                nextQuestion  = CurrentQuizList[randomIndex];
                UI.PrintQuestion(nextQuestion);
            }
        }
    }
}
