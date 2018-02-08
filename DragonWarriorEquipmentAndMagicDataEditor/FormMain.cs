using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/*
 * Author: Shawn M. Crawford [sleepy]
 * sleepy3d@gmail.com
 * 2018+
 */
namespace DragonWarriorEquipmentAndMagicDataEditor
{
    public partial class FormMain : Form
    {
        string path;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            disableMenuItems();
        }

        private void buttonOpenRom_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open file...";
            ofd.Filter = "nes files (*.nes)|*.nes|All files (*.*)|*.*";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                textBoxFilename.Text = path;

                loadRom();
            }
        }

        private void loadRom()
        {
            enableMenuItems();
        }

        private void enableMenuItems()
        {
            equipmentStatsToolStripMenuItem.Enabled = true;
            magicDataToolStripMenuItem.Enabled = true;
        }

        private void disableMenuItems()
        {
            equipmentStatsToolStripMenuItem.Enabled = false;
            magicDataToolStripMenuItem.Enabled = false;
        }

        #region toolstrip menu items
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openROMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonOpenRom_Click(sender, e);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }

        private void equipmentStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEquipmentStats formEquipmentStats = new FormEquipmentStats(path);
            formEquipmentStats.ShowDialog();
        }

        private void magicDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMagicData formMagicData = new FormMagicData(path);
            formMagicData.ShowDialog();
        }
        #endregion
    }
}
