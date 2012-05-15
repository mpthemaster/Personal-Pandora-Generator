using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace RandChar
{
    /// <summary>
    /// Takes care of the main mechanics of making a character as well as some misc.
    /// </summary>
    public class CharacterCreation
    {
        public FrmSkillsAdder skillsAdder;

        /* Holds the information of whether or not stats have changed and how much they have 
         * changed by due to type bonuses. This allows the changes to be undone when another type
         * is selected.*/
        private bool baseDefenseLimitDisabled, tierIsLimited, skillTierLevelIsReducedByBoStaff, skillTierLevelIsReducedByBrawler, 
            skillTierLevelIsReducedByDefend, skillTierLevelIsReducedBySniperOrMarksman;
        private int tierLimit, skillTierLevelAmountReducedByBoStaff, skillTierLevelAmountReducedByBrawler, skillTierLevelAmountReducedByDefend,
            skillTierLevelAmountReducedBySniperOrMarksman,skillBonusToMeleeAttack, skillBonusToRangedAttack, skillBonusToDefense, 
            skillBonusToHealth, skillBonusToCU;

        //Holds the information of what a character's stats currently are (including the 
        //properties past the fields).
        public int RangedAttackStat, MeleeAttackStat, WillBonusStat, HealthStat, BiteRateStat, 
            WeightTotal, HeightTotal, BaseDefenseStat, TotalStatPoints = 120, TotalTierPoints = 5, GestaltStat;
        public int CUTotal { get; private set; } //CharacterCreator needs to be able to access
                                                 //this, but shouldn't be changing it since it is
                                                 //calculated here.

        //These properties must have the autoStatCalculator() executed everytime they are set so
        //that the values calculated from them are updated.
        private int strengthTotal;
        public int StrengthTotal
        {
            get { return strengthTotal; }

            set 
            { 
                strengthTotal = value;
                autoStatCalculator();

                CUTotal = strengthTotal / 5 + skillBonusToCU; //One such calculated value that only Strength modifies

                if (CUTotal < 3)
                    CUTotal = 3;
                else if (CUTotal > 10)
                    CUTotal = 10;
            }
        }

        private int perceptionTotal;
        public int PerceptionTotal
        {
            get { return perceptionTotal; }

            set { perceptionTotal = value; autoStatCalculator(); }
        }

        private int willTotal;
        public int WillTotal
        {
            get { return willTotal; }

            set { willTotal = value; autoStatCalculator(); }
        }

        private int empathyTotal;
        public int EmpathyTotal
        {
            get { return empathyTotal; }

            set { empathyTotal = value; autoStatCalculator(); }
        }
 
        /// <summary>
        /// Loads up a type's bonuses as well as descriptive text and applies those bonuses. 
        /// The format of the saved information for types is similiar, but still different enough 
        /// from skills to warrent a new method. 
        /// </summary>
        /// <param name="typeName">The name of the picked type.</param>
        /// <param name="typeText">The RichTextBox where the type description is going to be placed</param>
        /// <param name="typeBonusList">The ListBox where the bonuses are to be listed.</param>
        public void TypeAndBonusLoader(string typeName, RichTextBox typeText, ListBox typeBonusList)
        {
            string typeInformation;
            StreamReader readingTypes = new StreamReader("../../Types.txt");

            if (typeBonuses != null)
                resetTypeBonuses(); //Undoes any previous type bonuses.

            do
            {
                typeInformation = readingTypes.ReadLine();

                //If the line contains the user-selected type...read and load the rest of the information.
                if (typeInformation == typeName && typeInformation.IndexOf(typeName) == 0)
                {
                    typeText.Text = typeInformation.ToUpper();

                    //Formats the name of the skill.
                    typeText.Select(0, typeName.Length);
                    typeText.SelectionAlignment = HorizontalAlignment.Center;
                    typeText.SelectionColor = Color.Red;

                    //Resets the color and alignment to normal
                    typeText.AppendText("\n");
                    typeText.SelectionAlignment = HorizontalAlignment.Left;
                    typeText.SelectionColor = Color.LimeGreen;

                    typeText.AppendText("\t" + readingTypes.ReadLine());

                    //Loads the list of bonuses.
                    int numberOfBonuses = int.Parse(readingTypes.ReadLine());
                    typeBonusList.Items.Add("Bonuses:");

                    for (int i = 0; i < numberOfBonuses; i++)
                    {
                        typeBonusList.Items.Add(readingTypes.ReadLine());
                    }
                    setTypeBonuses(readingTypes, typeBonusList, typeName); //Applies the type's bonuses.
                }
            } while (!readingTypes.EndOfStream && typeInformation != typeName);

            readingTypes.Close();
        }

        //Resets the bonuses given by a type when the type changes.
        private void resetTypeBonuses()
        {
            foreach (string typeBonus in typeBonusesKeyList)
            {
                if (typeBonus == "Empathy")
                {
                    TotalStatPoints -= typeBonuses[typeBonus];
                    EmpathyTotal -= typeBonuses[typeBonus];
                }
                else if (typeBonus == "Perception")
                {
                    TotalStatPoints -= typeBonuses[typeBonus];
                    PerceptionTotal -= typeBonuses[typeBonus];
                }
                else if (typeBonus == "Strength")
                {
                    TotalStatPoints -= typeBonuses[typeBonus];
                    StrengthTotal -= typeBonuses[typeBonus];
                }
                else if (typeBonus == "Will")
                {
                    TotalStatPoints -= typeBonuses[typeBonus];
                    WillTotal -= typeBonuses[typeBonus];
                }
                else if (typeBonus == "Tier")
                {
                    TotalTierPoints -= typeBonuses[typeBonus];
                }
                else if (typeBonus == "TotalStatPoints")
                {
                    TotalStatPoints -= typeBonuses[typeBonus];
                }
                else if (typeBonus == "Tier Limit")
                {
                    tierLimit = 0;
                    tierIsLimited = false;
                }
            }
        }

        //Applies the bonuses given by a type when the type changes.
        //A change is recorded as happening and how much it changed is also recorded.
        Dictionary<string, int> typeBonuses;
        string[] typeBonusesKeyList;
        private void setTypeBonuses(StreamReader readingTypes, ListBox typeBonusList, string typeName)
        {
            int numberOfModifications = int.Parse(readingTypes.ReadLine());
            typeBonuses = new Dictionary<string, int>();
            typeBonusesKeyList = new string[numberOfModifications];

            for (int i = 0; i < numberOfModifications; i++)
            {
                string checkModification = readingTypes.ReadLine();
                typeBonusesKeyList[i] = checkModification;
                typeBonuses.Add(checkModification, 0);
               
                if (checkModification == "Empathy")
                {
                    typeBonuses[checkModification] = int.Parse(readingTypes.ReadLine());
                    TotalStatPoints += typeBonuses[checkModification];
                    EmpathyTotal += typeBonuses[checkModification];
                }
                else if (checkModification == "Perception")
                {
                    typeBonuses[checkModification] = int.Parse(readingTypes.ReadLine());
                    TotalStatPoints += typeBonuses[checkModification];
                    PerceptionTotal += typeBonuses[checkModification];
                }
                else if (checkModification == "Strength")
                {
                    typeBonuses[checkModification] = int.Parse(readingTypes.ReadLine());
                    TotalStatPoints += typeBonuses[checkModification];
                    StrengthTotal += typeBonuses[checkModification];
                }
                else if (checkModification == "Will")
                {
                    typeBonuses[checkModification] = int.Parse(readingTypes.ReadLine());
                    TotalStatPoints += typeBonuses[checkModification];
                    WillTotal += typeBonuses[checkModification];
                }
                else if (checkModification == "Tier")
                {
                    typeBonuses[checkModification] = int.Parse(readingTypes.ReadLine());
                    TotalTierPoints += typeBonuses[checkModification];
                }
                else if (checkModification == "TotalStatPoints")
                {
                    typeBonuses[checkModification] = int.Parse(readingTypes.ReadLine());
                    TotalStatPoints += typeBonuses[checkModification];
                }
                else if (checkModification == "Tier Limit")
                {
                    tierLimit = int.Parse(readingTypes.ReadLine());
                    tierIsLimited = true;
                }
                else if (checkModification == "SwitchTierForTraits")
                {
                    if (MessageBox.Show("Would you like to forgo a bonus of 1 tier for handyman type traits " + 
                        "instead?", "Choose a Bonus!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == 
                        DialogResult.Yes)
                    {
                        if (typeName == "Civilian")
                        {
                            TotalTierPoints -= typeBonuses["Tier"];
                            typeBonuses.Remove("Tier");
                            
                            int arrayLocation = 0;
                            foreach (string tierBonus in typeBonusesKeyList)
                            {
                                if (tierBonus == "Tier")
                                    typeBonusesKeyList[arrayLocation] = null;

                                arrayLocation++;
                            }

                            typeBonusList.Items.Clear();
                            typeBonusList.Items.Add("Only allows for skills with Tier 4 and lower.");
                            typeBonusList.Items.Add("When performing a check that relates to handyman");
                            typeBonusList.Items.Add("work:");
                            typeBonusList.Items.Add(" +15 to Perception.");
                            typeBonusList.Items.Add("+25 to the success of Equipment Manufacture");
                            typeBonusList.Items.Add("Missions.");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Allows only numbers to be entered (for textboxes that have this method).
        /// </summary>
        /// <param name="sender">The textbox sending the event.</param>
        /// <param name="e">The key pressed.</param>
        public static void NumbersOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace
                (e.KeyChar) || char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        /// <summary>
        /// Changes the listbox selection color to dark green.
        /// </summary>
        /// <param name="sender">The listbox sending the event.</param>
        /// <param name="e"></param>
        public static void ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                ListBox listBox = sender as ListBox;

                //if the item state is selected then change the back color
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State ^
                        DrawItemState.Selected, e.ForeColor, Color.DarkGreen);

                // Draw the background of the ListBox control for each item.
                e.DrawBackground();

                // Draw the current item text
                e.Graphics.DrawString(listBox.Items[e.Index].ToString(), e.Font,
                    Brushes.YellowGreen, e.Bounds, StringFormat.GenericDefault);

                // If the ListBox has focus, draw a focus rectangle around the selected item.
                if (listBox.SelectedIndex != -1)
                    e.DrawFocusRectangle();
                
            }
            catch (ArgumentOutOfRangeException)
            {
                //Stops the program from crashing when a listbox is clicked on with no items.
            }
        }

        /// <summary>
        /// Loads up the skill's descriptive/bonus text.
        /// </summary>
        /// <param name="skillsName">The name of the skill.</param>
        /// <param name="skillTxt">The RichTextBox to put the skill's description into.</param>
        /// <param name="skillBonusList">The ListBox to put the skill's bonus description into</param>
        public void SkillAndBonusDescriptionLoader(string skillsName, RichTextBox skillTxt, 
            ListBox skillBonusList)
        {
            //Some clean-up.
            skillBonusList.Items.Clear();
            skillTxt.Clear();

            string skillInformation;
            StreamReader readingSkills = new StreamReader("../../Skills.txt");

            do
            {
                skillInformation = readingSkills.ReadLine();

                //If the line contains the user-selected skill...load up the descriptions of that 
                //skill.
                if (skillInformation == skillsName && skillInformation.IndexOf(skillsName) == 0)
                {
                    skillTxt.Text = skillInformation.ToUpper();

                    //Formats the name of the skill.
                    skillTxt.Select(0, skillsName.Length);
                    skillTxt.SelectionAlignment = HorizontalAlignment.Center;
                    skillTxt.SelectionColor = Color.Red;

                    //Resets the color and alignment to normal
                    skillTxt.AppendText("\n");
                    skillTxt.SelectionAlignment = HorizontalAlignment.Left;
                    skillTxt.SelectionColor = Color.LimeGreen;

                    skillTxt.AppendText("\t" + readingSkills.ReadLine());

                    //Displays the bonuses.
                    int numberOfBonuses = int.Parse(readingSkills.ReadLine());
                    skillBonusList.Items.Add("Bonuses:");

                    for (int i = 0; i < numberOfBonuses; i++)
                    {
                        skillBonusList.Items.Add(readingSkills.ReadLine());
                    }

                    numberOfBonuses = int.Parse(readingSkills.ReadLine());
                    skillBonusList.Items.Add("");
                    skillBonusList.Items.Add("Requirements:");

                    //Records what exceptions to a skill's requirements that there are.
                    string[] skillExceptions = null;
                    for (int i = 0; i < numberOfBonuses; i++)
                    {
                        string skillRequirements = readingSkills.ReadLine();

                        //Exceptions are displayed a different way.
                        if (skillRequirements != "Exceptions")
                            skillBonusList.Items.Add(skillRequirements + " - " +
                                readingSkills.ReadLine());
                        else
                        {
                            int numberOfExceptions = int.Parse(readingSkills.ReadLine());

                            skillExceptions = new string[numberOfExceptions + 2];
                            skillExceptions[0] = "";
                            skillExceptions[1] = "Exceptions to the Requirements for:";

                            for (int count = 2; count < numberOfExceptions + 2; count++)
                            {
                                skillExceptions[count] = readingSkills.ReadLine();
                            }
                        }
                    }
                    if (skillExceptions != null) //If there are skill exceptions, add to ListBox
                        skillBonusList.Items.AddRange(skillExceptions);
                }
            } while (!readingSkills.EndOfStream && skillInformation != skillsName);

            readingSkills.Close();
        }

        /// <summary>
        ///  Checks that the requirements of skills are met and applies the bonuses of skills.
        /// </summary>
        /// <param name="pickedSkillsList">The list of skills to be applied to the character.</param>
        /// <param name="characterType">The character's type (for exception purposes).</param>
        /// <param name="tierLevel">The skill's tier level.</param>
        /// <returns>Returns true if the requirement check passed.</returns>
        public bool skillBonusApplier(string[] pickedSkillsList, string characterType, int tierLevel)
        {
            bool passedRequirements = false;

            //Gets the streamreader to the right place in the text file for each skill the user has
            //selected.
            foreach (string skillName in pickedSkillsList)
            {
                string skillBonuses, skillBonuses2 = "";
                StreamReader readingSkillBonuses = new StreamReader("../../Skills.txt");

                do
                {
                    skillBonuses = readingSkillBonuses.ReadLine();

                    if (skillBonuses == skillName && skillBonuses.IndexOf(skillName) == 0)
                    {
                        readingSkillBonuses.ReadLine();
                        skillBonuses2 = readingSkillBonuses.ReadLine();

                        for (int i = 0; i < int.Parse(skillBonuses2); i++)
                        {
                            readingSkillBonuses.ReadLine();
                        }

                        passedRequirements = checkSkillRequirements(readingSkillBonuses, 
                            skillName, characterType);

                        //If the requirements aren't met or the user doesn't have enough tier 
                        //points for that skill...
                        if (!passedRequirements || skillsAdder.TotalTierPoints < tierLevel)
                            return false;

                        //Applies the skills' bonuses.
                        setSkillBonuses(readingSkillBonuses, skillName);
                    }
                } while (!readingSkillBonuses.EndOfStream && skillBonuses != skillName);

                readingSkillBonuses.Close();
            }
            return passedRequirements;
        }

        //Makes sure that the character meets the skill's requirements.
        private bool checkSkillRequirements(StreamReader readingSkillRequirements,
            string skillName, string characterType)
        {
            int tierLevel = TierExtracter(skillName);

            //If there is no extra limit on how many tiers a skill may have or if there is a limit,
            //but the tier limit is greater than or equal to the tier level of the skill level of 
            //the skill.
            if (!tierIsLimited || (tierIsLimited && tierLimit >= tierLevel))
            {
                int numberOfRequirements = int.Parse(readingSkillRequirements.ReadLine());

                for (int i = 0; i < numberOfRequirements; i++)
                {
                    string skillRequirement = readingSkillRequirements.ReadLine();

                    if (skillRequirement == "Strength")
                    {
                        if (StrengthTotal < int.Parse(readingSkillRequirements.ReadLine()))
                        {
                            warningMessages("Your Strength isn't high enough to take this skill.");
                            return false;
                        }
                    }
                    else if (skillRequirement == "Perception")
                    {
                        if (PerceptionTotal < int.Parse(readingSkillRequirements.ReadLine()))
                        {
                            warningMessages("Your Perception isn't high enough to take this skill.");
                            return false;
                        }
                    }
                    else if (skillRequirement == "Weight Less Than")
                    {
                        if (WeightTotal > int.Parse(readingSkillRequirements.ReadLine()))
                        {
                            warningMessages("Your Weight isn't low enough to take this skill.");
                            return false;
                        }
                    }
                    else if (skillRequirement == "Weight More Than")
                    {
                        if (WeightTotal < int.Parse(readingSkillRequirements.ReadLine()))
                        {
                            warningMessages("Your Weight isn't high enough to take this skill.");
                            return false;
                        }
                    }
                    else if (skillRequirement == "Height")
                    {
                        if (HeightTotal >= int.Parse(readingSkillRequirements.ReadLine()))
                        {
                            warningMessages("Your Height isn't low enough to take this skill.");
                            return false;
                        }
                    }
                    else if (skillRequirement == "Will")
                    {
                        if (WillTotal < int.Parse(readingSkillRequirements.ReadLine()))
                        {
                            warningMessages("Your Will isn't high enough to take this skill.");
                            return false;
                        }
                    }
                    else if (skillRequirement == "Empathy")
                    {
                        int empathyRequirement = int.Parse(readingSkillRequirements.ReadLine());

                        //Exception for Streetwise with lone wolf.
                        if (skillName.Contains("Streetwise") && (skills.ContainsKey("Lone Wolf - (Tier 1)") ||
                            skills.ContainsKey("Lone Wolf - (Tier 2)")))
                            empathyRequirement -= 35;

                        if (EmpathyTotal < empathyRequirement)
                        {
                            warningMessages("Your Empathy isn't high enough to take this skill.");
                            return false;
                        }
                    }
                    else if (skillRequirement == "EmpathyLess")
                    {
                        if (EmpathyTotal > int.Parse(readingSkillRequirements.ReadLine()))
                        {
                            warningMessages("Your Empathy isn't low enough to take this skill.");
                            return false;
                        }
                    }
                    //If true, this checks if any of a skill's exceptions to the requirements are
                    //met. If so, then the rest of a skill's requirements are ignored.
                    else if (skillRequirement == "Exceptions")
                    {
                        int amountOfExceptions = int.Parse(readingSkillRequirements.ReadLine());

                        for (int count = 0; count < amountOfExceptions; count++)
                        {
                            string exception = readingSkillRequirements.ReadLine();

                            //Special exceptions for the sniper and marksman skills.
                            if (((skillName == "Sniper - (Tier 5)" && skills.ContainsKey("Marksman - (Tier 4)")) ||
                                (skillName == "Marksman - (Tier 4)" && skills.ContainsKey("Sniper - (Tier 5)"))) &&
                                !skillTierLevelIsReducedBySniperOrMarksman)
                            {
                                skillTierLevelAmountReducedBySniperOrMarksman = tierLevel;
                                skillsAdder.TotalTierPoints += skillTierLevelAmountReducedBySniperOrMarksman;

                                skillTierLevelIsReducedBySniperOrMarksman = true;
                            }

                            /* All ifs must be checked before returning true. If conditions check if any of the 
                             * following exceptions are met.*/
                            if (exception == characterType || (skills.ContainsKey(exception.Remove(0, 1)) &&
                                (skillName == "Bo Staff - (Tier 4)" || skillName == "Brawler - (Tier 3)" ||
                                skillName == "Defend - (Tier 4)")) || ((skills.ContainsKey("Bo Staff - (Tier 4)") ||
                                skills.ContainsKey("Brawler - (Tier 3)") || skills.ContainsKey("Defend - (Tier 4)"))
                                && skillName.StartsWith("Martial Artist")))
                            {
                                //Specific exception for Bo Staff - (Tier 4) & Brawler - (Tier 3).
                                //Extracts the tier level.
                                if (exception.Contains("Martial Artist"))
                                    tierLevel = TierExtracter(exception);

                                if ((skillName == "Bo Staff - (Tier 4)" || (skillName.StartsWith("Martial Artist")
                                    && skills.ContainsKey("Bo Staff - (Tier 4)"))) && !skillTierLevelIsReducedByBoStaff && 
                                    skillsAdder.TotalTierPoints > 0)
                                {
                                    if (tierLevel < 4)
                                    {
                                        skillsAdder.TotalTierPoints += tierLevel;
                                        skillTierLevelAmountReducedByBoStaff = tierLevel;
                                    }
                                    else
                                    {
                                        skillsAdder.TotalTierPoints += 3;
                                        skillTierLevelAmountReducedByBoStaff = 3;
                                    }
                                    skillTierLevelIsReducedByBoStaff = true;
                                }

                                if ((skillName == "Brawler - (Tier 3)" || (skillName.StartsWith("Martial Artist") &&
                                    skills.ContainsKey("Brawler - (Tier 3)"))) && !skillTierLevelIsReducedByBrawler &&
                                    skillsAdder.TotalTierPoints > 0)
                                {
                                    if (tierLevel < 3)
                                    {
                                        skillsAdder.TotalTierPoints += tierLevel;
                                        skillTierLevelAmountReducedByBrawler = tierLevel;
                                    }
                                    else
                                    {
                                        skillsAdder.TotalTierPoints += 2;
                                        skillTierLevelAmountReducedByBrawler = 2;
                                    }
                                    skillTierLevelIsReducedByBrawler = true;
                                }

                                if ((skillName == "Defend - (Tier 4)" || (skillName.StartsWith("Martial Artist")
                                    && skills.ContainsKey("Defend - (Tier 4)"))) && !skillTierLevelIsReducedByDefend && 
                                    skillsAdder.TotalTierPoints > 0)
                                {
                                    if (tierLevel < 4)
                                    {
                                        skillsAdder.TotalTierPoints += tierLevel;
                                        skillTierLevelAmountReducedByDefend = tierLevel;
                                    }
                                    else
                                    {
                                        skillsAdder.TotalTierPoints += 3;
                                        skillTierLevelAmountReducedByDefend = 3;
                                    }
                                    skillTierLevelIsReducedByDefend = true;
                                }
                                //Gets the streamreader to the right place while the two skills below must have 
                                //their requirements checked.
                                if ((!skillName.StartsWith("Martial") && !skillName.StartsWith("Brawler"))  || 
                                    exception == characterType)
                                {
                                    while (readingSkillRequirements.ReadLine() != "Finished") { }
                                    return true;
                                }
                            }
                        }
                    }
                    else if (skillRequirement == "None")
                    {
                        readingSkillRequirements.ReadLine();
                        return true;
                    }
                }
                readingSkillRequirements.ReadLine();
                return true;
            }
            else
            {
                warningMessages("You are limited to only selecting skills with a tier of " +
                    tierLimit + " or less.");
                return false;
            }
        }

        //Extracts the tier level from skills.
        public int TierExtracter(string skillName) //===============================Update. (Take two lines from other file and shove into here).
        {
            char[] tierNumber = new char[1];
            skillName.CopyTo(skillName.Length - 2, tierNumber, 0, 1);
            return int.Parse(tierNumber[0].ToString());
        }

        //The set-up for a default warning message for requirements of skills that fail.
        private static void warningMessages(string message)
        {
            MessageBox.Show(message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // Sets and saves the skill Bonuses.
        // Dictionary<string skillName, string[bonus#1, bonusName/bonusEffect]>
        private Dictionary<string, string[,]> skills = new Dictionary<string, string[,]>();
        private void setSkillBonuses(StreamReader readingSkillBonuses, string skillName)
        {
            int numberOfBonuses = int.Parse(readingSkillBonuses.ReadLine());
            string[,] skillBonuses = new string[numberOfBonuses, 3];

            if (!skills.ContainsKey(skillName)) //If the dictionary doesn't contain the skill 
            {                                   //already, add it and apply the bonuses
                for (int i = 0; i < numberOfBonuses; i++)
                {
                    skillBonuses[i, 0] = readingSkillBonuses.ReadLine();
                    skillBonuses[i, 1] = readingSkillBonuses.ReadLine();

                    if (skillBonuses[i, 0] == "Defense")
                    {
                        if (skillName.Contains("Agility"))
                            baseDefenseLimitDisabled = true;

                        skillBonusToDefense += int.Parse(skillBonuses[i, 1]);
                        BaseDefenseStat += int.Parse(skillBonuses[i, 1]);
                    }
                    else if (skillBonuses[i, 0] == "Ranged Attack")
                    {
                        skillBonusToRangedAttack += int.Parse(skillBonuses[i, 1]);
                        RangedAttackStat += int.Parse(skillBonuses[i, 1]);
                    }
                    else if (skillBonuses[i, 0] == "Melee Attack")
                    {
                        skillBonusToMeleeAttack += int.Parse(skillBonuses[i, 1]);
                        MeleeAttackStat += int.Parse(skillBonuses[i, 1]);
                    }
                    else if (skillBonuses[i, 0] == "Health")
                    {
                        skillBonusToHealth += int.Parse(skillBonuses[i, 1]);
                        HealthStat += int.Parse(skillBonuses[i, 1]);
                    }
                    else if (skillBonuses[i, 0] == "CU")
                    {
                        skillBonusToHealth += int.Parse(skillBonuses[i, 1]);
                        CUTotal += int.Parse(skillBonuses[i, 1]);
                    }
                    else if (skillBonuses[i, 0] == "Gestalt")
                    {
                        GestaltStat += int.Parse(skillBonuses[i, 1]);
                    }
                    else if (skillBonuses[i, 0] == "Dice Roll")
                    {
                        Random dieRoll = new Random();

                        int numberOfDieRolls = int.Parse(skillBonuses[i, 1]);
                        string statToBoost = readingSkillBonuses.ReadLine();
                        int diesAmountOfSides = int.Parse(readingSkillBonuses.ReadLine());
                        skillBonuses[i, 1] = statToBoost;

                        for (int rollNumber = 0; rollNumber < numberOfDieRolls; rollNumber++)
                        {
                            skillBonuses[i, 2] += dieRoll.Next(1, diesAmountOfSides + 1);

                            if (statToBoost == "Will")
                                WillTotal += int.Parse(skillBonuses[i, 2]);
                            else if (statToBoost == "Strength")
                                StrengthTotal += int.Parse(skillBonuses[i, 2]);
                            else if (statToBoost == "Perception")
                                PerceptionTotal += int.Parse(skillBonuses[i, 2]);
                        }
                    }
                    else if (skillBonuses[i, 0] == "Will")
                    {
                        WillTotal += int.Parse(skillBonuses[i, 1]);
                    }
                }
                skills.Add(skillName, skillBonuses);
            }
        }

        /// <summary>
        /// Removes skill bonuses.
        /// </summary>
        /// <param name="skillName">The name of the skill to remove.</param>
        public void RemoveSkills(string skillName)
        {
            string[,] skillBonuses = skills[skillName];

            //These follow if statements are for the special exceptions involving skills.
            if ((skillName == "Bo Staff - (Tier 4)" || skillName.StartsWith("Martial Artist")) && skillTierLevelIsReducedByBoStaff)
            {
                skillsAdder.TotalTierPoints -= skillTierLevelAmountReducedByBoStaff;
                skillTierLevelIsReducedByBoStaff = false;
            }
            else if ((skillName == "Brawler - (Tier 3)" || skillName.StartsWith("Martial Artist")) && skillTierLevelIsReducedByBrawler)
            {
                skillsAdder.TotalTierPoints -= skillTierLevelAmountReducedByBrawler;
                skillTierLevelIsReducedByBrawler = false;
            }
            else if ((skillName == "Defend - (Tier 4)" || skillName.StartsWith("Martial Artist")) && skillTierLevelIsReducedByDefend)
            {
                    skillsAdder.TotalTierPoints -= skillTierLevelAmountReducedByDefend;
                    skillTierLevelIsReducedByDefend = false;
            }
            else if ((skillName == "Sniper - (Tier 5)" || skillName == "Marksman - (Tier 4)") && skillTierLevelIsReducedBySniperOrMarksman)
            {
                skillsAdder.TotalTierPoints -= skillTierLevelAmountReducedBySniperOrMarksman;
                skillTierLevelAmountReducedBySniperOrMarksman = 0;
                skillTierLevelIsReducedBySniperOrMarksman = false;
            }

            for (int i = 0; i <= skillBonuses.GetUpperBound(0); i++)
            {
                if (skillBonuses[i, 0] == "Defense")
                {
                    if (skillName.Contains("Agility"))
                        baseDefenseLimitDisabled = false;

                    skillBonusToDefense -= int.Parse(skillBonuses[i, 1]);
                    BaseDefenseStat -= int.Parse(skillBonuses[i, 1]);
                }
                else if (skillBonuses[i, 0] == "Ranged Attack")
                {
                    skillBonusToRangedAttack -= int.Parse(skillBonuses[i, 1]);
                    RangedAttackStat -= int.Parse(skillBonuses[i, 1]);
                }
                else if (skillBonuses[i, 0] == "Melee Attack")
                {
                    skillBonusToMeleeAttack -= int.Parse(skillBonuses[i, 1]);
                    MeleeAttackStat -= int.Parse(skillBonuses[i, 1]);
                }
                else if (skillBonuses[i, 0] == "Health")
                {
                    skillBonusToHealth -= int.Parse(skillBonuses[i, 1]);
                    HealthStat -= int.Parse(skillBonuses[i, 1]);
                }
                else if (skillBonuses[i, 0] == "CU")
                {
                    skillBonusToCU -= int.Parse(skillBonuses[i, 1]);
                    CUTotal -= int.Parse(skillBonuses[i, 1]);
                }
                else if (skillBonuses[i, 0] == "Gestalt")
                {
                    GestaltStat -= int.Parse(skillBonuses[i, 1]);
                }
                else if (skillBonuses[i, 0] == "Dice Roll")
                {
                    if (skillBonuses[i, 1] == "Will")
                        WillTotal -= int.Parse(skillBonuses[i, 2]);
                    else if (skillBonuses[i, 1] == "Strength")
                        StrengthTotal -= int.Parse(skillBonuses[i, 2]);
                    else if (skillBonuses[i, 1] == "Perception")
                        PerceptionTotal -= int.Parse(skillBonuses[i, 2]);
                }
                else if (skillBonuses[i, 0] == "Will")
                {
                    WillTotal -= int.Parse(skillBonuses[i, 1]);
                }
            }
            skills.Remove(skillName);
        }

        //Does all the auto-stat calculations except for movement speeds.
        private void autoStatCalculator()
        {
            int baseDefenseLimit;

            WillBonusStat = WillTotal / 10;
            MeleeAttackStat = StrengthTotal / 5 + PerceptionTotal / 10 + WillBonusStat + skillBonusToMeleeAttack;
            RangedAttackStat = PerceptionTotal / 5 + StrengthTotal / 10 + WillBonusStat + skillBonusToRangedAttack;
            BaseDefenseStat = StrengthTotal / 5 + PerceptionTotal / 10 + WillTotal / 15 + skillBonusToDefense;

            if (skills.ContainsKey("Tough - (Tier 1)"))
                baseDefenseLimit = 7;
            else 
                baseDefenseLimit = 5;

            if (BaseDefenseStat > baseDefenseLimit && !baseDefenseLimitDisabled)
                BaseDefenseStat = baseDefenseLimit;

            BiteRateStat = (int)Math.Round(PerceptionTotal / 2F); //A little bit of a beneficial 
                                                                  //rounding for characters.

            HealthStat = StrengthTotal + WillTotal / 5 + skillBonusToHealth;
        }
    }
}