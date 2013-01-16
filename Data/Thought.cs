using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ThoughtQ.Data
{
    [Serializable]
    public class Thought : ISerializable
    {
        private String Title;
        private String Description;
        private DateTime created;

        #region SERIALIZATION

        public Thought(SerializationInfo info, StreamingContext context)
        {
            Title = (String)info.GetValue("Title", typeof(String));
            Description = (String)info.GetValue("Description", typeof(String));
            created = (DateTime)info.GetValue("created", typeof(DateTime));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Title", Title);
            info.AddValue("Description", Description);
            info.AddValue("created", created);
        }

        #endregion

        public Thought()
        {
            Title = "Empty Thought";
            Description = String.Empty;
            created = DateTime.Now;
        }

        public Thought(String inTitle, String inDescription = "")
        {
            Title = inTitle;
            Description = inDescription;
            created = DateTime.Now;
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
