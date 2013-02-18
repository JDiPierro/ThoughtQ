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
        public static String unCat = "Uncategorized";

        private String Title;
        private String Description;
        private String Category;
        private DateTime created;
        private DateTime lastUpdated;
        public thought_state tState;

        #region SERIALIZATION

        //Constructor used when deserializing data.
        public Thought(SerializationInfo info, StreamingContext context)
        {
            try
            {
                Title = (String)info.GetValue("Title", typeof(String));
            }
            catch (SerializationException e)
            {
                Title = "Corrupted Thought";
            }

            try
            {
                Description = (String)info.GetValue("Description", typeof(String));
            }
            catch (SerializationException e)
            {
                Description = String.Empty;
            }

            try
            {
                created = (DateTime)info.GetValue("created", typeof(DateTime));
            }
            catch (SerializationException e)
            {
                created = DateTime.Now;
            }

            try
            {
                tState = (thought_state)info.GetValue("tState", typeof(thought_state));
            }
            catch (SerializationException e)
            {
                tState = thought_state.active;
            }

            try
            {
                Category = (String)info.GetValue("Category", typeof(String));
            }
            catch(SerializationException e)
            {
                Category = unCat;
            }

            try
            {
                lastUpdated = (DateTime)info.GetValue("lastUpdated", typeof(DateTime));
            }
            catch (SerializationException e)
            {
                lastUpdated = DateTime.Now;
            }
        }

        //Used to get the data for serialization.
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Title", Title);
            info.AddValue("Description", Description);
            info.AddValue("created", created);
            info.AddValue("tState", tState);
            info.AddValue("Category", Category);
            info.AddValue("lastUpdated", lastUpdated);
        }

        #endregion

        public Thought()
        {
            Title = "Empty Thought";
            Description = String.Empty;
            created = DateTime.Now;
            lastUpdated = DateTime.Now;
            tState = thought_state.active;
            Category = unCat;
        }

        public Thought(String inTitle, String inDescription = "", String inCategory = "Uncategorized")
        {
            Title = inTitle;
            Description = inDescription;
            created = DateTime.Now;
            lastUpdated = DateTime.Now;
            tState = thought_state.active;
            Category = inCategory;
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

        public DateTime getLastUpdate()
        {
            return lastUpdated;
        }

        public void Update()
        {
            lastUpdated = DateTime.Now;
        }

        public String getCategory()
        {
            return Category;
        }

        public void setCategory(String inCat)
        {
            Category = inCat;
        }
    }
}
