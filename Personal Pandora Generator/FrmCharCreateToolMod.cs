using System;
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

        //Keeps track of new user possibilities.
        public string[] likes, mottos, traits, skills;

        //Adds new possibilities to the above arrays and to the listbox.
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

            txtNewPossibility.Clear();
            txtNewPossibility.Focus();
        }

        #region Radio Checked Changed Updates Listbox
        //Updates the listbox based on what radio button is selected.
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
        #endregion

        //Removes a selected possibility from the listbox and array.
        private void btnRemovePossibility_Click(object sender, EventArgs e)
        {
            lstNewlyAddedPossibilities.Items.Remove(lstNewlyAddedPossibilities.SelectedItem);

            UpdateArrays();
            txtNewPossibility.Focus();
        }

        //Updates the arrays to reflect what is in the listbox.
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

        //Makes sure the user wants to cancel out of the window and lose all progress.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            int count = 0;

            if (mottos != null)
                count += mottos.Length;
            if (likes != null)
                count += likes.Length;
            if (traits != null)
                count += traits.Length;
            if (skills != null)
                count += skills.Length;

            if (count > 0)
            {
                if (MessageBox.Show("Are you sure you want to continue? All your new possibilities won't be saved.", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    DialogResult = DialogResult.Cancel;
            }
            else
                DialogResult = DialogResult.Cancel;
        }

        //Allows the user to press enter while in the textbox.
        private void txtNewPossibility_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnAddPossibility_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
