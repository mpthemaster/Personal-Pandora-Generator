using System;
using System.Windows.Forms;

namespace RandChar
{
    public partial class SkillsAdder : Form
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
        public SkillsAdder(string[] skillsAdded, int totalTierPoints, 
            CharacterCreation characterCreation, string characterType)
        {
            characterCreation.skillsAdder = this;

            InitializeComponent();

            this.characterCreation = characterCreation;
            this.characterType = characterType;

            tiersTxt.Text = totalTierPoints.ToString();
            TotalTierPoints = totalTierPoints;

            if (skillsAdded != null)
            {
                skillsPickedList.Items.AddRange(skillsAdded);

                foreach (string item in skillsAdded)
                {
                    for (int i = 0; i < skillsList.Items.Count; i++)
                    {
                        if (item == skillsList.Items[i].ToString())
                            skillsList.Items.Remove(item);
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
                characterCreation.SkillAndBonusDescriptionLoader(listBoxSelected.Text, skillTxt,
                    skillBonusList);
        }

        //Adds the skill's bonuses internally and for the user to see.
        private void addSkillBtn_Click(object sender, EventArgs e)
        {
            string selectedSkill = skillsList.Text;

            if (selectedSkill != "")
            {
                //Extracts the tier level.
                char[] tierNumber = new char[1];
                selectedSkill.CopyTo(selectedSkill.Length - 2, tierNumber,
                    0, 1);
                int tierLevel = int.Parse(tierNumber[0].ToString());

                //Checks that the skill's requirements are met.
                    string[] selectedSkillParam = new string[1];
                    selectedSkillParam[0] = selectedSkill;
                    bool meetsRequirements = characterCreation.skillBonusApplier(selectedSkillParam, characterType, tierLevel);

                    //If the requirements are met, the skill is added.
                    if (meetsRequirements)
                    {
                        skillsPickedList.Items.Add(selectedSkill);
                        skillsList.Items.Remove(selectedSkill);
                        skillsPickedList.SelectedItem = selectedSkill;

                        TotalTierPoints -= tierLevel;
                        tiersTxt.Text = TotalTierPoints.ToString();

                        skillsAdded = new string[skillsPickedList.Items.Count];
                        skillsPickedList.Items.CopyTo(skillsAdded, 0);
                    }
            }
        }

        //Allows the CharacterCreator form to add the chosen skills to its listbox.
        public string[] skillsAdded;
        private void okBtn_Click(object sender, EventArgs e)
        {
            skillsAdded = new string[skillsPickedList.Items.Count];
            skillsPickedList.Items.CopyTo(skillsAdded, 0);
        }

        //Removes the selected skill.
        private void removeSkillBtn_Click(object sender, EventArgs e)
        {
            string selectedSkill = skillsPickedList.Text;

            if (selectedSkill != "")
            {
                //Extracts the tier level.
                char[] tierNumber = new char[1];
                selectedSkill.CopyTo(selectedSkill.Length - 2, tierNumber,
                    0, 1);
                int tierLevel = int.Parse(tierNumber[0].ToString());

                //Removes the skill.
                skillsPickedList.Items.Remove(selectedSkill);
                skillsList.Items.Add(selectedSkill);
                skillsPickedList.SelectedItem = selectedSkill;
                characterCreation.RemoveSkills(selectedSkill);

                TotalTierPoints += tierLevel;

                //All skills are removed if due to how skills interact with each other, removing one
                //would cause the Total Amount of Tier Points to drop below 0.
                if (TotalTierPoints < 0)
                {
                    RemoveAllSkills();
                }

                tiersTxt.Text = TotalTierPoints.ToString();
            }
        }

        //Removes all the skills a user has put into the picked list box.
        private void RemoveAllSkills()
        {
            string[] allSkills = new string[skillsPickedList.Items.Count];
            skillsPickedList.Items.CopyTo(allSkills, 0);

            foreach (string skill in allSkills)
            {
                skillsPickedList.Items.Remove(skill);
                skillsList.Items.Add(skill);
                skillsPickedList.SelectedItem = skill;
                characterCreation.RemoveSkills(skill);

                //Extracts the tier level.
                char[] tierNumber = new char[1];
                skill.CopyTo(skill.Length - 2, tierNumber,
                    0, 1);
                int tierLevel = int.Parse(tierNumber[0].ToString());

                TotalTierPoints += tierLevel;
                tiersTxt.Text = TotalTierPoints.ToString();
            }
        }
    }
}