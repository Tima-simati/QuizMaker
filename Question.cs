using System;
using System.Collections.Generic;
using System.Text;

namespace QuizMaker
{
    public class Question
    {
        public string question;
        public List<string> possibleOptions = new List<string>();
        public List<string> answer = new List<string>(); //answer stored in List to support multiple choice questions
    }
}
