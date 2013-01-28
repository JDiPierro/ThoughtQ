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
        Thought displayed;
        tQueue queue;
        MainWindow mainForm;

        public ThoughtInfo(ref Thought inThought, ref tQueue inThoughtList, MainWindow mainForm)
        {
            InitializeComponent();

            displayed = inThought;
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

            if (inThought.tState == thought_state.archived)
            {
                btnArchive.Enabled = false;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            displayed.setDescription(txt_Description.Text);
            displayed.setTitle(txt_Title.Text);
            displayed.setCategory(cbx_cat.Text);

            if(!queue.categories.Contains(cbx_cat.Text))
            {
                queue.categories.Add(cbx_cat.Text);
            }

            mainForm.updateList();
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(displayed.tState == thought_state.active)
                queue.thoughts.Remove(displayed);
            else
                queue.archive.Remove(displayed);
            mainForm.updateList();
            this.Close();
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            queue.thoughts.Remove(displayed);
            queue.archive.Add(displayed);
            displayed.tState = thought_state.archived;
            mainForm.updateList();
            this.Close();
        }
    }
}
