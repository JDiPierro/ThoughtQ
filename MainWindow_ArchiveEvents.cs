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
        private void archiveList_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Delete) && archiveList.SelectedItems.Count > 0)
            {
                DeleteThought();
            }
        }

        private void archiveList_DoubleClick(object sender, EventArgs e)
        {
            var selected = archiveList.SelectedItems;
            foreach (ListViewItem item in selected)
            {
                Thought found = archive.Find(i => i.getTitle() == item.Text);
                ThoughtInfo tInfo = new ThoughtInfo(ref found, ref archive, this);
                tInfo.Show();
            }
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestoreThought();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteThought();
        }
    }
}
