using System;
using System.Windows.Forms;
using System.IO;

namespace RandChar
{
    public partial class FrmCharacterCreationTool : Form
    {
        public FrmCharacterCreationTool()
        {
            InitializeComponent();

            //Counts up the possibilities for each possibility group.
            ReadLines("likes");
            ReadLines("mottos");
            ReadLines("skillsTool");
            ReadLines("traits");
        }

        //Figures out how many lines (items) are in each text file.
        private void ReadLines(string fileName)
        {
            int count = 0;
            StreamReader reader = new StreamReader("../../" + fileName + ".txt");

            while (!reader.EndOfStream)
            {
                reader.ReadLine();
                count++;
            }

            //Sets the appropriate count for the type of possibilities.
            switch(fileName)
            {
                case "likes" :
                    likesCount = count;
                    break;

                case "mottos" :
                    mottosCount = count;
                    break;

                case "skillsTool" :
                    skillsCount = count;
                    break;
                    
                case "traits" :
                    traitsCount = count;
                    break;

                default :
                    MessageBox.Show("The count for " + fileName + " has failed.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        Random rnd = new Random();
        int likesCount, mottosCount, skillsCount, traitsCount;

        //Generates a new random number and allows up to 9 ideas be generated at a time.
        private void generateBtn_Click(object sender, EventArgs e)
        {
            StreamReader reader;

            lblResultPossibilities.Text = "";

            int[] generatedNumbers = new int[(int)numAmountGenerated.Value];

            for (int i = 0; i < numAmountGenerated.Value; i++)
            {
                int gen, maxCount;

                if (radLikes.Checked)
                {
                    reader = new StreamReader("../../likes.txt");
                    maxCount = likesCount;
                }
                else if (radPersonality.Checked)
                {
                    reader = new StreamReader("../../traits.txt");
                    maxCount = traitsCount;
                }
                else if (radSkills.Checked)
                {
                    reader = new StreamReader("../../skillsTool.txt");
                    maxCount = skillsCount;
                }
                else
                {
                    reader = new StreamReader("../../mottos.txt");
                    maxCount = mottosCount;
                }

                do
                {
                    gen = rnd.Next(0, maxCount);
                } while (Repeating(gen, generatedNumbers));

                generatedNumbers[i] = gen;

                //Gets the StreamReader to the right place.
                for (int x = 0; x < gen - 1; x++)
                    reader.ReadLine();
                if (!radMottos.Checked)
                    lblResultPossibilities.Text += reader.ReadLine() + ". ";
                else
                {   //Only one motto is given at a time.
                    lblResultPossibilities.Text += reader.ReadLine();
                    break;
                }
            }
        }

        /// <summary>
        /// Checks if a newly generated random number is a repeat or not.
        /// </summary>
        /// <param name="genNum">The new random number.</param>
        /// <param name="genNums">The list of previously generated random numbers.</param>
        /// <returns>Returns if the new random number is a repetition.</returns>
        private bool Repeating(int genNum, int[] genNums)
        {
            foreach (int num in genNums)
                if (num == genNum)
                    return true;
            return false;
        }

        //Generates a random age between user inputted values.
        private void generateAgeBtn_Click(object sender, EventArgs e)
        {
            int lowerRange, higherRange;
            bool error = false;

            if (!int.TryParse(txtLowerAgeRange.Text, out lowerRange))
            {
                MessageBox.Show("Please enter a number into the lower age range textbox.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = true;
            }

            if (!int.TryParse(txtHigherAgeRange.Text, out higherRange))
            {
                MessageBox.Show("Please enter a number into the higher age range textbox.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = true;
            }

            if (lowerRange >= higherRange)
            {
                MessageBox.Show("The textbox on the left must have a lower value than the textbox on the right.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLowerAgeRange.Clear();
                txtLowerAgeRange.Focus();
            }
            else if (!error)
                txtAgeResult.Text = rnd.Next(lowerRange, higherRange + 1).ToString();
        }
        
        //Stops anything other than number symbols to be entered into textboxes.
        private void numbersOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            CharacterCreation.NumbersOnly_KeyPress(sender, e);
        }

        //Applies some settings to the form based on the user's last use.
        private void CharacterCreationTool_Load(object sender, EventArgs e)
        {
            //Applies user-settings.
            this.Location = Properties.Settings.Default.FormLocation;
            numAmountGenerated.Value = Properties.Settings.Default.GenerateAmount;
            txtLowerAgeRange.Text = Properties.Settings.Default.LowerAge;
            txtHigherAgeRange.Text = Properties.Settings.Default.HigherAge;

        }

        //Saves user settings.
        private void CharacterCreationTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.FormLocation = this.Location;
            Properties.Settings.Default.GenerateAmount = numAmountGenerated.Value;
            Properties.Settings.Default.LowerAge = txtLowerAgeRange.Text;
            Properties.Settings.Default.HigherAge = txtHigherAgeRange.Text;
            Properties.Settings.Default.Save();
        }
        
        //Lets the user know that they can't change the amount of mottos generated.
        private void mottosRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (radMottos.Checked)
                numAmountGenerated.Enabled = false;
            else
                numAmountGenerated.Enabled = true;
        }

        //Allows the user to add possibilities and saves them to their textfiles.
        private void btnMOD_Click(object sender, EventArgs e)
        {
            FrmCharCreateToolMod modTool = new FrmCharCreateToolMod();

            if (modTool.ShowDialog() == DialogResult.OK)
            {
                if (modTool.likes != null)
                    WritingLines("likes", modTool.likes);
                if (modTool.mottos != null)
                    WritingLines("mottos", modTool.mottos);
                if (modTool.skills != null)
                    WritingLines("skillsTool", modTool.skills);
                if (modTool.traits != null)
                    WritingLines("traits", modTool.traits);
            }
        }

        //Writes the user's new possibilities to text files.
        private void WritingLines(string fileName, string[] possibilities)
        {
            using (StreamWriter writer = new StreamWriter("../../" + fileName + ".txt", true))
                for (int i = 0; i < possibilities.Length; i++)
                    writer.Write("\r\n" + possibilities[i]);
        }
    }
}
