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
        private List<Thought> allThoughts;
        private List<Thought> thoughts;
        private List<Thought> archive;
        public List<String> categories;

        public tQueue()
        {
            thoughts = new List<Thought>();
            archive = new List<Thought>();
            categories = new List<String>();
            allThoughts = new List<Thought>();
        }

        public IReadOnlyCollection<Thought> getActive()
        {
            return thoughts.AsReadOnly();
        }

        public IReadOnlyCollection<Thought> getArchive()
        {
            return archive.AsReadOnly();
        }

        public IReadOnlyCollection<Thought> getAll()
        {
            return allThoughts.AsReadOnly();
        }

        #region SERIALIZATION

        public tQueue(SerializationInfo info, StreamingContext context)
        {
            thoughts = (List<Thought>)info.GetValue("thoughts", typeof(List<Thought>));
            archive = (List<Thought>)info.GetValue("archive", typeof(List<Thought>));
            try
            {
                categories = (List<String>)info.GetValue("categories", typeof(List<String>));
            }
            catch (SerializationException e)
            {
                categories = new List<String>();
            }
            try
            {
                allThoughts = (List<Thought>)info.GetValue("allThoughts", typeof(List<Thought>));
            }
            catch (SerializationException)
            {
                foreach(Thought t in thoughts)
                {
                    allThoughts.Add(t);
                }

                foreach(Thought t in archive)
                {
                    allThoughts.Add(t);
                }
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("thoughts", thoughts);
            info.AddValue("archive", archive);
            info.AddValue("categories", categories);
            info.AddValue("allThoughts", allThoughts);
        }

        #endregion

        public void deleteThought(Thought t)
        {
            if (thoughts.Contains(t))
                thoughts.Remove(t);
            else if(archive.Contains(t))
                archive.Remove(t);
            
            allThoughts.Remove(t);
        }

        public void archiveThought(Thought t)
        {
            archive.Add(t);
            t.tState = thought_state.archived;
            thoughts.Remove(t);
        }

        public void RestoreThought(Thought t)
        {
            t.tState = thought_state.active;
            thoughts.Add(t);
            archive.Remove(t);
        }

        public Thought AddThought(String name)
        {
            Thought newThought = new Thought(name);
            thoughts.Add(newThought);
            allThoughts.Add(newThought);
            
            return newThought;
        }

        public void loadCategories()
        {
            foreach (Thought t in thoughts)
            {
                if (!categories.Contains(t.getCategory()))
                {
                    categories.Add(t.getCategory());
                }
            }

            foreach (Thought t in archive)
            {
                if (!categories.Contains(t.getCategory()))
                {
                    categories.Add(t.getCategory());
                }
            }
        }
    }
}
