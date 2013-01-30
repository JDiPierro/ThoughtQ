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

        private void thoughtList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && archiveList.SelectedItems.Count > 0)
            {
                ArchiveThought();
            }
        }

        private void thoughtList_DoubleClick(object sender, EventArgs e)
        {
            var selected = thoughtList.SelectedItems;
            foreach (ListViewItem item in selected)
            {
                Thought found = queue.thoughts.Find(i => i.getTitle() == item.Text);
                ThoughtInfo tInfo = new ThoughtInfo(ref found, ref queue, this);
                tInfo.Show();
            }
        }

        private void archiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArchiveThought();
        }
    }
}
