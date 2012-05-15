namespace RandChar
{
    partial class FrmSkillsAdder
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
            this.lstSkills = new System.Windows.Forms.ListBox();
            this.txtSkill = new System.Windows.Forms.RichTextBox();
            this.lstSkillsPicked = new System.Windows.Forms.ListBox();
            this.btnAddSkill = new System.Windows.Forms.Button();
            this.btnRemoveSkill = new System.Windows.Forms.Button();
            this.lstSkillBonus = new System.Windows.Forms.ListBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTiers = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lstSkills
            // 
            this.lstSkills.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.lstSkills.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstSkills.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSkills.ForeColor = System.Drawing.Color.YellowGreen;
            this.lstSkills.FormattingEnabled = true;
            this.lstSkills.ItemHeight = 16;
            this.lstSkills.Items.AddRange(new object[] {
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
            "Caged Wisdom - (Tier 1)",
            "Calm - (Tier 1)",
            "Chemistry - (Tier 5)",
            "Climb - (Tier 3)",
            "Combat Medic - (Tier 4)",
            "Contemplative - (Tier 2)",
            "Crushing Blow - (Tier 2)",
            "Defend - (Tier 4)",
            "Early Bird - (Tier 1)",
            "Endurance - (Tier 3)",
            "Fast Shot - (Tier 3)",
            "Grenadier - (Tier 2)",
            "Gunslinger - (Tier 3)",
            "Gunsmithing - (Tier 4)",
            "Handyman - (Tier 3)",
            "Healer - (Tier 3)",
            "Healthy - (Tier 3)",
            "Heroic - (Tier 5)",
            "Hide - (Tier 1)",
            "Knife Fighter - (Tier 3)",
            "Leadership - (Tier 1)",
            "Leadership - (Tier 2)",
            "Leadership - (Tier 3)",
            "Leadership - (Tier 4)",
            "Leadership - (Tier 5)",
            "Lone Wolf - (Tier 1)",
            "Lone Wolf - (Tier 2)",
            "Marksman - (Tier 4)",
            "Martial Artist - (Tier 1)",
            "Martial Artist - (Tier 2)",
            "Martial Artist - (Tier 3)",
            "Martial Artist - (Tier 4)",
            "Martial Artist - (Tier 5)",
            "Melee Fighter - (Tier 2)",
            "Mountain Goat - (Tier 1)",
            "Mule - (Tier 1)",
            "Navigator - (Tier 3)",
            "Night Owl - (Tier 1)",
            "Offroad - (Tier 3)",
            "Pack Rat - (Tier 1)",
            "Parry - (Tier 3)",
            "Resourceful - (Tier 2)",
            "Search - (Tier 1)",
            "Search - (Tier 2)",
            "Search - (Tier 3)",
            "Search - (Tier 4)",
            "Search - (Tier 5)",
            "Sniper - (Tier 5)",
            "Steady Shot - (Tier 3)",
            "Stealthy - (Tier 3)",
            "Streetwise - (Tier 1)",
            "Streetwise - (Tier 2)",
            "Streetwise - (Tier 3)",
            "Streetwise - (Tier 4)",
            "Streetwise - (Tier 5)",
            "Stunt Driver (class) - (Tier 3)",
            "Survivalist - (Tier 4)",
            "Switch Hitter - (Tier 2)",
            "Swordsman - (Tier 4)",
            "Tactician - (Tier 5)",
            "Tough - (Tier 1)",
            "Traceur/Traceuse - (Tier 1)",
            "Traceur/Traceuse - (Tier 2)",
            "Traceur/Traceuse - (Tier 3)",
            "Traceur/Traceuse - (Tier 4)",
            "Traceur/Traceuse - (Tier 5)",
            "Trigger Discipline - (Tier 1)",
            "Trigger Discipline - (Tier 2)",
            "Trigger Discipline - (Tier 3)",
            "Trigger Discipline - (Tier 4)",
            "Trigger Discipline - (Tier 5)",
            "Warlord - (Tier 1)",
            "Weapon Tinker - (Tier 3)",
            "Woodsman - (Tier 3)"});
            this.lstSkills.Location = new System.Drawing.Point(354, 47);
            this.lstSkills.Name = "lstSkills";
            this.lstSkills.Size = new System.Drawing.Size(255, 164);
            this.lstSkills.TabIndex = 30;
            this.lstSkills.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.skillsList_DrawItem);
            this.lstSkills.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // txtSkill
            // 
            this.txtSkill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtSkill.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSkill.ForeColor = System.Drawing.Color.LimeGreen;
            this.txtSkill.Location = new System.Drawing.Point(12, 217);
            this.txtSkill.Name = "txtSkill";
            this.txtSkill.ReadOnly = true;
            this.txtSkill.Size = new System.Drawing.Size(488, 134);
            this.txtSkill.TabIndex = 38;
            this.txtSkill.Text = "";
            // 
            // lstSkillsPicked
            // 
            this.lstSkillsPicked.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.lstSkillsPicked.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstSkillsPicked.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSkillsPicked.ForeColor = System.Drawing.Color.YellowGreen;
            this.lstSkillsPicked.FormattingEnabled = true;
            this.lstSkillsPicked.ItemHeight = 16;
            this.lstSkillsPicked.Location = new System.Drawing.Point(12, 47);
            this.lstSkillsPicked.Name = "lstSkillsPicked";
            this.lstSkillsPicked.Size = new System.Drawing.Size(255, 164);
            this.lstSkillsPicked.TabIndex = 39;
            this.lstSkillsPicked.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.skillsList_DrawItem);
            this.lstSkillsPicked.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // btnAddSkill
            // 
            this.btnAddSkill.Location = new System.Drawing.Point(273, 47);
            this.btnAddSkill.Name = "btnAddSkill";
            this.btnAddSkill.Size = new System.Drawing.Size(75, 23);
            this.btnAddSkill.TabIndex = 40;
            this.btnAddSkill.Text = "Add";
            this.btnAddSkill.UseVisualStyleBackColor = true;
            this.btnAddSkill.Click += new System.EventHandler(this.addSkillBtn_Click);
            // 
            // btnRemoveSkill
            // 
            this.btnRemoveSkill.Location = new System.Drawing.Point(273, 76);
            this.btnRemoveSkill.Name = "btnRemoveSkill";
            this.btnRemoveSkill.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveSkill.TabIndex = 41;
            this.btnRemoveSkill.Text = "Remove";
            this.btnRemoveSkill.UseVisualStyleBackColor = true;
            this.btnRemoveSkill.Click += new System.EventHandler(this.removeSkillBtn_Click);
            // 
            // lstSkillBonus
            // 
            this.lstSkillBonus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lstSkillBonus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSkillBonus.ForeColor = System.Drawing.Color.LimeGreen;
            this.lstSkillBonus.FormattingEnabled = true;
            this.lstSkillBonus.ItemHeight = 16;
            this.lstSkillBonus.Location = new System.Drawing.Point(506, 217);
            this.lstSkillBonus.Name = "lstSkillBonus";
            this.lstSkillBonus.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstSkillBonus.Size = new System.Drawing.Size(370, 132);
            this.lstSkillBonus.TabIndex = 42;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(12, 357);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(488, 43);
            this.btnOk.TabIndex = 43;
            this.btnOk.Text = "Okay";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(506, 355);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(370, 43);
            this.btnCancel.TabIndex = 44;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
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
            // txtTiers
            // 
            this.txtTiers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtTiers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTiers.ForeColor = System.Drawing.Color.LimeGreen;
            this.txtTiers.Location = new System.Drawing.Point(90, 12);
            this.txtTiers.MaxLength = 2;
            this.txtTiers.Name = "txtTiers";
            this.txtTiers.ReadOnly = true;
            this.txtTiers.Size = new System.Drawing.Size(31, 29);
            this.txtTiers.TabIndex = 46;
            this.txtTiers.Text = "5";
            this.txtTiers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // FrmSkillsAdder
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(888, 411);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtTiers);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lstSkillBonus);
            this.Controls.Add(this.btnRemoveSkill);
            this.Controls.Add(this.btnAddSkill);
            this.Controls.Add(this.lstSkillsPicked);
            this.Controls.Add(this.txtSkill);
            this.Controls.Add(this.lstSkills);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmSkillsAdder";
            this.Text = "Skill Adder & Remover";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstSkills;
        private System.Windows.Forms.RichTextBox txtSkill;
        private System.Windows.Forms.ListBox lstSkillsPicked;
        private System.Windows.Forms.Button btnAddSkill;
        private System.Windows.Forms.Button btnRemoveSkill;
        private System.Windows.Forms.ListBox lstSkillBonus;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTiers;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}