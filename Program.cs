namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Question firstQuesiton = new Question();
            firstQuesiton.question = "What is the highest mountain in the world?";
            firstQuesiton.possibleOptions.Add("K2");
            firstQuesiton.possibleOptions.Add("Mount Everest");
            firstQuesiton.possibleOptions.Add("Mount Blanc");
            firstQuesiton.possibleOptions.Add("Zugspitze");

            Console.WriteLine(firstQuesiton.question);
            foreach (string i in firstQuesiton.possibleOptions)
            {
                Console.Write($"{i} ");
            }
        }
    }
}
