using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileStringComparison;

namespace RandChar
{
    public partial class FrmCharCreateToolMod : Form
    {
        public FrmCharCreateToolMod()
        {
            InitializeComponent();
        }

        public string[] likes, mottos, traits, skills;

        private void btnAddPossibility_Click(object sender, EventArgs e)
        {
            string fileName;

            if (radLikes.Checked)
                fileName = "likes";
            else if (radMottos.Checked)
                fileName = "mottos";
            else if (radPersonality.Checked)
                fileName = "traits";
            else
                fileName = "skillsTool";

            if (DuplicateSearch.DuplicateCheck(txtNewPossibility.Text, fileName))
                MessageBox.Show("\"" + txtNewPossibility.Text + "\" has been found in \"" + fileName + ".txt\"", "Duplication Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                lstNewlyAddedPossibilities.Items.Add(txtNewPossibility.Text);
                UpdateArrays();
            }
        }

        private void radLikes_CheckedChanged(object sender, EventArgs e)
        {
            lstNewlyAddedPossibilities.Items.Clear();
            if (radLikes.Checked && likes != null)
                lstNewlyAddedPossibilities.Items.AddRange(likes);
        }

        private void radPersonality_CheckedChanged(object sender, EventArgs e)
        {
            lstNewlyAddedPossibilities.Items.Clear();
            if (radPersonality.Checked && traits != null)
                lstNewlyAddedPossibilities.Items.AddRange(traits);
        }

        private void radMottos_CheckedChanged(object sender, EventArgs e)
        {
            lstNewlyAddedPossibilities.Items.Clear();
            if (radMottos.Checked && mottos != null)
                lstNewlyAddedPossibilities.Items.AddRange(mottos);
        }

        private void radSkills_CheckedChanged(object sender, EventArgs e)
        {
            lstNewlyAddedPossibilities.Items.Clear();
            if (radSkills.Checked && skills != null)
                lstNewlyAddedPossibilities.Items.AddRange(skills);
        }

        private void btnRemovePossibility_Click(object sender, EventArgs e)
        {
            lstNewlyAddedPossibilities.Items.Remove(lstNewlyAddedPossibilities.SelectedItem);

            UpdateArrays();
        }

        private void UpdateArrays()
        {
            if (radLikes.Checked)
            {
                likes = new string[lstNewlyAddedPossibilities.Items.Count];
                lstNewlyAddedPossibilities.Items.CopyTo(likes, 0);
            }
            else if (radMottos.Checked)
            {
                mottos = new string[lstNewlyAddedPossibilities.Items.Count];
                lstNewlyAddedPossibilities.Items.CopyTo(mottos, 0);
            }
            else if (radPersonality.Checked)
            {
                traits = new string[lstNewlyAddedPossibilities.Items.Count];
                lstNewlyAddedPossibilities.Items.CopyTo(traits, 0);
            }
            else
            {
                skills = new string[lstNewlyAddedPossibilities.Items.Count];
                lstNewlyAddedPossibilities.Items.CopyTo(skills, 0);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (mottos != null || likes != null || skills != null || traits != null)
            {
                if (MessageBox.Show("Are you sure you want to continue? All your new possibilities won't be saved.", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    DialogResult = DialogResult.Cancel;
            }
            else
                DialogResult = DialogResult.Cancel;
        }
    }
}
