using System;
using System.Drawing;
using System.Windows.Forms;

namespace RandChar
{
    public partial class FrmPersonalPandoraGenerator : Form
    {
        public FrmPersonalPandoraGenerator()
        {
            InitializeComponent();

            //Makes a custom toolstrip renderer for custom colors.
            mainMenuStrip.Renderer = new myRenderer();
        }

        //Used to provide a custom look to the mainMenuToolStrip.
        private class myRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                Rectangle menuRectangle = new Rectangle(Point.Empty, e.Item.Size);

                //Stops every menustripitem from being changed to black.
                if (!e.Item.Selected && (e.Item.ToString() == "&File" || e.Item.ToString() == 
                    "&Edit" || e.Item.ToString() == "&Help"))
                {
                    base.OnRenderMenuItemBackground(e);
                    e.Graphics.FillRectangle(Brushes.Black, menuRectangle);
                }
                //Highlights an item if it is selected.
                else if (e.Item.Selected)
                {
                    e.Graphics.FillRectangle(Brushes.DarkGreen, menuRectangle);
                    e.Graphics.DrawRectangle(Pens.Lime, 1, 0, menuRectangle.Width - 2,
                        menuRectangle.Height - 1);
                }
                //Keeps the color as normal.
                else
                    base.OnRenderMenuItemBackground(e);
            }
        }

        //Makes the seperators for the mainMenuToolStrip match the rest of the MenuItems.
        private void seperatorMenuItem_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(0, 0, 246, 6)); 
            e.Graphics.FillRectangle(Brushes.Black, new Rectangle(31, 2, 241, 2));
            e.Dispose();
        }
        
        //Opens the AboutBox form from the mainMenuToolStrip.
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAboutBox aboutBox = new FrmAboutBox();
            aboutBox.Show();
        }

        //Exits the application from the mainMenuToolStrip.
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Creates a red box with a red x until the design for a planned feature is finished.
        private void zombieCharacterRad_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Red, 10);

            e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, 156, 36));
            
            pen.Width = 3;
            e.Graphics.DrawLine(pen, -15, 0, 171, 36);
            e.Graphics.DrawLine(pen, 171, 0, -15, 36);

            e.Dispose();
            pen.Dispose();
        }

        //Creates and shows a form for creating a templete character.
        private void templeteCharacterRad_Click(object sender, EventArgs e)
        {
            FrmCharacterCreator templeteCharacter = new FrmCharacterCreator();
            templeteCharacter.Show();
        }

        private void btnCharacterCreationTool_Click(object sender, EventArgs e)
        {
            FrmCharacterCreationTool creationTool = new FrmCharacterCreationTool();
            creationTool.Show();
        }
    }
}
