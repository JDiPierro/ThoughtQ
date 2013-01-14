﻿using System;
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
        private List<Thought> thoughts;
        private List<Thought> archive;

        public MainWindow()
        {
            InitializeComponent();
            thoughts = new List<Thought>();
            archive = new List<Thought>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            thoughtEntry.Text = FormConstants.defEnterText;
        }

        private void DeleteThought()
        {
            //Console.Out.WriteLine("Deleting...");
            var selected = archiveList.SelectedItems;
            foreach (ListViewItem item in selected)
            {
                Thought found = archive.Find(i => (i.getTitle() == item.Text));
                //Console.Out.WriteLine("Found: {0}", found.getTitle());
                archive.Remove(found);
            }
            updateArchiveList();
            //Serializer.SerializeToXML(thoughts);
        }

        private void ArchiveThought()
        {
            //Console.Out.WriteLine("Deleting...");
            var selected = thoughtList.SelectedItems;
            foreach (ListViewItem item in selected)
            {
                Thought found = thoughts.Find( i => (i.getTitle() == item.Text) );
                //Console.Out.WriteLine("Found: {0}", found.getTitle());
                if (found != null)
                {
                    archive.Add(found);
                    thoughts.Remove(found);
                }
            }
            updateActiveList();
            //Serializer.SerializeToXML(thoughts);
        }

        private void RestoreThought()
        {
            //Console.Out.WriteLine("Deleting...");
            var selected = archiveList.SelectedItems;
            foreach (ListViewItem item in selected)
            {
                Thought found = archive.Find(i => (i.getTitle() == item.Text));
                //Console.Out.WriteLine("Found: {0}", found.getTitle());
                if (found != null)
                {
                    thoughts.Add(found);
                    archive.Remove(found);
                }
            }
            updateArchiveList();
            //Serializer.SerializeToXML(thoughts);
        }

        private void AddThought()
        {
            Thought newThought = new Thought(thoughtEntry.Text);
            thoughts.Add(newThought);

            ListViewItem newEntry = new ListViewItem(newThought.getTitle());
            newEntry.SubItems.Add(newThought.getTimeCreated().ToShortTimeString());
            thoughtList.Items.Add(newEntry);

            thoughtEntry.Text = String.Empty;
            //Serializer.SerializeToXML(thoughts);
        }

        public void updateActiveList()
        {
            thoughtList.Items.Clear();
            foreach (Thought t in thoughts)
            {
                ListViewItem newEntry = new ListViewItem(t.getTitle());
                newEntry.SubItems.Add(t.getTimeCreated().ToShortTimeString());
                thoughtList.Items.Add(newEntry);
            }
        }

        public void updateArchiveList()
        {
            archiveList.Items.Clear();
            foreach (Thought t in archive)
            {
                ListViewItem newEntry = new ListViewItem(t.getTitle());
                newEntry.SubItems.Add(t.getTimeCreated().ToShortTimeString());
                archiveList.Items.Add(newEntry);
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
            if (tabControl1.SelectedTab.Name == "tp_Archive")
            {
                updateActiveList();
            }
            else
            {
                updateArchiveList();
            }
        }

    }
}
