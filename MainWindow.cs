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
        private List<ThoughtInfo> openWindows = new List<ThoughtInfo>();

        List<ThoughtInfo> openThoughts = new List<ThoughtInfo>();
        List<ListViewItem> hiddenActive = new List<ListViewItem>();
        List<ListViewItem> hiddenArchive = new List<ListViewItem>();

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
                        foreach (Thought t in queue.getAll())
                        {
                            AddThought(t);
                        }

                        cbx_cats.Items.Add(AllCats);
                        act_ctxt_cats.DropDownItems.Add(new ToolStripMenuItem(AllCats));
                        cbx_cats.SelectedIndex = 0;

                        foreach (String str in queue.categories)
                        {
                            if (!cbx_cats.Items.Contains(str))
                                cbx_cats.Items.Add(str);
                            ToolStripMenuItem catItem = new ToolStripMenuItem(str);
                            catItem.Click += clickedCategoryContext;
                            if (!act_ctxt_cats.DropDownItems.Contains(catItem))
                            {
                                act_ctxt_cats.DropDownItems.Add(catItem);
                            }
                        }
                    }
                }
            }
        }

        private void clickedCategoryContext(object sender, EventArgs e)
        {
            ListView list;
            ToolStripMenuItem inCat = (ToolStripMenuItem)sender;
            if (tabControl1.SelectedTab.Name.Equals("tb_Active"))
            {
                list = thoughtList;
            }
            else
            {
                list = archiveList;
            }

            foreach (ListViewItem item in list.SelectedItems)
            {
                Thought t = (Thought)item.Tag;

                t.setCategory(inCat.Text);
            }
            SaveQueue();
        }

        public void updateCategories(Thought t)
        {
            if (!cbx_cats.Items.Contains(t.getCategory()))
            {
                cbx_cats.Items.Add(t.getCategory());
            }
        }

        private void DeleteThought()
        {
            //Console.Out.WriteLine("Deleting...");
            var selected = archiveList.SelectedItems;
            foreach (ListViewItem item in selected)
            {
                //Delete the Thought
                queue.deleteThought((Thought)item.Tag);
                //Delete the ListViewItem associated with that thought.
                archiveList.Items.Remove(item);
            }
            //updateList();
            SaveQueue();
        }

        private void ArchiveThought()
        {
            //Console.Out.WriteLine("Deleting...");
            var selected = thoughtList.SelectedItems;
            foreach (ListViewItem item in selected)
            {
                queue.archiveThought((Thought)item.Tag);
                thoughtList.Items.Remove(item);
                archiveList.Items.Add(item);
            }
            //updateList();
            //Serializer.SerializeToXML(thoughts);
            SaveQueue();
        }

        private void RestoreThought()
        {
            var selected = archiveList.SelectedItems;
            foreach (ListViewItem item in selected)
            {
                Thought t = (Thought)item.Tag;
                queue.RestoreThought((Thought)item.Tag);
                archiveList.Items.Remove(item);
                thoughtList.Items.Add(item);
            }
            //updateList();
            SaveQueue();
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
            //updateList();
            SaveQueue();
        }

        private void AddThought(Thought t)
        {
            
            //Create the ListViewItem that will be displayed in the list
            ListViewItem newEntry = new ListViewItem(t.getTitle());
            newEntry.SubItems.Add(t.getTimeCreated().ToShortTimeString());
            newEntry.Tag = t;

            if (t.tState == thought_state.active)
                thoughtList.Items.Add(newEntry);
            else
                archiveList.Items.Add(newEntry);

            //Select the Active tab after creating a new item.
            if (tabControl1.SelectedTab.Name != "tb_Active")
                tabControl1.SelectTab("tb_Active");
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
            updateListForCategory(tabControl1.SelectedTab.Name);
        }

        public void addCategory(String cat)
        {
            if (!queue.categories.Contains(cat))
            {
                queue.categories.Add(cat);
            }

            if (!cbx_cats.Items.Contains(cat))
            {
                cbx_cats.Items.Add(cat);
            }

            ToolStripMenuItem item = new ToolStripMenuItem(cat);
            if (!act_ctxt_cats.DropDownItems.Contains(item))
            {
                act_ctxt_cats.DropDownItems.Add(item);
            }
        }

        private void cbx_cats_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateListForCategory(tabControl1.SelectedTab.Name);
        }

        private void updateListForCategory(String activeTab)
        {
            ListView list;
            List<ListViewItem> hidden;
            if (activeTab.Equals("tb_Active"))
            {
                list = thoughtList;
                hidden = hiddenActive;
            }
            else
            {
                list = archiveList;
                hidden = hiddenArchive;
            }

            for(int i = 0 ; i < list.Items.Count; i++)
            {
                Thought t = (Thought)list.Items[i].Tag;

                if (!cbx_cats.SelectedItem.Equals(AllCats) && !t.getCategory().Equals(cbx_cats.SelectedItem))
                {
                    hidden.Add(list.Items[i]);
                    list.Items.Remove(list.Items[i]);
                }
            }

            for(int i = 0; i < hidden.Count; i++)
            {
                Thought t = (Thought)hidden[i].Tag;
                if (cbx_cats.SelectedItem.Equals(AllCats) || t.getCategory().Equals(cbx_cats.SelectedItem))
                {
                    list.Items.Add(hidden[i]);
                    hidden.Remove(hidden[i]);
                }
            }
        }

        public void SaveQueue()
        {
            String filename = Serializer.defaultFilePath + "\\thoughts.tq";
            Serializer.Serialize(filename, queue);
        }

        public void closeWin(ThoughtInfo tIn)
        {
            openThoughts.Remove(tIn);
        }
    }
}
