using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThoughtQ.Data;

namespace ThoughtQ
{
    public partial class ThoughtInfo : Form
    {
        Thought displayed;
        List<Thought> allThoughts;

        public ThoughtInfo(Thought inThought, List<Thought> inThoughtList)
        {
            InitializeComponent();

            displayed = inThought;
            allThoughts = inThoughtList;

            txt_Title.Text = displayed.getTitle();
            txt_Description.Text = displayed.getDescription();
            txt_Created.Text = displayed.getTimeCreated().ToShortTimeString();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            displayed.setDescription(txt_Description.Text);
            displayed.setTitle(txt_Title.Text);
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            allThoughts.Remove(displayed);
            this.Close();
        }
    }
}
