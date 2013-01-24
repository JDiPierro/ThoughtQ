using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ThoughtQ.Data
{
    public enum thought_state
    {
        active,
        archived
    }

    [Serializable]
    public class Thought : ISerializable
    {
        private String Title;
        private String Description;
        private DateTime created;
        public thought_state tState;

        #region SERIALIZATION

        public Thought(SerializationInfo info, StreamingContext context)
        {
            Title = (String)info.GetValue("Title", typeof(String));
            Description = (String)info.GetValue("Description", typeof(String));
            created = (DateTime)info.GetValue("created", typeof(DateTime));
            tState = (thought_state)info.GetValue("tState", typeof(thought_state));
            
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Title", Title);
            info.AddValue("Description", Description);
            info.AddValue("created", created);
            info.AddValue("tState", tState);
        }

        #endregion

        public Thought()
        {
            Title = "Empty Thought";
            Description = String.Empty;
            created = DateTime.Now;
            tState = thought_state.active;
        }

        public Thought(String inTitle, String inDescription = "")
        {
            Title = inTitle;
            Description = inDescription;
            created = DateTime.Now;
            tState = thought_state.active;
        }

        public void setTitle(String inTitle)
        {
            Title = inTitle;
        }

        public void setDescription(String inDescription)
        {
            Description = inDescription;
        }

        public String getTitle()
        {
            return Title;
        }

        public String getDescription()
        {
            return Description;
        }

        public DateTime getTimeCreated()
        {
            return created;
        }
    }
}
