using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


namespace QuizMaker
{
    internal class QuizStorage
    {
        public static XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));

        public static void StoreQuestion(List<Question> quizlist)
        {
            var path = @"C:\Users\Timur\source\repos\QuizMaker\QuizStorage\QuizDataBase.xml";
            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, quizlist);
            }
        }
        public static List<Question> ReadQuestion()
        {
            var path = @"C:\Users\Timur\source\repos\QuizMaker\QuizStorage\QuizDataBase.xml";
            using (FileStream file = File.OpenRead(path))
            {                
               return serializer.Deserialize(file) as List<Question>;
            }
        }
    }
}
