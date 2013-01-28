using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThoughtQ.FormFiles;
using ThoughtQ.Data;

namespace ThoughtQ
{
    public partial class MainWindow : Form
    {
        private tQueue queue;

        public static String AllCats = "All Categories";

        public MainWindow()
        {
            InitializeComponent();
            loadQueue();
            if(queue == null)
                queue = new tQueue();

            if (!System.IO.Directory.Exists(Serializer.defaultFilePath))
            {
                System.IO.Directory.CreateDirectory(Serializer.defaultFilePath);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            thoughtEntry.Text = FormConstants.defEnterText;

            cbx_cats.Items.Add(AllCats);
            cbx_cats.SelectedIndex = 0;
            //updateList();
        }

        private void loadQueue()
        {
            if (System.IO.Directory.Exists(Serializer.defaultFilePath))
            {
                String fp = Serializer.defaultFilePath + "\\thoughts.tq";
                if (System.IO.File.Exists(fp))
                {
                    //Yes: Load the day
                    queue = Serializer.DeSerialize(fp);

                    foreach (Thought t in queue.thoughts)
                    {
                        if (!queue.categories.Contains(t.getCategory()))
                        {
                            queue.categories.Add(t.getCategory());
                        }
                    }
                    foreach (Thought t in queue.archive)
                    {
                        if (!queue.categories.Contains(t.getCategory()))
                        {
                            queue.categories.Add(t.getCategory());
                        }
                    }
                }
            }
        }

        private void DeleteThought()
        {
            //Console.Out.WriteLine("Deleting...");
            var selected = archiveList.SelectedItems;
            foreach (ListViewItem item in selected)
            {
                Thought found = queue.archive.Find(i => (i.getTitle() == item.Text));
                //Console.Out.WriteLine("Found: {0}", found.getTitle());
                queue.archive.Remove(found);
            }
            updateList();
            //Serializer.SerializeToXML(thoughts);
        }

        private void ArchiveThought()
        {
            //Console.Out.WriteLine("Deleting...");
            var selected = thoughtList.SelectedItems;
            foreach (ListViewItem item in selected)
            {
                Thought found = queue.thoughts.Find(i => (i.getTitle() == item.Text));
                //Console.Out.WriteLine("Found: {0}", found.getTitle());
                found.tState = thought_state.archived;
                if (found != null)
                {
                    queue.archive.Add(found);
                    queue.thoughts.Remove(found);
                }
            }
            updateList();
            //Serializer.SerializeToXML(thoughts);
        }

        private void RestoreThought()
        {
            //Console.Out.WriteLine("Deleting...");
            var selected = archiveList.SelectedItems;
            foreach (ListViewItem item in selected)
            {
                Thought found = queue.archive.Find(i => (i.getTitle() == item.Text));
                //Console.Out.WriteLine("Found: {0}", found.getTitle());
                found.tState = thought_state.active;
                if (found != null)
                {
                    queue.thoughts.Add(found);
                    queue.archive.Remove(found);
                }
            }
            updateList();
            //Serializer.SerializeToXML(thoughts);
        }

        private void AddThought()
        {
            Thought newThought = new Thought(thoughtEntry.Text);
            queue.thoughts.Add(newThought);

            ListViewItem newEntry = new ListViewItem(newThought.getTitle());
            newEntry.SubItems.Add(newThought.getTimeCreated().ToShortTimeString());
            thoughtList.Items.Add(newEntry);

            thoughtEntry.Text = String.Empty;

            if (tabControl1.SelectedTab.Name != "tb_Active")
                tabControl1.SelectTab("tb_Active");
            updateList();
            //Serializer.SerializeToXML(thoughts);
        }

        public void updateList()
        {
            if (tabControl1.SelectedTab.Name == "tb_Archive")
            {
                updateList(queue.archive, thought_state.archived);
            }
            else
            {
                updateList(queue.thoughts, thought_state.active);
            }

            String filename = Serializer.defaultFilePath + "\\thoughts.tq";
            Serializer.Serialize(filename, queue);
        }

        public void updateList(List<Thought> inThoughts,thought_state state)
        {
            ListView view;
            if (state == thought_state.active)
            {
                view = thoughtList;
            }
            else
            {
                view = archiveList;
            }

            view.Items.Clear();
            if (queue.thoughts.Count > 0)
            {
                foreach (Thought t in inThoughts)
                {
                    if(!cbx_cats.Items.Contains(t.getCategory()))
                    {
                        cbx_cats.Items.Add(t.getCategory());
                    }
                    if (cbx_cats.SelectedItem.Equals(AllCats) || cbx_cats.SelectedItem.Equals(t.getCategory()))
                    {
                        ListViewItem newEntry = new ListViewItem(t.getTitle());
                        newEntry.SubItems.Add(t.getTimeCreated().ToShortTimeString());
                        view.Items.Add(newEntry);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (thoughtEntry.Text != "" && thoughtEntry.Text != FormConstants.defEnterText)
            {
                AddThought();
            }
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            updateList();
        }

        private void cbx_cats_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateList();
        }
    }
}
