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

        List<ThoughtInfo> openThoughts = new List<ThoughtInfo>();

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
                    if(queue != null)
                    {
                        queue.loadCategories();
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
                queue.deleteThought((Thought)item.Tag);
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
                queue.archiveThought((Thought)item.Tag);
            }
            updateList();
            //Serializer.SerializeToXML(thoughts);
        }

        private void RestoreThought()
        {
            var selected = archiveList.SelectedItems;
            foreach (ListViewItem item in selected)
            {
                Thought t = (Thought)item.Tag;
                queue.RestoreThought((Thought)item.Tag);
            }
            updateList();
        }

        private void AddThought()
        {
            //Get a new thought from the queue
            Thought newThought = queue.AddThought(thoughtEntry.Text);

            //Create the ListViewItem that will be displayed in the list
            ListViewItem newEntry = new ListViewItem(newThought.getTitle());
            newEntry.SubItems.Add(newThought.getTimeCreated().ToShortTimeString());
            newEntry.Tag = newThought;
            thoughtList.Items.Add(newEntry);

            //Clear the thoughtEntry field
            thoughtEntry.Text = String.Empty;

            //Select the Active tab after creating a new item.
            if (tabControl1.SelectedTab.Name != "tb_Active")
                tabControl1.SelectTab("tb_Active");
            //Update the list view.
            updateList();
        }

        public void updateList()
        {
            if (tabControl1.SelectedTab.Name == "tb_Archive")
            {
                updateList(queue.getArchive(), thought_state.archived);
            }
            else
            {
                updateList(queue.getActive(), thought_state.active);
            }

            String filename = Serializer.defaultFilePath + "\\thoughts.tq";
            Serializer.Serialize(filename, queue);
        }

        public void updateList(IReadOnlyCollection<Thought> inThoughts,thought_state state)
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
            if (queue.getActive().Count > 0)
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
                        if (t.getTimeCreated().Date < DateTime.Now.Date)
                        {
                            newEntry.SubItems.Add(t.getTimeCreated().Month + "/" + t.getTimeCreated().Day);
                        }
                        else
                        {
                            newEntry.SubItems.Add(t.getTimeCreated().ToShortTimeString());
                        }
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
