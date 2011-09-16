namespace RandChar
{
    partial class SkillsAdder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.skillsList = new System.Windows.Forms.ListBox();
            this.skillTxt = new System.Windows.Forms.RichTextBox();
            this.skillsPickedList = new System.Windows.Forms.ListBox();
            this.addSkillBtn = new System.Windows.Forms.Button();
            this.removeSkillBtn = new System.Windows.Forms.Button();
            this.skillBonusList = new System.Windows.Forms.ListBox();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.tiersTxt = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // skillsList
            // 
            this.skillsList.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.skillsList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skillsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skillsList.ForeColor = System.Drawing.Color.YellowGreen;
            this.skillsList.FormattingEnabled = true;
            this.skillsList.ItemHeight = 16;
            this.skillsList.Items.AddRange(new object[] {
            "Agility - (Tier 1)",
            "Archery - (Tier 3)",
            "Backseat Driver - (Tier 2)",
            "Basic First Aid Training - (Tier 2)",
            "Basic First Aid Training - (Tier 3)",
            "Basic First Aid Training - (Tier 4)",
            "Basic First Aid Training - (Tier 5)",
            "Biker - (Tier 1)",
            "Biker - (Tier 2)",
            "Biker - (Tier 3)",
            "Biker - (Tier 4)",
            "Biker - (Tier 5)",
            "Bilingual - (Tier 1)",
            "Bilingual - (Tier 2)",
            "Bilingual - (Tier 3)",
            "Bilingual - (Tier 4)",
            "Bilingual - (Tier 5)",
            "Billy Goat - (Tier 1)",
            "BMX - (Tier 1)",
            "BMX - (Tier 2)",
            "BMX - (Tier 3)",
            "BMX - (Tier 4)",
            "BMX - (Tier 5)",
            "Bo Staff - (Tier 4)",
            "Brawler - (Tier 3)",
            "Martial Artist - (Tier 3)"});
            this.skillsList.Location = new System.Drawing.Point(354, 47);
            this.skillsList.Name = "skillsList";
            this.skillsList.Size = new System.Drawing.Size(255, 164);
            this.skillsList.TabIndex = 30;
            this.skillsList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.skillsList_DrawItem);
            this.skillsList.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // skillTxt
            // 
            this.skillTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.skillTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skillTxt.ForeColor = System.Drawing.Color.LimeGreen;
            this.skillTxt.Location = new System.Drawing.Point(12, 217);
            this.skillTxt.Name = "skillTxt";
            this.skillTxt.ReadOnly = true;
            this.skillTxt.Size = new System.Drawing.Size(488, 134);
            this.skillTxt.TabIndex = 38;
            this.skillTxt.Text = "";
            // 
            // skillsPickedList
            // 
            this.skillsPickedList.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.skillsPickedList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skillsPickedList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skillsPickedList.ForeColor = System.Drawing.Color.YellowGreen;
            this.skillsPickedList.FormattingEnabled = true;
            this.skillsPickedList.ItemHeight = 16;
            this.skillsPickedList.Location = new System.Drawing.Point(12, 47);
            this.skillsPickedList.Name = "skillsPickedList";
            this.skillsPickedList.Size = new System.Drawing.Size(255, 164);
            this.skillsPickedList.TabIndex = 39;
            this.skillsPickedList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.skillsList_DrawItem);
            this.skillsPickedList.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // addSkillBtn
            // 
            this.addSkillBtn.Location = new System.Drawing.Point(273, 47);
            this.addSkillBtn.Name = "addSkillBtn";
            this.addSkillBtn.Size = new System.Drawing.Size(75, 23);
            this.addSkillBtn.TabIndex = 40;
            this.addSkillBtn.Text = "Add";
            this.addSkillBtn.UseVisualStyleBackColor = true;
            this.addSkillBtn.Click += new System.EventHandler(this.addSkillBtn_Click);
            // 
            // removeSkillBtn
            // 
            this.removeSkillBtn.Location = new System.Drawing.Point(273, 76);
            this.removeSkillBtn.Name = "removeSkillBtn";
            this.removeSkillBtn.Size = new System.Drawing.Size(75, 23);
            this.removeSkillBtn.TabIndex = 41;
            this.removeSkillBtn.Text = "Remove";
            this.removeSkillBtn.UseVisualStyleBackColor = true;
            this.removeSkillBtn.Click += new System.EventHandler(this.removeSkillBtn_Click);
            // 
            // skillBonusList
            // 
            this.skillBonusList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.skillBonusList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skillBonusList.ForeColor = System.Drawing.Color.LimeGreen;
            this.skillBonusList.FormattingEnabled = true;
            this.skillBonusList.ItemHeight = 16;
            this.skillBonusList.Location = new System.Drawing.Point(506, 217);
            this.skillBonusList.Name = "skillBonusList";
            this.skillBonusList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.skillBonusList.Size = new System.Drawing.Size(370, 132);
            this.skillBonusList.TabIndex = 42;
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okBtn.Location = new System.Drawing.Point(12, 357);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(488, 43);
            this.okBtn.TabIndex = 43;
            this.okBtn.Text = "Okay";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(506, 355);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(370, 43);
            this.cancelBtn.TabIndex = 44;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(127, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(155, 17);
            this.label14.TabIndex = 47;
            this.label14.Text = "tiers of skills remaining.";
            // 
            // tiersTxt
            // 
            this.tiersTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.tiersTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiersTxt.ForeColor = System.Drawing.Color.LimeGreen;
            this.tiersTxt.Location = new System.Drawing.Point(90, 12);
            this.tiersTxt.MaxLength = 2;
            this.tiersTxt.Name = "tiersTxt";
            this.tiersTxt.ReadOnly = true;
            this.tiersTxt.Size = new System.Drawing.Size(31, 29);
            this.tiersTxt.TabIndex = 46;
            this.tiersTxt.Text = "5";
            this.tiersTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(12, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 17);
            this.label15.TabIndex = 45;
            this.label15.Text = "You have ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RandChar.Properties.Resources.girl;
            this.pictureBox1.Location = new System.Drawing.Point(615, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(262, 199);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 48;
            this.pictureBox1.TabStop = false;
            // 
            // SkillsAdder
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(888, 411);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tiersTxt);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.skillBonusList);
            this.Controls.Add(this.removeSkillBtn);
            this.Controls.Add(this.addSkillBtn);
            this.Controls.Add(this.skillsPickedList);
            this.Controls.Add(this.skillTxt);
            this.Controls.Add(this.skillsList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SkillsAdder";
            this.Text = "Skill Adder & Remover";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox skillsList;
        private System.Windows.Forms.RichTextBox skillTxt;
        private System.Windows.Forms.ListBox skillsPickedList;
        private System.Windows.Forms.Button addSkillBtn;
        private System.Windows.Forms.Button removeSkillBtn;
        private System.Windows.Forms.ListBox skillBonusList;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tiersTxt;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}