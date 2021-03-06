﻿using System;
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
        private ListViewItem item;
        private Thought displayed;

        /* Object Reference */
        private tQueue queue;
        private MainWindow mainForm;

        public ThoughtInfo(ref ListViewItem inView, ref tQueue inThoughtList, MainWindow mainForm)
        {
            InitializeComponent();

            item = inView;
            displayed = (Thought)item.Tag;
            queue = inThoughtList;

            txt_Title.Text = displayed.getTitle();
            txt_Description.Text = displayed.getDescription();
            txt_Created.Text = displayed.getTimeCreated().ToShortTimeString();
            cbx_cat.Text = displayed.getCategory();
            foreach (String el in inThoughtList.categories)
            {
                cbx_cat.Items.Add(el);
            }
            this.mainForm = mainForm;

            if (displayed.tState == thought_state.archived)
            {
                btnArchive.Enabled = false;
            }
            this.Text = "Thought Info -- " + displayed.getTitle();
           
        }

        public Thought getThought()
        {
            return displayed;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            displayed.setDescription(txt_Description.Text);
            displayed.setTitle(txt_Title.Text);
            item.Text = displayed.getTitle();
            displayed.setCategory(cbx_cat.Text);

            mainForm.addCategory(cbx_cat.Text);
            mainForm.SaveQueue();

            //mainForm.updateList();
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(displayed.tState == thought_state.active)
                queue.deleteThought(displayed);
            else
                queue.deleteThought(displayed);
            //mainForm.updateList();
            this.Close();
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            queue.archiveThought(displayed);
            displayed.tState = thought_state.archived;
            //mainForm.updateList();
            this.Close();
        }

        private void txt_Description_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
            {
                txt_Description.SelectAll();
            }
            else if (e.Control & e.KeyCode == Keys.Back)
            {
                SendKeys.SendWait("^+{LEFT}{BACKSPACE}");
            }
        }

        private void txt_Title_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
            {
                txt_Title.SelectAll();
            }
            else if (e.Control & e.KeyCode == Keys.Back)
            {
                SendKeys.SendWait("^+{LEFT}{BACKSPACE}");
            }
        }

        private void ThoughtInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.closeWin(this);
        }
    }
}
