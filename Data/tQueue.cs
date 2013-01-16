using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ThoughtQ.Data
{
    [Serializable]
    public class tQueue : ISerializable
    {
        public List<Thought> thoughts;
        public List<Thought> archive;

        public tQueue()
        {
            thoughts = new List<Thought>();
            archive = new List<Thought>();
        }

        #region SERIALIZATION

        public tQueue(SerializationInfo info, StreamingContext context)
        {
            thoughts = (List<Thought>)info.GetValue("thoughts", typeof(List<Thought>));
            archive = (List<Thought>)info.GetValue("archive", typeof(List<Thought>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("thoughts", thoughts);
            info.AddValue("archive", archive);
        }

        #endregion
    }
}
