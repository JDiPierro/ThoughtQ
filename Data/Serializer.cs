using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace ThoughtQ.Data
{
    class Serializer
    {
        static public void SerializeToXML(List<Thought> inThoughts)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Thought>));
            TextWriter textWriter = new StreamWriter(@"C:\thoughts.xml");
            serializer.Serialize(textWriter, inThoughts);
            textWriter.Close();
        }
    }
}
