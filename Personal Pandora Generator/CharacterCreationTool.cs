using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RandChar
{
    public partial class CharacterCreationTool : Form
    {
        public CharacterCreationTool()
        {
            InitializeComponent();
        }

        //Sets up the dictionaries for likes, personality traits, and skills.
        private Dictionary<int, string> likes = new Dictionary<int, string>();
        private Dictionary<int, string> traits = new Dictionary<int, string>();
        private Dictionary<int, string> skills = new Dictionary<int, string>();
        private Dictionary<int, string> mottos = new Dictionary<int, string>();

        Random rnd = new Random();

        //Generates a new random number and allows up to 9 ideas be generated at a time.
        private void generateBtn_Click(object sender, EventArgs e)
        {
            resultPosibilitiesLbl.Text = "";

            int[] generatedNumbers = new int[(int)amountGeneratedNumeric.Value];

            for (int i = 0; i < amountGeneratedNumeric.Value; i++)
            {
            Redo:
                int gen = rnd.Next(0, 150);

                //Stops duplicated results.
                foreach (int number in generatedNumbers)
                {
                    if (number == gen)
                        goto Redo;
                }

                generatedNumbers[i] = gen;

                if (likesRadio.Checked)
                    resultPosibilitiesLbl.Text += likes[gen] + ". ";
                else if (personalityRadio.Checked)
                    resultPosibilitiesLbl.Text += traits[gen] + ". ";
                else if (skillsRadio.Checked)
                    resultPosibilitiesLbl.Text += skills[gen] + ". ";
                else if (mottosRadio.Checked)
                {
                    i = (int) amountGeneratedNumeric.Value;
                    resultPosibilitiesLbl.Text = mottos[gen];
                }
                else
                    MessageBox.Show("Error!");
            }
        }

        //Generates a random age between user inputted values.
        private void generateAgeBtn_Click(object sender, EventArgs e)
        {
            int lower = int.Parse(lowerAgeRangeTxt.Text);
            int higher = int.Parse(higherAgeRangeTxt.Text);

            if (lower >= higher)
            {
                MessageBox.Show("The textbox on the left must have a lower value than the textbox"
                    + " on the right.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lowerAgeRangeTxt.Clear();
                lowerAgeRangeTxt.Focus();
            }
            else
                ageResultTxt.Text = rnd.Next(lower, higher + 1).ToString();
        }
        
        //Stops anything other than number symbols to be entered into textboxes.
        private void numbersOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            CharacterCreation.NumbersOnly_KeyPress(sender, e);
        }

        //Fills up the three different dictionaries.
        private void CharacterCreationTool_Load(object sender, EventArgs e)
        {
            //Applies user-settings.
            this.Location = Properties.Settings.Default.FormLocation;
            amountGeneratedNumeric.Value = Properties.Settings.Default.GenerateAmount;
            lowerAgeRangeTxt.Text = Properties.Settings.Default.LowerAge;
            higherAgeRangeTxt.Text = Properties.Settings.Default.HigherAge;

            likes.Add(0, "Birds");
            likes.Add(1, "Cars");
            likes.Add(2, "Food");
            likes.Add(3, "Partying");
            likes.Add(4, "Money");
            likes.Add(5, "Bowling");
            likes.Add(6, "Video Games");
            likes.Add(7, "Halloween");
            likes.Add(8, "Pets");
            likes.Add(9, "Alcohol");
            likes.Add(10, "Science Fiction");
            likes.Add(11, "Card Games");
            likes.Add(12, "Christmas");
            likes.Add(13, "Gambling");
            likes.Add(14, "Shopping");
            likes.Add(15, "Reading");
            likes.Add(16, "Working");
            likes.Add(17, "Gardening");
            likes.Add(18, "Air Conditioning");
            likes.Add(19, "Outdoors");
            likes.Add(20, "Cooking");
            likes.Add(21, "Smoking");
            likes.Add(22, "Children");
            likes.Add(23, "Camping");
            likes.Add(24, "Hiking");
            likes.Add(25, "Sky Diving");
            likes.Add(26, "Candles");
            likes.Add(27, "House Work");
            likes.Add(28, "Quiet");
            likes.Add(29, "Noise");
            likes.Add(30, "Jewlry");
            likes.Add(31, "Animals");
            likes.Add(32, "Family");
            likes.Add(33, "Technology");
            likes.Add(34, "Meat");
            likes.Add(35, "Beaches");
            likes.Add(36, "Mountains");
            likes.Add(37, "Rivers");
            likes.Add(38, "Football");
            likes.Add(39, "Soccer");
            likes.Add(40, "Baseball");
            likes.Add(41, "Hockey");
            likes.Add(42, "Flowers");
            likes.Add(43, "Poetry");
            likes.Add(44, "Art");
            likes.Add(45, "Music");
            likes.Add(46, "Movies");
            likes.Add(47, "Puzzles");
            likes.Add(48, "Riddles");
            likes.Add(49, "Science");
            likes.Add(50, "Bicycling");
            likes.Add(51, "Motorcycles");
            likes.Add(52, "Trucks");
            likes.Add(53, "Rain");
            likes.Add(54, "Airplanes");
            likes.Add(55, "People");
            likes.Add(56, "Parties");
            likes.Add(57, "Sex");
            likes.Add(58, "Romance");
            likes.Add(59, "Manipulating");
            likes.Add(60, "Nature");
            likes.Add(61, "Bugs");
            likes.Add(62, "Guns");
            likes.Add(63, "Fire");
            likes.Add(64, "Knives");
            likes.Add(65, "Hospitals");
            likes.Add(66, "Other races");
            likes.Add(67, "Darkness");
            likes.Add(68, "Light");
            likes.Add(69, "Being Alone");
            likes.Add(70, "Being Busy");
            likes.Add(71, "Having Nothing to Do");
            likes.Add(72, "Eating");
            likes.Add(73, "Chocolate");
            likes.Add(74, "Illicit Drugs");
            likes.Add(75, "Pain");
            likes.Add(76, "Fashion");
            likes.Add(77, "Scuba Diving");
            likes.Add(78, "Programming");
            likes.Add(79, "Cold Weather");
            likes.Add(80, "Snow");
            likes.Add(81, "Politics");
            likes.Add(82, "Plays");
            likes.Add(83, "Doing Good Deeds");
            likes.Add(84, "Church");
            likes.Add(85, "Religion");
            likes.Add(86, "Tennis");
            likes.Add(87, "Board Games");
            likes.Add(88, "Fishing");
            likes.Add(89, "Hunting");
            likes.Add(90, "Spicy Food");
            likes.Add(91, "Exercising");
            likes.Add(92, "Hygiene");
            likes.Add(93, "Grooming");
            likes.Add(94, "Documenting");
            likes.Add(95, "Relaxing");
            likes.Add(96, "Sugary (Sweet) Foods");
            likes.Add(97, "Gossiping");
            likes.Add(98, "Trains");
            likes.Add(99, "Fast Speeds");
            likes.Add(100, "Power");
            likes.Add(101, "Mysteries");
            likes.Add(102, "Blood");
            likes.Add(103, "Police");
            likes.Add(104, "Military Veterans");
            likes.Add(105, "Doctors/Dentists");
            likes.Add(106, "School");
            likes.Add(107, "Authority Figures");
            likes.Add(108, "Authority Over Others");
            likes.Add(109, "Males");
            likes.Add(110, "Females");
            likes.Add(111, "Swimming");
            likes.Add(112, "Make-up");
            likes.Add(113, "Clowns");
            likes.Add(114, "Tight/Small Spaces");
            likes.Add(115, "Big Open Areas");
            likes.Add(116, "Car Rides");
            likes.Add(117, "Loud Music/Movies/Games");
            likes.Add(118, "Occult Magic");
            likes.Add(119, "Small Details");
            likes.Add(120, "Big Picture (Gist) of Ideas/Plans");
            likes.Add(121, "Public Speaking");
            likes.Add(122, "Listening to Others");
            likes.Add(123, "Attention");
            likes.Add(124, "Heights");
            likes.Add(125, "Flying");
            likes.Add(126, "Fighting");
            likes.Add(127, "Fire Works");
            likes.Add(128, "Remote Controlled Vehicles");
            likes.Add(129, "Paintball Fights");
            likes.Add(130, "Musical Instruments");
            likes.Add(131, "Philosophy");
            likes.Add(132, "Cats");
            likes.Add(133, "Dogs");
            likes.Add(134, "Babies");
            likes.Add(135, "Twinkies");
            likes.Add(136, "Fairs");
            likes.Add(137, "Festivals");
            likes.Add(138, "Acrobatics");
            likes.Add(139, "Parkour");
            likes.Add(140, "Being Tested");
            likes.Add(141, "Extreme Sports");
            likes.Add(142, "Group Activities");
            likes.Add(143, "Morals (Ethics)");
            likes.Add(144, "Boxing/Wrestling");
            likes.Add(145, "Casual Clothing");
            likes.Add(146, "Stylish Clothing");
            likes.Add(147, "City-life");
            likes.Add(148, "Country-life");
            likes.Add(149, "Bars");

            traits.Add(0, "Neat");
            traits.Add(1, "Clean");
            traits.Add(2, "Messy");
            traits.Add(3, "Athletic");
            traits.Add(4, "Intelligent");
            traits.Add(5, "Street Smart");
            traits.Add(6, "Ignorant");
            traits.Add(7, "Aggressive");
            traits.Add(8, "Passive");
            traits.Add(9, "Perfectionist");
            traits.Add(10, "Humorous");
            traits.Add(11, "Shy");
            traits.Add(12, "Friendly");
            traits.Add(13, "Snobby");
            traits.Add(14, "Proud");
            traits.Add(15, "Curious");
            traits.Add(16, "Liar");
            traits.Add(17, "Strict");
            traits.Add(18, "Eccentric");
            traits.Add(19, "Flashy");
            traits.Add(20, "Shady");
            traits.Add(21, "Anxious");
            traits.Add(22, "Charming");
            traits.Add(23, "Paranoid");
            traits.Add(24, "Devious");
            traits.Add(25, "Organized");
            traits.Add(26, "Crazy");
            traits.Add(27, "Careful");
            traits.Add(28, "Courageous");
            traits.Add(29, "Judgemental");
            traits.Add(30, "Complainer");
            traits.Add(31, "Independent");
            traits.Add(32, "Peaceful");
            traits.Add(33, "Frugal");
            traits.Add(34, "Emotional");
            traits.Add(35, "Stubborn");
            traits.Add(36, "Hardy (Emotionally Tough)");
            traits.Add(37, "Opinionated");
            traits.Add(38, "Pessemistic");
            traits.Add(39, "Optimistic");
            traits.Add(40, "Quiet");
            traits.Add(41, "Loud");
            traits.Add(42, "Determined");
            traits.Add(43, "Indecisive");
            traits.Add(44, "Nurturing");
            traits.Add(45, "Perceptive");
            traits.Add(46, "Pleasure Seeker");
            traits.Add(47, "Social Bug");
            traits.Add(48, "Sophisticated");
            traits.Add(49, "Energetic");
            traits.Add(50, "Excitable");
            traits.Add(51, "Romantic");
            traits.Add(52, "Obssessive");
            traits.Add(53, "Complusive");
            traits.Add(54, "Thinker");
            traits.Add(55, "Wise");
            traits.Add(56, "Leader");
            traits.Add(57, "Follower");
            traits.Add(58, "Old-Fashioned");
            traits.Add(59, "Morally Concious");
            traits.Add(60, "Caring");
            traits.Add(61, "Listener");
            traits.Add(62, "Whimsical");
            traits.Add(63, "Apathetic");
            traits.Add(64, "Clumsy");
            traits.Add(65, "Loner");
            traits.Add(66, "Trusting");
            traits.Add(67, "Non-Conforming");
            traits.Add(68, "Artistic");
            traits.Add(69, "Musically Inclined");
            traits.Add(70, "Simple");
            traits.Add(71, "Defensive");
            traits.Add(72, "Fashionable");
            traits.Add(73, "Outgoing");
            traits.Add(74, "Dependent");
            traits.Add(75, "Inappropriate");
            traits.Add(76, "attractive");
            traits.Add(77, "Boring");
            traits.Add(78, "Tired");
            traits.Add(79, "Risky");
            traits.Add(80, "Cautious");
            traits.Add(81, "Practical");
            traits.Add(82, "Idealistic");
            traits.Add(83, "Hard Worker");
            traits.Add(84, "Reliable");
            traits.Add(85, "Humble");
            traits.Add(86, "Egotistical");
            traits.Add(87, "Sneaky");
            traits.Add(88, "Ugly");
            traits.Add(89, "Foolish");
            traits.Add(90, "Bully");
            traits.Add(91, "Quick Learner");
            traits.Add(92, "Clueless");
            traits.Add(93, "Generous");
            traits.Add(94, "Greedy");
            traits.Add(95, "Lustful");
            traits.Add(96, "Trouble-Maker");
            traits.Add(97, "Unreliable");
            traits.Add(98, "Evil");
            traits.Add(99, "Creepy");
            traits.Add(100, "Competitive");
            traits.Add(101, "Spoiled");
            traits.Add(102, "Adventurous");
            traits.Add(103, "Just (Fair)");
            traits.Add(104, "Gluttonous");
            traits.Add(105, "Revengeful");
            traits.Add(106, "Wants to Prove Self-Worth");
            traits.Add(107, "Prude");
            traits.Add(108, "Rude");
            traits.Add(109, "Offensive (Speaks Mind Freely)");
            traits.Add(110, "Dreamer");
            traits.Add(111, "Dazed (Spacey)");
            traits.Add(112, "Ferocious");
            traits.Add(113, "Imaginitive");
            traits.Add(114, "Sociopath");
            traits.Add(115, "Touchy (Sensitive)");
            traits.Add(116, "Dramatic (Histrionic)");
            traits.Add(117, "Fake (Phony)");
            traits.Add(118, "Religious");
            traits.Add(119, "Spirtual");
            traits.Add(120, "Vulnerable");
            traits.Add(121, "Gullible");
            traits.Add(122, "Sore Loser");
            traits.Add(123, "Deformed (Physically or Mentally)");
            traits.Add(124, "Vain");
            traits.Add(125, "Responsible");
            traits.Add(126, "Loving");
            traits.Add(127, "Not Religious");
            traits.Add(128, "Not Spiritual");
            traits.Add(129, "Hyper");
            traits.Add(130, "Sluggish");
            traits.Add(131, "Witty");
            traits.Add(132, "Clingy");
            traits.Add(133, "Forgiving");
            traits.Add(134, "Unforgiving");
            traits.Add(135, "Decisive");
            traits.Add(136, "Annoying");
            traits.Add(137, "Daring");
            traits.Add(138, "Sheltered");
            traits.Add(139, "Domineering (Overbearing)");
            traits.Add(140, "Strange (Weird)");
            traits.Add(141, "Neutral");
            traits.Add(142, "Eclectic");
            traits.Add(143, "Fiesty");
            traits.Add(144, "Racy");
            traits.Add(145, "Gentle");
            traits.Add(146, "Fearsome");
            traits.Add(147, "Chivalrous");
            traits.Add(148, "Dreadful");
            traits.Add(149, "Environmentally Concious");

            skills.Add(0, "Cooking");
            skills.Add(1, "Driving");
            skills.Add(2, "Hiking");
            skills.Add(3, "Swimming");
            skills.Add(4, "Painting");
            skills.Add(5, "Automobile Mechanic");
            skills.Add(6, "Photography");
            skills.Add(7, "Writing");
            skills.Add(8, "Running");
            skills.Add(9, "Cleaning");
            skills.Add(10, "Hacking");
            skills.Add(11, "Computer Repair");
            skills.Add(12, "Hunting");
            skills.Add(13, "Fishing");
            skills.Add(14, "Using Guns");
            skills.Add(15, "Self-Defense");
            skills.Add(16, "Botany");
            skills.Add(17, "First AID");
            skills.Add(18, "Performing Surgery");
            skills.Add(19, "Hiding");
            skills.Add(20, "Climbing");
            skills.Add(21, "Persuasion");
            skills.Add(22, "Knitting");
            skills.Add(23, "Farming");
            skills.Add(24, "Chess");
            skills.Add(25, "Decorating");
            skills.Add(26, "Programming");
            skills.Add(27, "Teaching");
            skills.Add(28, "Training");
            skills.Add(29, "Calming Others");
            skills.Add(30, "Reducing Stress");
            skills.Add(31, "Parenting");
            skills.Add(32, "Golfing");
            skills.Add(33, "Computation");
            skills.Add(34, "Solving Problems");
            skills.Add(35, "Socializing");
            skills.Add(36, "Wood Work");
            skills.Add(37, "Mr/s.Fix-It Around The House");
            skills.Add(38, "Plumbing");
            skills.Add(39, "Wiring");
            skills.Add(40, "Engineering");
            skills.Add(41, "Scavanging For Food in the Wild");
            skills.Add(42, "Tracking");
            skills.Add(43, "Speaking");
            skills.Add(44, "Heavy Machinery");
            skills.Add(45, "Crafting");
            skills.Add(46, "Living in the Woods");
            skills.Add(47, "Navigating");
            skills.Add(48, "Staying Up Late");
            skills.Add(49, "Walking Up Early");
            skills.Add(50, "Flying (an airplane)");
            skills.Add(51, "Steering a Ship");
            skills.Add(52, "Using Explosives");
            skills.Add(53, "Doing Manual Labor");
            skills.Add(54, "Speaking Other Languages");
            skills.Add(55, "Memorizing");
            skills.Add(56, "Gymnastics");
            skills.Add(57, "Understanding Others");
            skills.Add(58, "Dancing");
            skills.Add(59, "Playing Video Games");
            skills.Add(60, "Etiquette");
            skills.Add(61, "Masterminding Plans");
            skills.Add(62, "Eating");
            skills.Add(63, "Darts");
            skills.Add(64, "Mixing Drinks");
            skills.Add(65, "Mixing Chemicals");
            skills.Add(66, "Finding Information");
            skills.Add(67, "Gambling");
            skills.Add(68, "Self-Control");
            skills.Add(69, "Magic Tricks");
            skills.Add(70, "Juggling");
            skills.Add(71, "Making Others Happy");
            skills.Add(72, "Concealing Your Emotions");
            skills.Add(73, "Being Humorous");
            skills.Add(74, "Remote Controlled Vehicles/Airplanes");
            skills.Add(75, "Acting");
            skills.Add(76, "Documenting");
            skills.Add(77, "Financing");
            skills.Add(78, "Knowledge of History");
            skills.Add(79, "Mountain Climbing");
            skills.Add(80, "Singing");
            skills.Add(81, "Being Discreet");
            skills.Add(82, "Being Secure");
            skills.Add(83, "Editing Videos");
            skills.Add(84, "Racing Cars");
            skills.Add(85, "Spying");
            skills.Add(86, "Cutting (things)");
            skills.Add(87, "Riding Horses");
            skills.Add(88, "Breeding Animals");
            skills.Add(89, "Dieting");
            skills.Add(90, "Designing (things)");
            skills.Add(91, "Making Tools");
            skills.Add(92, "Fire Fighting");
            skills.Add(93, "Using Maps");
            skills.Add(94, "Spulunking");
            skills.Add(95, "Public Speaking");
            skills.Add(96, "Being Lucky");
            skills.Add(97, "Lifting Heavy Objects");
            skills.Add(98, "Peace Making");
            skills.Add(99, "Imitating Others");
            skills.Add(100, "Archery");
            skills.Add(101, "Hand-to-Hand Combat");
            skills.Add(102, "Using Knives");
            skills.Add(103, "Using Swords");
            skills.Add(104, "Bargaining");
            skills.Add(105, "Coercing");
            skills.Add(106, "Thievery");
            skills.Add(107, "Trapping");
            skills.Add(108, "Analyzing Others");
            skills.Add(109, "Logic");
            skills.Add(110, "Ventriliquism");
            skills.Add(111, "Boxing");
            skills.Add(112, "Camouflage");
            skills.Add(113, "Apothecary");
            skills.Add(114, "Managing");
            skills.Add(115, "Organizing");
            skills.Add(116, "Staying up at Night");
            skills.Add(117, "Waking up Early");
            skills.Add(118, "Landscaping");
            skills.Add(119, "Picking Locks");
            skills.Add(120, "Playing Dumb");
            skills.Add(121, "Detecting Lies");
            skills.Add(122, "Lightening the Mood");
            skills.Add(123, "Counseling");
            skills.Add(124, "Meterologist");
            skills.Add(125, "Tricking Others");
            skills.Add(126, "Coordinating Events");
            skills.Add(127, "Veterinary");
            skills.Add(128, "Astronomy");
            skills.Add(129, "Physics");
            skills.Add(130, "Applied Mathematics");
            skills.Add(131, "Statistics");
            skills.Add(132, "Business");
            skills.Add(133, "Criminal Justice/Law Enforcement");
            skills.Add(134, "Fire Safety");
            skills.Add(135, "Search and Rescue");
            skills.Add(136, "Stealth (Being Quiet)");
            skills.Add(137, "Nutritionist");
            skills.Add(138, "Faking Emotions");
            skills.Add(139, "Physical Therapy");
            skills.Add(140, "Sanitation");
            skills.Add(141, "Scriptural Knowledge (any religion)");
            skills.Add(142, "Child Care");
            skills.Add(143, "Street Performing");
            skills.Add(144, "Raising LiveStock");
            skills.Add(145, "Sailing");
            skills.Add(146, "Demolition");
            skills.Add(147, "Divination");
            skills.Add(148, "Sign Language");
            skills.Add(149, "Brewing Beverages");

            mottos.Add(0, "Most of the time true words are spoken jokingly.");
            mottos.Add(1, "A just cause should be the reason for a fight.");
            mottos.Add(2, "Donate when you can.");
            mottos.Add(3, "Be more diplomatic in stressful situations.");
            mottos.Add(4, "Wealth and success are not the same things.");
            mottos.Add(5, "Always take advantage of an advantage.");
            mottos.Add(6, "A strong sense of duty is another way of saying imprisonment");
            mottos.Add(7, "Obstacles become easier by waiting them out.");
            mottos.Add(8, "Savour every moment life brings you.");
            mottos.Add(9, "Don't knock on the competition.");
            mottos.Add(10, "Dreams and hope are fodder for disappointment.");
            mottos.Add(11, "Time spent alone is a beautiful thing.");
            mottos.Add(12, "Make a promise and keep it.");
            mottos.Add(13, "Loud laughter is not something to be ashamed of.");
            mottos.Add(14, "Always plan for the worst.");
            mottos.Add(15, "Never be afraid to question or ask questions.");
            mottos.Add(16, "A job's a job no matter who is giving it.");
            mottos.Add(17, "Love will find a way.");
            mottos.Add(18, "Don't bite off more than you can chew.");
            mottos.Add(19, "Truth is a virtue to shame evil with.");
            mottos.Add(20, "The endings of stories should be known before you read the book.");
            mottos.Add(21, "Be more diligent and perceptive than those around you.");
            mottos.Add(22, "Brighten a room just by entering it.");
            mottos.Add(23, "It never hurts to kiss-up to superiors and to make them look good.");
            mottos.Add(24, "Keep the rhythm of life going.");
            mottos.Add(25, "The best gifts usually don't come packaged beautifully.");
            mottos.Add(26, "Don't look a gift horse in the mouth.");
            mottos.Add(27, "The one winking is just as bad as the one winking.");
            mottos.Add(28, "Don't borrow even a penny from your friends.");
            mottos.Add(29, "If you're fooling yourself then you are not fooling others.");
            mottos.Add(30, "You should never let yourself be pushed around.");
            mottos.Add(31, "Never take or use more than you need.");
            mottos.Add(32, "Criticism and praise should both be taken gracefully.");
            mottos.Add(33, "The small joys are just as good as the big joys.");
            mottos.Add(34, "Aim and then fire; don't fire and then aim.");
            mottos.Add(35, "Sometimes you have to do things you don't want to do.");
            mottos.Add(36, "Over-indulgence should be replaced by charity.");
            mottos.Add(37, "To delay is to be wasting time.");
            mottos.Add(38, "Good friends should be charished.");
            mottos.Add(39, "You should throw out the baby with the bathwater.");
            mottos.Add(40, "Don't speak about those who aren't there to defend themselves.");
            mottos.Add(41, "The only waste is not using something up right away.");
            mottos.Add(42, "If time has passed, forgive and forget.");
            mottos.Add(43, "Everything should have a place and be in that place.");
            mottos.Add(44, "You don't need to hear the whole story; say no if it sounds like you don't approve/like it.");
            mottos.Add(45, "Your rights are second to your manners.");
            mottos.Add(46, "Destruction is a virtue.");
            mottos.Add(47, "If there's smoke, there's fire.");
            mottos.Add(48, "Watch your attitude.");
            mottos.Add(49, "Friends are only as good as what they can provide you with.");
            mottos.Add(50, "The exception disproves the rule.");
            mottos.Add(51, "What you say and how you act should be the same.");
            mottos.Add(52, "Don't ask too many questions and mind your own business.");
            mottos.Add(53, "Easy questions are the only questions that need answering.");
            mottos.Add(54, "Using more than you need is immoral.");
            mottos.Add(55, "The truth is best told in detail.");
            mottos.Add(56, "Those who commit acts of evil on others need to be killed.");
            mottos.Add(57, "If you can only do a little, do nothing.");
            mottos.Add(58, "Think before you speak.");
            mottos.Add(59, "Don't put all your eggs in one basket.");
            mottos.Add(60, "Your eyes should always be open, even when kissing.");
            mottos.Add(61, "The highest standards should always be observed on oneself.");
            mottos.Add(62, "Don't let evidence get in the way of being the judge, jury, and executioner");
            mottos.Add(63, "A meal with loved ones is the most important part of any day.");
            mottos.Add(64, "Sometimes you need to rush off unprepared.");
            mottos.Add(65, "Decision-making should be a group effort.");
            mottos.Add(66, "Extreme measaures must be taken in order to defend your values.");
            mottos.Add(67, "You should always keep track of your accomplishments.");
            mottos.Add(68, "Your conscience should be listened to.");
            mottos.Add(69, "Don't throw out something that is old until you have something new to replace it with");
            mottos.Add(70, "Evil is not to be ignored.");
            mottos.Add(71, "High goals should always be set.");
            mottos.Add(72, "Don't get too big for your boots.");
            mottos.Add(73, "Dreams of others should never be laughed at.");
            mottos.Add(74, "Important things should be done before lesser things.");
            mottos.Add(75, "If it isn't broken, it doesn't need fixing.");
            mottos.Add(76, "You can expect safety in numbers.");
            mottos.Add(77, "Personal physical limitations are meant to be pushed.");
            mottos.Add(78, "Gold can fill the emptiness in your heart.");
            mottos.Add(79, "Threats are good bluffs to get what you want.");
            mottos.Add(80, "Always be yourself.");
            mottos.Add(81, "Keep your thoughts to yourself.");
            mottos.Add(82, "Never count your chickens before they've hatched.");
            mottos.Add(83, "The journey of true love is never easy.");
            mottos.Add(84, "It is best to live and fight another day.");
            mottos.Add(85, "Pleasure should be sought for at all costs.");
            mottos.Add(86, "Friends should be used for what they provide.");
            mottos.Add(87, "Those trying to improve mentally, physically, or spiritually should be encourgaed.");
            mottos.Add(88, "A little criticism goes a long way with others.");
            mottos.Add(89, "Money can always be saved even on a small income.");
            mottos.Add(90, "Relaxation is not the way to obtain happiness.");
            mottos.Add(91, "The right thing should always be done.");
            mottos.Add(92, "Try to understand the world through other peoples' eyes.");
            mottos.Add(93, "Additional training is always a good thing.");
            mottos.Add(94, "Don't always spend your time aiming; you need to shoot eventually.");
            mottos.Add(95, "Be mysterious can be a good thing.");
            mottos.Add(96, "Being treated poorly by others is no excuse to treat them poorly.");
            mottos.Add(97, "Constant time spent on self-improvement can be considered anti-social.");
            mottos.Add(98, "Honey catches more flies than vinegar.");
            mottos.Add(99, "Other's confidence in you should never be betrayed.");
            mottos.Add(100, "Punishments should always fit the crime.");
            mottos.Add(101, "There's never a good enough reason why you can't do something.");
            mottos.Add(102, "Winning doesn't require boasting.");
            mottos.Add(103, "Family traditions are to be kept alive.");
            mottos.Add(104, "Debts need to be repaid.");
            mottos.Add(105, "Power is the ultimate aspiration.");
            mottos.Add(106, "Don't bite off more than you can chew.");
            mottos.Add(107, "You can never be too joyfull.");
            mottos.Add(108, "Help friends in order to help yourself.");
            mottos.Add(109, "Never forget those who love you.");
            mottos.Add(110, "Knowledge is power.");
            mottos.Add(111, "Never abandon a fight.");
            mottos.Add(112, "Fight fire with fire.");
            mottos.Add(113, "Don't make mountains out of molehills.");
            mottos.Add(114, "Allow for imperfection.");
            mottos.Add(115, "The future of your life is not worth getting worried about.");
            mottos.Add(116, "The desire to learn new things is godly.");
            mottos.Add(117, "Hasteful actions should be decided on slowly.");
            mottos.Add(118, "Rules and laws were made to be broken.");
            mottos.Add(119, "Never throw pearls before swine.");
            mottos.Add(120, "Books are the path to knowledge.");
            mottos.Add(121, "Decisions and values are both the same.");
            mottos.Add(122, "Being in comfort is not necessarily being happy.");
            mottos.Add(123, "The elderly are old jewels to be cared for.");
            mottos.Add(124, "Be ready for surprises.");
            mottos.Add(125, "Don't go looking for trouble because trouble is already looking for you.");
            mottos.Add(126, "Don't waste time waiting for inspiration.");
            mottos.Add(127, "You can't help loving those who don't deserve it.");
            mottos.Add(128, "Criticism is to be ignored.");
            mottos.Add(129, "Traveling fast is best done alone.");
            mottos.Add(130, "When ever something is done for some one else, he/she now owes you.");
            mottos.Add(131, "Volunteering helps support the backbone of a community.");
            mottos.Add(132, "A victory can't be claimed until the battle is over.");
            mottos.Add(133, "A penny saved is a penny earned.");
            mottos.Add(134, "Prejudice of any type is unacceptable aond condemable.");
            mottos.Add(135, "You must assume responsibility for your actions.");
            mottos.Add(136, "Actions speak louder than words.");
            mottos.Add(137, "Adventures are what make you tick.");
            mottos.Add(138, "You should rather to be lucky than rich.");
            mottos.Add(139, "Little disputes should not get in the way of friendships.");
            mottos.Add(140, "One of the most powerful medicines is hope and positive thinking.");
            mottos.Add(141, "Never confuse foolishness with bravery.");
            mottos.Add(142, "Many hands make light work.");
            mottos.Add(143, "Unacceptable behavior is acceptable.");
            mottos.Add(144, "Credit should be given where credit is due.");
            mottos.Add(145, "Never trust anyone.");
            mottos.Add(146, "Suckers should be scammed out of all that you can possibly get from them.");
            mottos.Add(147, "Toil is not a redeeming virtue.");
            mottos.Add(148, "The lesser of two evils should always be chosen.");
            mottos.Add(149, "Ignorant thinking only gets worse with time.");
        }

        //Saves user settings.
        private void CharacterCreationTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.FormLocation = this.Location;
            Properties.Settings.Default.GenerateAmount = amountGeneratedNumeric.Value;
            Properties.Settings.Default.LowerAge = lowerAgeRangeTxt.Text;
            Properties.Settings.Default.HigherAge = higherAgeRangeTxt.Text;
            Properties.Settings.Default.Save();
        }

        //Lets user know that they can't change the amount of mottos generated.
        private void mottosRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (mottosRadio.Checked)
                amountGeneratedNumeric.Enabled = false;
            else
                amountGeneratedNumeric.Enabled = true;
        }
    }
}
