using System;
using System.Windows.Forms;

namespace RandChar
{
    /// <summary>
    /// The form for creating template/yourself characters.
    /// </summary>
    public partial class FrmCharacterCreator : Form
    {
        public CharacterCreation characterCreation = new CharacterCreation();

        public FrmCharacterCreator()
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

            gestaltDiceTxt.SetToolTip(this.txtGestaltDice, "Enter your age.");
            rangedAttackTxt.SetToolTip(this.txtRangedAttack, "Includes your will bonus.");
            meleeAttackTxt.SetToolTip(this.txtMeleeAttack, "Includes your will bonus.");
            willBonusTxt.SetToolTip(this.txtWillBonus, "Already included in your RA & MA.");
            baseDefenseTxt.SetToolTip(this.txtBaseDefense, "Your unmodified defense.");
            biteRateTxt.SetToolTip(this.txtBiteRate, "Your overall Bite Rate Percentage.");
            panel1.SetToolTip(this.panel1, "Disabled anytime a type or any skills have been selected.");

            comboGender.SelectedIndex = 0;
            comboType.SelectedIndex = 0;
        }

        //Loads up the type's bonuses and descriptive text as well as applies those bonuses.
        private void typeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstTypeBonus.Items.Clear();
            txtType.Clear();

            characterCreation.TypeAndBonusLoader(comboType.Text, txtType, lstTypeBonus);

            //Sets the bonuses to the textboxes.
            bonusFromIntToTextBox();
        }

        //Sets the bonuses to the textboxes.
        private void bonusFromIntToTextBox()
        {
            txtTiers.Text = characterCreation.TotalTierPoints.ToString();
            txtStrengthStat.Text = characterCreation.StrengthTotal.ToString();
            txtPerceptionStat.Text = characterCreation.PerceptionTotal.ToString();
            txtWillStat.Text = characterCreation.WillTotal.ToString();
            txtEmpathyStat.Text = characterCreation.EmpathyTotal.ToString();
            txtBaseDefense.Text = characterCreation.BaseDefenseStat.ToString();
            txtRangedAttack.Text = characterCreation.RangedAttackStat.ToString();
            txtMeleeAttack.Text = characterCreation.MeleeAttackStat.ToString();
            txtGestaltDice.Text = characterCreation.GestaltStat.ToString();
            txtCU.Text = characterCreation.CUTotal.ToString();
        }

        //Subtracts from the total amount of statpoints left and checks for errors.
        private void StatTxt_TextChanged(object sender, EventArgs e)
        {
            TextBox statTxtChanged = sender as TextBox;
            int totalStatPoints = characterCreation.TotalStatPoints;

            try
            {
                int totalStatPointsUsed = int.Parse(txtStrengthStat.Text) +
                    int.Parse(txtPerceptionStat.Text) + int.Parse(txtWillStat.Text) +
                    int.Parse(txtEmpathyStat.Text);

                //Allows for bonuses to the stats from skills without creating errors.
                if (totalStatPoints - totalStatPointsUsed >= 0 || (panel1.Enabled == false &&
                    comboType.Enabled == false))
                {
                    txtStatPoints.Text = (totalStatPoints - totalStatPointsUsed).ToString();
                    characterCreation.StrengthTotal = int.Parse(txtStrengthStat.Text);
                    characterCreation.PerceptionTotal = int.Parse(txtPerceptionStat.Text);
                    characterCreation.WillTotal = int.Parse(txtWillStat.Text);
                    characterCreation.EmpathyTotal = int.Parse(txtEmpathyStat.Text);


                    txtCU.Text = characterCreation.CUTotal.ToString();
                    txtRangedAttack.Text = characterCreation.RangedAttackStat.ToString();
                    txtMeleeAttack.Text = characterCreation.MeleeAttackStat.ToString();
                    txtBaseDefense.Text = characterCreation.BaseDefenseStat.ToString();
                    txtWillBonus.Text = characterCreation.WillBonusStat.ToString();
                    txtBiteRate.Text = characterCreation.BiteRateStat.ToString();
                    txtHealth.Text = characterCreation.HealthStat.ToString();
                }
                else
                {
                    MessageBox.Show("Can't use more than " + totalStatPoints + " stat points.",
                        "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    statTxtChanged.Text = "0";
                    statTxtChanged.SelectAll();

                    //Stops a bug where negative values occur when bonuses are unapplied.
                    if (comboType.Text == "Child")
                    {
                        txtStrengthStat.Text = "0";
                        txtWillStat.Text = "0";
                        txtPerceptionStat.Text = "0";
                        txtEmpathyStat.Text = "10";

                        comboType.SelectedIndex = 0;
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
            if (comboType.Text != "None")
            {
                try
                {
                    FrmSkillsAdder skillsAdder = new FrmSkillsAdder(skillNames,
                        characterCreation.TotalTierPoints, characterCreation, comboType.Text);

                    //Sends the weight & height for the checkRequirement.
                    characterCreation.WeightTotal = int.Parse(txtWeight.Text);
                    characterCreation.HeightTotal = int.Parse(txtHeightFt.Text);

                    if (characterCreation.WeightTotal == 0 && characterCreation.HeightTotal == 0)
                        throw new Exception("Make sure you entered a weight and a height!");
                    else if (characterCreation.HeightTotal == 0)
                        throw new Exception("Make sure you entered a height!");
                    else if (characterCreation.WeightTotal == 0)
                        throw new Exception("Make sure you entered a weight!");

                    if (skillsAdder.ShowDialog() == DialogResult.OK)
                    {
                        characterCreation.TotalTierPoints = skillsAdder.TotalTierPoints;

                        lstSkillsPicked.Items.Clear();
                        lstSkillsPicked.Items.AddRange(skillsAdder.skillsAdded);

                        //Stops the user from modifying stats when bonuses are applied to them.
                        if (lstSkillsPicked.Items.Count > 0)
                        {
                            comboType.Enabled = false;
                            panel1.Enabled = false;
                        }
                        else
                        {
                            comboType.Enabled = true;
                            panel1.Enabled = true;
                        }

                        //Passes the skills so that their bonuses may be applied.
                        skillNames = new string[lstSkillsPicked.Items.Count];
                        lstSkillsPicked.Items.CopyTo(skillNames, 0);
                        characterCreation.skillBonusApplier(skillNames, comboType.Text, 0);

                        //Sets the bonuses in the textboxes.
                        bonusFromIntToTextBox();
                    }
                    //Updates the characterCreation's dictionary when the DialogResult = Cancel.
                    else if (skillNames != null)
                        characterCreation.skillBonusApplier(skillNames, comboType.Text, 0);

                    //Stops the Stat Points from being displayed as less than 0 when skills/type bonuses are added to 
                    //attributes.
                    if (int.Parse(txtStatPoints.Text) < 0)
                        txtStatPoints.Text = "0";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Make sure you selected a type first.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Changes the listbox selection color to darkgreen.
        private void skillsPickedList_DrawItem(object sender, DrawItemEventArgs e)
        {
            CharacterCreation.ListBox_DrawItem(sender, e);
        }

        //Loads up the skills descriptions.
        private void skillsPickedList_SelectedIndexChanged(object sender, EventArgs e)
        {
            characterCreation.SkillAndBonusDescriptionLoader(lstSkillsPicked.Text, txtType, 
                lstTypeBonus);
        }

        //Calculates and displays the character's movement speeds.
        private void characterMovementSpeeds_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int heightFeet = int.Parse(txtHeightFt.Text);
                int heightInches = int.Parse(txtHeightInches.Text);

                if (heightInches >= 6)
                    heightFeet++;

                lblCrawlingSpeed.Text = "Crawl: " + heightFeet + " = " + heightFeet;
                lblNormalSpeed.Text = "Normal: 2 X " + heightFeet + " = " + heightFeet * 2;
                lblRunningSpeed.Text = "Run: 4 X " + heightFeet + " = " + heightFeet * 4;
                lblSprintingSpeed.Text = "Sprint: 10 X " + heightFeet + " = " + heightFeet * 10;
            }
            catch (FormatException)
            {
                //Stops the program from crashing due to an empty textbox.
                TextBox textChangedTxtBx = sender as TextBox;
                textChangedTxtBx.Text = "0";
                textChangedTxtBx.SelectAll();
            }
        }

        //Tracks the amount of Gestalt Dice a player has.
        private void gestaltDiceTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                characterCreation.GestaltStat = int.Parse(txtGestaltDice.Text);
            }
            catch (FormatException)
            {
                txtGestaltDice.Text = "0";
                txtGestaltDice.SelectAll();
            }
        }
    }
}