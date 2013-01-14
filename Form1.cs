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
    public partial class Form1 : Form
    {

        private List<Thought> thoughts;

        public Form1()
        {
            InitializeComponent();
            thoughts = new List<Thought>();
        }

        private void AddThought()
        {
            Thought newThought = new Thought(thoughtEntry.Text);
            thoughts.Add(newThought);

            ListViewItem newEntry = new ListViewItem(newThought.getTitle());
            newEntry.SubItems.Add(newThought.getTimeCreated().ToShortTimeString());
            thoughtList.Items.Add(newEntry);

            thoughtEntry.Text = String.Empty;
        }

        private void updateList()
        {
            thoughtList.Items.Clear();
            foreach (Thought t in thoughts)
            {
                ListViewItem newEntry = new ListViewItem(t.getTitle());
                newEntry.SubItems.Add(t.getTimeCreated().ToShortTimeString());
                thoughtList.Items.Add(newEntry);
            }
        }

        private void thoughtList_DoubleClick(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selected = thoughtList.SelectedItems;
            foreach (ListViewItem item in selected)
            {
                Thought found = thoughts.Find(i => i.getTitle() == item.Text);
                ThoughtInfo tInfo = new ThoughtInfo(found, thoughts);
                tInfo.ShowDialog();
            }
            updateList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            thoughtEntry.Text = FormConstants.defEnterText;
        }

        private void thoughtEntry_Enter(object sender, EventArgs e)
        {
            if (thoughtEntry.Text == FormConstants.defEnterText)
                thoughtEntry.Text = String.Empty;
        }

        private void thoughtEntry_Leave(object sender, EventArgs e)
        {
            if (thoughtEntry.Text == "")
                thoughtEntry.Text = FormConstants.defEnterText;
        }

        private void thoughtEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && thoughtEntry.Text != "")
            {
                AddThought();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AddThought();
        }
    }
}
