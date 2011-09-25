using System;
using System.Windows.Forms;

namespace RandChar
{
    public partial class CharacterCreator : Form
    {
        public CharacterCreation characterCreation = new CharacterCreation();

        public CharacterCreator()
        {
            InitializeComponent();
        }

        //Stops anything other than number symbols to be entered into textboxes.
        private void numberOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            CharacterCreation.NumbersOnly_KeyPress(sender, e);
        }
        
        //Sets combobox to have a default value and the tooltips(might be removed).
        private void CharacterCreator_Load(object sender, EventArgs e)
        {
            ToolTip gestaltDiceTxt = new ToolTip();
            ToolTip rangedAttackTxt = new ToolTip();
            ToolTip meleeAttackTxt = new ToolTip();
            ToolTip willBonusTxt = new ToolTip();
            ToolTip baseDefenseTxt = new ToolTip();
            ToolTip biteRateTxt = new ToolTip();
            ToolTip panel1 = new ToolTip();

            gestaltDiceTxt.SetToolTip(this.gestaltDiceTxt, "Enter your age.");
            rangedAttackTxt.SetToolTip(this.rangedAttackTxt, "Includes your will bonus.");
            meleeAttackTxt.SetToolTip(this.meleeAttackTxt, "Includes your will bonus.");
            willBonusTxt.SetToolTip(this.willBonusTxt, "Already included in your RA & MA.");
            baseDefenseTxt.SetToolTip(this.baseDefenseTxt, "Your unmodified defense.");
            biteRateTxt.SetToolTip(this.biteRateTxt, "Your overall Bite Rate Percentage.");
            panel1.SetToolTip(this.panel1, "Disabled anytime a type or any skills have been selected.");

            genderCombo.SelectedIndex = 0;
            typeCombo.SelectedIndex = 0;
        }

        //Loads up the type's bonuses and descriptive text as well as applies those bonuses.
        private void typeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            typeBonusList.Items.Clear();
            typeText.Clear();

            characterCreation.TypeAndBonusLoader(typeCombo.Text, typeText, typeBonusList);

            //Stops the user from changing stats after bonuses have been applied.
            if (typeCombo.SelectedIndex != 0)
            {
                panel1.Enabled = false;
                addRemoveSkillBtn.Enabled = true;
            }
            else if (!(skillsPickedList.Items.Count > 0))
            {
                panel1.Enabled = true;
                addRemoveSkillBtn.Enabled = false; //Stops skills from being added without a type.
            }
            //Sets the bonuses to the textboxes.
            bonusFromIntToTextBox();
        }

        //Sets the bonuses to the textboxes.
        private void bonusFromIntToTextBox()
        {
            tiersTxt.Text = characterCreation.TotalTierPoints.ToString();
            strengthStatTxt.Text = characterCreation.StrengthTotal.ToString();
            perceptionStatTxt.Text = characterCreation.PerceptionTotal.ToString();
            willStatTxt.Text = characterCreation.WillTotal.ToString();
            empathyStatTxt.Text = characterCreation.EmpathyTotal.ToString();
            baseDefenseTxt.Text = characterCreation.BaseDefenseStat.ToString();
            rangedAttackTxt.Text = characterCreation.RangedAttackStat.ToString();
            meleeAttackTxt.Text = characterCreation.MeleeAttackStat.ToString();
            gestaltDiceTxt.Text = characterCreation.GestaltStat.ToString();
        }

        //Subtracts from the total amount of statpoints left and checks for errors.
        private void StatTxt_TextChanged(object sender, EventArgs e)
        {
            TextBox statTxtChanged = sender as TextBox;
            int totalStatPoints = characterCreation.TotalStatPoints;

            try
            {
                int totalStatPointsUsed = int.Parse(strengthStatTxt.Text) +
                    int.Parse(perceptionStatTxt.Text) + int.Parse(willStatTxt.Text) +
                    int.Parse(empathyStatTxt.Text);

                //Allows for bonuses to the stats from skills without creating errors.
                if (totalStatPoints - totalStatPointsUsed >= 0 || (panel1.Enabled == false &&
                    typeCombo.Enabled == false))
                {
                    statPointsTxt.Text = (totalStatPoints - totalStatPointsUsed).ToString();
                    characterCreation.StrengthTotal = int.Parse(strengthStatTxt.Text);
                    characterCreation.PerceptionTotal = int.Parse(perceptionStatTxt.Text);
                    characterCreation.WillTotal = int.Parse(willStatTxt.Text);
                    characterCreation.EmpathyTotal = int.Parse(empathyStatTxt.Text);


                    CUTxt.Text = characterCreation.CUTotal.ToString();
                    rangedAttackTxt.Text = characterCreation.RangedAttackStat.ToString();
                    meleeAttackTxt.Text = characterCreation.MeleeAttackStat.ToString();
                    baseDefenseTxt.Text = characterCreation.BaseDefenseStat.ToString();
                    willBonusTxt.Text = characterCreation.WillBonusStat.ToString();
                    biteRateTxt.Text = characterCreation.BiteRateStat.ToString();
                    healthTxt.Text = characterCreation.HealthStat.ToString();
                }
                else
                {
                    MessageBox.Show("Can't use more than " + totalStatPoints + " stat points.",
                        "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    statTxtChanged.Text = "0";
                    statTxtChanged.SelectAll();

                    //Stops a bug where negative values occur when bonuses are unapplied.
                    if (typeCombo.Text == "Child")
                    {
                        strengthStatTxt.Text = "0";
                        willStatTxt.Text = "0";
                        perceptionStatTxt.Text = "0";
                        empathyStatTxt.Text = "10";

                        typeCombo.SelectedIndex = 0;
                    }
                }
            }
            //Stops the program from crashing due to an empty textbox.
            catch (FormatException)
            {
                statTxtChanged.Text = "0";
                statTxtChanged.SelectAll();
            }
        }

        //Opens a new form for users to pick skills.
        string[] skillNames = null; //Keeps track of the skills added.
        private void addRemoveSkillBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SkillsAdder skillsAdder = new SkillsAdder(skillNames, 
                    characterCreation.TotalTierPoints, characterCreation, typeCombo.Text);

                //Sends the weight for the checkRequirement.
                characterCreation.WeightTotal = int.Parse(weightTxt.Text);
                if (characterCreation.WeightTotal == 0)
                    throw new Exception("Make sure you entered a weight");

                if (skillsAdder.ShowDialog() == DialogResult.OK)
                {
                    characterCreation.TotalTierPoints = skillsAdder.TotalTierPoints;

                    skillsPickedList.Items.Clear();
                    skillsPickedList.Items.AddRange(skillsAdder.skillsAdded);

                    //Stops the user from modifying stats when bonuses are applied to them.
                    if (skillsPickedList.Items.Count > 0)
                        typeCombo.Enabled = false;
                    else
                        typeCombo.Enabled = true;

                    //Passes the skills so that their bonuses may be applied.
                    skillNames = new string[skillsPickedList.Items.Count];
                    skillsPickedList.Items.CopyTo(skillNames, 0);
                    characterCreation.skillBonusApplier(skillNames, typeCombo.Text, 0);

                    //Sets the bonuses in the textboxes.
                    bonusFromIntToTextBox();
                }
                //Updates the characterCreation's dictionary when the DialogResult = Cancel.
                else if (skillNames != null) 
                    characterCreation.skillBonusApplier(skillNames, typeCombo.Text, 0);

                //Stops the Stat Points from being displayed as less than 0 when skills/type bonuses are added to attributes.
                if (int.Parse(statPointsTxt.Text) < 0)
                    statPointsTxt.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Changes the listbox selection color to darkgreen.
        private void skillsPickedList_DrawItem(object sender, DrawItemEventArgs e)
        {
            CharacterCreation.ListBox_DrawItem(sender, e);
        }

        //Loads up the skills descriptions.
        private void skillsPickedList_SelectedIndexChanged(object sender, EventArgs e)
        {
            characterCreation.SkillAndBonusDescriptionLoader(skillsPickedList.Text, typeText, 
                typeBonusList);
        }

        //Calculates and displays the character's movement speeds.
        private void characterMovementSpeeds_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int heightFeet = int.Parse(heightFeetTxt.Text);
                int heightInches = int.Parse(heightInchesTxt.Text);

                if (heightInches >= 6)
                    heightFeet++;

                crawlingSpeedLbl.Text = "Crawl: " + heightFeet + " = " + heightFeet;
                normalSpeedLbl.Text = "Normal: 2 X " + heightFeet + " = " + heightFeet * 2;
                runningSpeedLbl.Text = "Run: 4 X " + heightFeet + " = " + heightFeet * 4;
                sprintingSpeedLbl.Text = "Sprint: 10 X " + heightFeet + " = " + heightFeet * 10;
            }
            catch (FormatException)
            {
                //Stops the program from crashing due to an empty textbox.
                TextBox textChangedTxtBx = sender as TextBox;
                textChangedTxtBx.Text = "0";
            }
        }

        //Tracks the amount of Gestalt Dice a player has.
        private void gestaltDiceTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                characterCreation.GestaltStat = int.Parse(gestaltDiceTxt.Text);
            }
            catch (FormatException)
            {
                gestaltDiceTxt.Text = "0";
                gestaltDiceTxt.SelectAll();
            }
        }
    }
}