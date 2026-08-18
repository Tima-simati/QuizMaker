namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var QuizList = new List<Question>();    

            Question firstQuesiton = new Question();
            firstQuesiton.question = "What is the highest mountain in the world?";
            firstQuesiton.possibleOptions.Add("K2");
            firstQuesiton.possibleOptions.Add("Mount Everest");
            firstQuesiton.possibleOptions.Add("Mount Blanc");
            firstQuesiton.possibleOptions.Add("Zugspitze");
            firstQuesiton.answer.Add("Mount Everest");

            Question secondQuesiton = new Question();
            secondQuesiton.question = "What is longest river in the world?";
            secondQuesiton.possibleOptions.Add("Nile");
            secondQuesiton.possibleOptions.Add("Amazonas");
            secondQuesiton.possibleOptions.Add("Danube");
            secondQuesiton.possibleOptions.Add("Wolga");
            secondQuesiton.answer.Add("Nile");

            Console.WriteLine(firstQuesiton.question);
            foreach (string i in firstQuesiton.possibleOptions)
            {
                Console.WriteLine($"{i} ");
            }

            //List created to store all question
            QuizList.Add(firstQuesiton);
            QuizList.Add(secondQuesiton);

            QuizStorage.StoreQuestion(QuizList);
        }
    }
}
