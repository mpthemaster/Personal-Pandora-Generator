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
        public SkillsAdder skillsAdder;

        /* Holds the information of whether or not stats have changed and how much they have 
         * changed by due to type bonuses. This allows the changes to be undone when another type
         * is selected.*/
        private bool empathyChanged, perceptionChanged, strengthChanged, willChanged,
            tierChanged, totalStatPointsChanged, baseDefenseLimitDisabled, tierIsLimited, 
            skillTierLevelIsReducedByBoStaff, skillTierLevelIsReducedByBrawler;
        private int empathyStatChange, perceptionStatChange, strengthStatChange,
            willStatChange, tierPointChange, totalStatPointsChange, tierLimit, 
            skillTierLevelAmountReducedByBoStaff, skillTierLevelAmountReducedByBrawler;

        //Holds the information of what a character's stats currently are (including the 
        //properties past the fields).
        public int RangedAttackStat, MeleeAttackStat, WillBonusStat, HealthStat, BiteRateStat, 
            WeightTotal, BaseDefenseStat, TotalStatPoints = 120, TotalTierPoints = 5;
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

                CUTotal = strengthTotal / 5; //One such calculated value that only Strength modifies

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
        /// <param name="typeText">The RichTextBox where the type description is going to be 
        /// placed</param>
        /// <param name="typeBonusList">The ListBox where the bonuses are to be listed.</param>
        public void TypeAndBonusLoader(string typeName, RichTextBox typeText,  
            ListBox typeBonusList)
        {
            string typeInformation;
            StreamReader readingTypes = new StreamReader("../../Types.txt");

            resetTypeBonuses(); //Undoes any previous type bonuses.

            do
            {
                typeInformation = readingTypes.ReadLine();

                //If the line contains the user-selected type...read and load the rest of the
                //information
                if (typeInformation == typeName && typeInformation.IndexOf(typeName) == 0)
                {
                    typeText.Text = typeInformation.ToUpper();
                    typeText.AppendText("\n\t" + readingTypes.ReadLine());

                    int numberOfBonuses = int.Parse(readingTypes.ReadLine());
                    typeBonusList.Items.Add("Bonuses:");

                    for (int i = 0; i < numberOfBonuses; i++)
                    {
                        typeBonusList.Items.Add(readingTypes.ReadLine());
                    }

                    setTypeBonuses(readingTypes); //Applies the type's bonuses.

                    //Formats the name of the type to be prettier.
                    typeText.Select(0, typeName.Length);
                    typeText.SelectionAlignment = HorizontalAlignment.Center;
                    typeText.SelectionColor = Color.Red;
                }
            } while (!readingTypes.EndOfStream && typeInformation != typeName);

            readingTypes.Close();
        }

        //Resets the bonuses given by a type when the type changes.
        private void resetTypeBonuses()
        {
            if (empathyChanged)
            {
                TotalStatPoints -= empathyStatChange;
                EmpathyTotal -= empathyStatChange;

                empathyChanged = false;
            }
            if (perceptionChanged)
            {
                TotalStatPoints -= perceptionStatChange;
                PerceptionTotal -= perceptionStatChange;

                perceptionChanged = false;
            }
            if (strengthChanged)
            {
                TotalStatPoints -= strengthStatChange;
                StrengthTotal -= strengthStatChange;

                strengthChanged = false;
            }
            if (willChanged)
            {
                TotalStatPoints -= willStatChange;
                WillTotal -= willStatChange;

                willChanged = false;
            }
            if (tierChanged)
            {
                TotalTierPoints -= tierPointChange;
                tierChanged = false;
            }
            if (totalStatPointsChanged)
            {
                TotalStatPoints -= totalStatPointsChange;
                totalStatPointsChanged = false;
            }
            if (tierIsLimited)
            {
                tierLimit = 0;
                tierIsLimited = false;
            }
        }

        //Applies the bonuses given by a type when the type changes.
        //A change is recorded as happening and how much it changed is also recorded.
        private void setTypeBonuses(StreamReader readingTypes)
        {
            int numberOfModifications = int.Parse(readingTypes.ReadLine());

            for (int i = 0; i < numberOfModifications; i++)
            {
                string checkModification = readingTypes.ReadLine();

                if (checkModification == "Empathy")
                {
                    empathyStatChange = int.Parse(readingTypes.ReadLine());
                    TotalStatPoints += empathyStatChange;
                    empathyChanged = true;

                    EmpathyTotal += empathyStatChange;
                }
                else if (checkModification == "Perception")
                {
                    perceptionStatChange = int.Parse(readingTypes.ReadLine());
                    TotalStatPoints += perceptionStatChange;
                    perceptionChanged = true;

                    PerceptionTotal += perceptionStatChange;
                }
                else if (checkModification == "Strength")
                {
                    strengthStatChange = int.Parse(readingTypes.ReadLine());
                    TotalStatPoints += strengthStatChange;
                    strengthChanged = true;

                    StrengthTotal += strengthStatChange;
                }
                else if (checkModification == "Will")
                {
                    willStatChange = int.Parse(readingTypes.ReadLine());
                    TotalStatPoints += willStatChange;
                    willChanged = true;

                    WillTotal += willStatChange;
                }
                else if (checkModification == "Tier")
                {
                    tierPointChange = int.Parse(readingTypes.ReadLine());
                    TotalTierPoints += tierPointChange;
                    tierChanged = true;
                }
                else if (checkModification == "TotalStatPoints")
                {
                    totalStatPointsChange = int.Parse(readingTypes.ReadLine());
                    TotalStatPoints += totalStatPointsChange;

                    totalStatPointsChanged = true;
                }
                else if (checkModification == "Tier Limit")
                {
                    tierLimit = int.Parse(readingTypes.ReadLine());

                    tierIsLimited = true;
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
                (e.KeyChar) || char.IsPunctuation(e.KeyChar) && e.KeyChar.ToString() != ".")
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
                    skillTxt.AppendText("\n\t" + readingSkills.ReadLine());

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

                        //Exceptions are dealt with a different way.
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

                    //Formats the name of the skill.
                    skillTxt.Select(0, skillsName.Length);
                    skillTxt.SelectionAlignment = HorizontalAlignment.Center;
                    skillTxt.SelectionColor = Color.Red;
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
        public bool skillBonusApplier(string[] pickedSkillsList, string characterType, 
            int tierLevel)
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
            //Extracts the tier level.
            char[] tierNumber = new char[1];
            skillName.CopyTo(skillName.Length - 2, tierNumber, 0, 1);
            int tierLevel = int.Parse(tierNumber[0].ToString());

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
                    else if (skillRequirement == "Weight")
                    {
                        if (WeightTotal > int.Parse(readingSkillRequirements.ReadLine()))
                        {
                            warningMessages("Your Weight isn't low enough to take this skill.");
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
                        if (EmpathyTotal < int.Parse(readingSkillRequirements.ReadLine()))
                        {
                            warningMessages("Your Empathy isn't high enough to take this skill.");
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

                            /* Returns true inside this if statement at the bottom. All ifs must
                             * be checked before returning true. If conditions check if any of the 
                             * following exceptions are met. 
                             * ***I will be able to make this less complicated if after adding the 
                             * real "Martial Artist" skill, it has no type exceptions.
                             */ 
                            if (exception == characterType || (skills.ContainsKey(exception.Remove(0, 1)) && (skillName == "Bo Staff - (Tier 4)" || skillName == "Brawler - (Tier 3)")) || ((skills.ContainsKey("Bo Staff - (Tier 4)") || skills.ContainsKey("Brawler - (Tier 3)")) && skillName.StartsWith("Martial Artist")))
                            {
                                //Gets the streamreader to the right place for setSkillBonuses().
                                if (exception == characterType)
                                {
                                    //Depending on whether the amountOfExceptions and 
                                    //numberOfRequirements are odd or even, a different
                                    //formula needs to be used.
                                    int x;
                                    if (amountOfExceptions % 2 == 0 && numberOfRequirements % 2 == 0) //Does nothing right now (conditions are never met so far)
                                        x = 2;
                                    else if (amountOfExceptions % 2 == 1 && numberOfRequirements % 2 == 0)
                                        x = 0;
                                    else
                                        x = 1;

                                    for (int count2 = 0; count2 < amountOfExceptions - count +
                                        numberOfRequirements + x - 1; count2++)
                                    {
                                        readingSkillRequirements.ReadLine();
                                    }
                                }

                                //Specific exception for Bo Staff - (Tier 4) & Brawler - (Tier 3).
                                if (exception.Contains("Martial Artist") || ((skills.ContainsKey("Bo Staff - (Tier 4)") || skills.ContainsKey("Brawler - (Tier 3)")) && skillName.StartsWith("Martial Artist")))
                                {
                                    //Extracts the tier level.
                                    if (exception.Contains("Martial Artist"))
                                        exception.CopyTo(exception.Length - 2, tierNumber, 0, 1);
                                    int tierLevelToAdd = int.Parse(tierNumber[0].ToString());

                                    if (skillName == "Bo Staff - (Tier 4)" || (skillName.StartsWith("Martial Artist") && skills.ContainsKey("Bo Staff - (Tier 4)")))
                                    {
                                        if (tierLevelToAdd < 4)
                                        {
                                            skillsAdder.TotalTierPoints += tierLevelToAdd;
                                            skillTierLevelAmountReducedByBoStaff = tierLevelToAdd;
                                        }
                                        else
                                        {
                                            skillsAdder.TotalTierPoints += 3;
                                            skillTierLevelAmountReducedByBoStaff = 3;
                                        }
                                        skillTierLevelIsReducedByBoStaff = true;
                                    }

                                    if (skillName == "Brawler - (Tier 3)" || (skillName.StartsWith("Martial Artist") && skills.ContainsKey("Brawler - (Tier 3)")))
                                    {
                                        if (tierLevelToAdd < 3)
                                        {
                                            skillsAdder.TotalTierPoints += tierLevelToAdd;
                                            skillTierLevelAmountReducedByBrawler = tierLevelToAdd;
                                        }
                                        else
                                        {
                                            skillsAdder.TotalTierPoints += 2;
                                            skillTierLevelAmountReducedByBrawler = 2;
                                        }
                                        skillTierLevelIsReducedByBrawler = true;
                                    }
                                    //Gets the streamreader to the right place for setSkillBonuses(). Regardless, the Martial Artist skill must have its own requirements checked because it is a special case that impacts two other skills. *I need to edit this* after I add in the real Martial Artist skill.
                                    if (!skillName.StartsWith("Martial Artist"))
                                    {
                                        int x;
                                        if (amountOfExceptions % 2 == 0 || numberOfRequirements % 2 == 0)
                                            x = 1;
                                        else
                                            x = 0;

                                        for (int count2 = 0; count2 < amountOfExceptions - count +
                                            numberOfRequirements + x; count2++)
                                        {
                                            readingSkillRequirements.ReadLine();
                                        }
                                    }
                                }
                                return true;
                            }
                        }
                    }
                    else if (skillRequirement == "None")
                    {
                        readingSkillRequirements.ReadLine();
                        return true;
                    }
                }
                return true;
            }
            else
            {
                warningMessages("You are limited to only selecting skills with a tier of " +
                    tierLimit + " or less.");
                return false;
            }
        }

        //The set-up for a default warning message.
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
            string[,] skillBonuses = new string[numberOfBonuses, 2];

            if (!skills.ContainsKey(skillName)) //If the dictionary doesn't contain the skill 
            {                                   //already, add it and apply the bonuses
                for (int i = 0; i < numberOfBonuses; i++)
                {
                    skillBonuses[i, 0] = readingSkillBonuses.ReadLine();
                    skillBonuses[i, 1] = readingSkillBonuses.ReadLine();

                    if (skillBonuses[i, 0] == "Defense")
                    {
                        baseDefenseLimitDisabled = true;
                        BaseDefenseStat += int.Parse(skillBonuses[i, 1]);
                    }
                    else if (skillBonuses[i, 0] == "Ranged Attack")
                    {
                        RangedAttackStat += int.Parse(skillBonuses[i, 1]);
                    }
                    else if (skillBonuses[i, 0] == "Melee Attack")
                    {
                        MeleeAttackStat += int.Parse(skillBonuses[i, 1]);
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

            //These two if statements are for the special exceptions involving Bo Staff, Brawler, and Martial Artist.
            if (skillName == "Bo Staff - (Tier 4)" || skillName.StartsWith("Martial Artist"))
            {
                if (skillTierLevelIsReducedByBoStaff)
                {
                    skillsAdder.TotalTierPoints -= skillTierLevelAmountReducedByBoStaff;
                    skillTierLevelIsReducedByBoStaff = false;
                }
            }
            if (skillName == "Brawler - (Tier 3)" || skillName.StartsWith("Martial Artist"))
            {
                if (skillTierLevelIsReducedByBrawler)
                {
                    skillsAdder.TotalTierPoints -= skillTierLevelAmountReducedByBrawler;
                    skillTierLevelIsReducedByBrawler = false;
                }
            }

            for (int i = 0; i < skillBonuses.Length - 1; i++)
            {
                if (skillBonuses[i, 0] == "Defense")
                {
                    baseDefenseLimitDisabled = false;
                    BaseDefenseStat -= int.Parse(skillBonuses[i, 1]);
                }
                else if (skillBonuses[i, 0] == "Ranged Attack")
                    RangedAttackStat -= int.Parse(skillBonuses[i, 1]);
                else if (skillBonuses[i, 0] == "Melee Attack")
                    MeleeAttackStat -= int.Parse(skillBonuses[i, 1]);
            }
            skills.Remove(skillName);
        }

        //Does all the auto-stat calculations except for movement speeds.
        private void autoStatCalculator()
        {
            WillBonusStat = WillTotal / 10;
            MeleeAttackStat = StrengthTotal / 5 + PerceptionTotal / 10 + WillBonusStat;
            RangedAttackStat = PerceptionTotal / 5 + StrengthTotal / 10 + WillBonusStat;
            BaseDefenseStat = StrengthTotal / 5 + PerceptionTotal / 10 + WillTotal / 15;

            if (BaseDefenseStat > 5 && !baseDefenseLimitDisabled)
                BaseDefenseStat = 5;

            BiteRateStat = (int)Math.Round(PerceptionTotal / 2F); //A little bit of a beneficial 
                                                                  //rounding for characters.

            HealthStat = StrengthTotal + WillTotal / 5;
        }
    }
}