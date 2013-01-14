using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ThoughtQ.Data
{
    [Serializable]
    public class Thought
    {
        private String Title;
        private String Description;
        DateTime created;

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
