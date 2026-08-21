using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


namespace QuizMaker
{
    internal class Logic
    {
        public static XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));

        public static void StoreQuestionsToQuizDataBaseFile(List<Question> quizlist)
        {
            using (FileStream file = File.Create(Constants.DATABASE_PATH))
            {
                serializer.Serialize(file, quizlist);
            }
        }
        public static List<Question> LoadQuestionsFromQuizDatabaseFile(List<Question> quizlist)
        {
            using (FileStream file = File.OpenRead(Constants.DATABASE_PATH))
            {
                quizlist = serializer.Deserialize(file) as List<Question>;
                return quizlist;
            }
        }

    }
}
