using System;
using System.Windows.Forms;

namespace RandChar
{
    /// <summary>
    /// Form for adding skills to template/yourself characters.
    /// </summary>
    public partial class FrmSkillsAdder : Form
    {
        CharacterCreation characterCreation;
        string characterType;

        //Updates the amount of tiers left hypothetically just incase the user hits cancel.
        public int TotalTierPoints;

        /// <summary>
        /// Updates the TotalTierPoints for this form and matches up which skills should be in 
        /// which ListBox.
        /// </summary>
        /// <param name="skillsAdded">The list of skills that were previously applied to the 
        /// character.</param>
        /// <param name="totalTierPoints">The total amount of tier points.</param>
        /// <param name="charactercreator">Pass a reference for the same CharacterCreation
        /// object that is being used for the character.</param>
        public FrmSkillsAdder(string[] skillsAdded, int totalTierPoints, 
            CharacterCreation characterCreation, string characterType)
        {
            characterCreation.skillsAdder = this;

            InitializeComponent();

            this.characterCreation = characterCreation;
            this.characterType = characterType;

            txtTiers.Text = totalTierPoints.ToString();
            TotalTierPoints = totalTierPoints;

            if (skillsAdded != null)
            {
                lstSkillsPicked.Items.AddRange(skillsAdded);

                foreach (string item in skillsAdded)
                {
                    for (int i = 0; i < lstSkills.Items.Count; i++)
                    {
                        if (item == lstSkills.Items[i].ToString())
                            lstSkills.Items.Remove(item);
                    }
                }
            }
        }

        //Changes the listbox selection color to darkgreen.
        private void skillsList_DrawItem(object sender, DrawItemEventArgs e)
        {
            CharacterCreation.ListBox_DrawItem(sender, e);
        }

        //Loads a selected skill's descriptions.
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBoxSelected = sender as ListBox;

            if (listBoxSelected.Text != "")
                characterCreation.SkillAndBonusDescriptionLoader(listBoxSelected.Text, txtSkill,
                    lstSkillBonus);
        }

        //Adds the skill's bonuses internally and for the user to see.
        private void addSkillBtn_Click(object sender, EventArgs e)
        {
            string selectedSkill = lstSkills.Text;

            if (selectedSkill != "")
            {
                int tierLevel = characterCreation.TierExtracter(selectedSkill);

                //Checks that the skill's requirements are met.
                    string[] selectedSkillParam = new string[1];
                    selectedSkillParam[0] = selectedSkill;
                    bool meetsRequirements = characterCreation.skillBonusApplier(selectedSkillParam, characterType, tierLevel);

                    //If the requirements are met, the skill is added.
                    if (meetsRequirements)
                    {
                        lstSkillsPicked.Items.Add(selectedSkill);
                        lstSkills.Items.Remove(selectedSkill);
                        lstSkillsPicked.SelectedItem = selectedSkill;

                        TotalTierPoints -= tierLevel;
                        txtTiers.Text = TotalTierPoints.ToString();

                        skillsAdded = new string[lstSkillsPicked.Items.Count];
                        lstSkillsPicked.Items.CopyTo(skillsAdded, 0);
                    }
            }
        }

        //Allows the CharacterCreator form to add the chosen skills to its listbox.
        public string[] skillsAdded;
        private void okBtn_Click(object sender, EventArgs e)
        {
            skillsAdded = new string[lstSkillsPicked.Items.Count];
            lstSkillsPicked.Items.CopyTo(skillsAdded, 0);
        }

        //Removes the selected skill.
        private void removeSkillBtn_Click(object sender, EventArgs e)
        {
            string selectedSkill = lstSkillsPicked.Text;

            if (selectedSkill != "")
            {
                int tierLevel = characterCreation.TierExtracter(selectedSkill);

                //Removes the skill.
                lstSkillsPicked.Items.Remove(selectedSkill);
                lstSkills.Items.Add(selectedSkill);
                lstSkillsPicked.SelectedItem = selectedSkill;
                characterCreation.RemoveSkills(selectedSkill);

                TotalTierPoints += tierLevel;

                //All skills are removed if due to how skills interact with each other, removing one
                //would cause the Total Amount of Tier Points to drop below 0.
                if (TotalTierPoints < 0)
                {
                    RemoveAllSkills();
                }

                txtTiers.Text = TotalTierPoints.ToString();
            }
        }

        //Removes all the skills a user has put into the picked list box.
        private void RemoveAllSkills()
        {
            string[] allSkills = new string[lstSkillsPicked.Items.Count];
            lstSkillsPicked.Items.CopyTo(allSkills, 0);

            foreach (string skill in allSkills)
            {
                lstSkillsPicked.Items.Remove(skill);
                lstSkills.Items.Add(skill);
                lstSkillsPicked.SelectedItem = skill;
                characterCreation.RemoveSkills(skill);

                int tierLevel = characterCreation.TierExtracter(skill);

                TotalTierPoints += tierLevel;
                txtTiers.Text = TotalTierPoints.ToString();
            }
        }
    }
}