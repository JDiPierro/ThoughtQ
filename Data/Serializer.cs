using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ThoughtQ.Data
{
    public class Serializer
    {
        public static String defaultFilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Thoughts";

        static public void SerializeToXML(List<Thought> inThoughts)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Thought>));
            TextWriter textWriter = new StreamWriter(@"C:\thoughts.xml");
            serializer.Serialize(textWriter, inThoughts);
            textWriter.Close();
        }

        public static void Serialize(string filename, tQueue serialize)
        {
            Stream stream = File.Open(filename, FileMode.Create);

            var bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, serialize);

            stream.Close();
        }

        public static tQueue DeSerialize(string filename)
        {
            try
            {
                Stream stream = File.Open(filename, FileMode.Open);

                var bFormatter = new BinaryFormatter();
                var loaded = (tQueue)bFormatter.Deserialize(stream);

                stream.Close();

                return loaded;
            }
            catch
            {}

            return null;
        }
    }
}
