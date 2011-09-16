namespace RandChar
{
    partial class CharacterCreationTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CharacterCreationTool));
            this.label1 = new System.Windows.Forms.Label();
            this.likesRadio = new System.Windows.Forms.RadioButton();
            this.personalityRadio = new System.Windows.Forms.RadioButton();
            this.skillsRadio = new System.Windows.Forms.RadioButton();
            this.generateBtn = new System.Windows.Forms.Button();
            this.resultPosibilitiesLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.amountGeneratedNumeric = new System.Windows.Forms.NumericUpDown();
            this.lowerAgeRangeTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.higherAgeRangeTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.generateAgeBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ageResultTxt = new System.Windows.Forms.TextBox();
            this.mottosRadio = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountGeneratedNumeric)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please select what to generate.";
            // 
            // likesRadio
            // 
            this.likesRadio.AutoSize = true;
            this.likesRadio.Checked = true;
            this.likesRadio.Location = new System.Drawing.Point(12, 52);
            this.likesRadio.Name = "likesRadio";
            this.likesRadio.Size = new System.Drawing.Size(91, 17);
            this.likesRadio.TabIndex = 1;
            this.likesRadio.TabStop = true;
            this.likesRadio.Text = "Likes/Dislikes";
            this.likesRadio.UseVisualStyleBackColor = true;
            // 
            // personalityRadio
            // 
            this.personalityRadio.AutoSize = true;
            this.personalityRadio.Location = new System.Drawing.Point(109, 52);
            this.personalityRadio.Name = "personalityRadio";
            this.personalityRadio.Size = new System.Drawing.Size(105, 17);
            this.personalityRadio.TabIndex = 2;
            this.personalityRadio.Text = "Personality Traits";
            this.personalityRadio.UseVisualStyleBackColor = true;
            // 
            // skillsRadio
            // 
            this.skillsRadio.AutoSize = true;
            this.skillsRadio.Location = new System.Drawing.Point(220, 52);
            this.skillsRadio.Name = "skillsRadio";
            this.skillsRadio.Size = new System.Drawing.Size(116, 17);
            this.skillsRadio.TabIndex = 3;
            this.skillsRadio.Text = "Skills/Weaknesses";
            this.skillsRadio.UseVisualStyleBackColor = true;
            // 
            // generateBtn
            // 
            this.generateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateBtn.Location = new System.Drawing.Point(220, 118);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(324, 43);
            this.generateBtn.TabIndex = 4;
            this.generateBtn.Text = "Generate";
            this.generateBtn.UseVisualStyleBackColor = true;
            this.generateBtn.Click += new System.EventHandler(this.generateBtn_Click);
            // 
            // resultPosibilitiesLbl
            // 
            this.resultPosibilitiesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultPosibilitiesLbl.Location = new System.Drawing.Point(6, 217);
            this.resultPosibilitiesLbl.Name = "resultPosibilitiesLbl";
            this.resultPosibilitiesLbl.Size = new System.Drawing.Size(698, 108);
            this.resultPosibilitiesLbl.TabIndex = 5;
            this.resultPosibilitiesLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(718, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 9);
            this.label2.TabIndex = 6;
            this.label2.Text = "V. 0.3";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.amountGeneratedNumeric);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 66);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "How many should be generated?";
            // 
            // amountGeneratedNumeric
            // 
            this.amountGeneratedNumeric.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.amountGeneratedNumeric.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::RandChar.Properties.Settings.Default, "GenerateAmount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.amountGeneratedNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountGeneratedNumeric.Location = new System.Drawing.Point(74, 34);
            this.amountGeneratedNumeric.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.amountGeneratedNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.amountGeneratedNumeric.Name = "amountGeneratedNumeric";
            this.amountGeneratedNumeric.ReadOnly = true;
            this.amountGeneratedNumeric.Size = new System.Drawing.Size(32, 26);
            this.amountGeneratedNumeric.TabIndex = 0;
            this.amountGeneratedNumeric.Value = global::RandChar.Properties.Settings.Default.GenerateAmount;
            // 
            // lowerAgeRangeTxt
            // 
            this.lowerAgeRangeTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lowerAgeRangeTxt.Location = new System.Drawing.Point(3, 34);
            this.lowerAgeRangeTxt.MaxLength = 3;
            this.lowerAgeRangeTxt.Name = "lowerAgeRangeTxt";
            this.lowerAgeRangeTxt.Size = new System.Drawing.Size(39, 26);
            this.lowerAgeRangeTxt.TabIndex = 11;
            this.lowerAgeRangeTxt.Text = "0";
            this.lowerAgeRangeTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.lowerAgeRangeTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numbersOnly_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(402, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Generate an age from 0 to 100 (or some other number).";
            // 
            // higherAgeRangeTxt
            // 
            this.higherAgeRangeTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.higherAgeRangeTxt.Location = new System.Drawing.Point(77, 34);
            this.higherAgeRangeTxt.MaxLength = 3;
            this.higherAgeRangeTxt.Name = "higherAgeRangeTxt";
            this.higherAgeRangeTxt.Size = new System.Drawing.Size(41, 26);
            this.higherAgeRangeTxt.TabIndex = 13;
            this.higherAgeRangeTxt.Text = "100";
            this.higherAgeRangeTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.higherAgeRangeTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numbersOnly_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(48, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "to";
            // 
            // generateAgeBtn
            // 
            this.generateAgeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateAgeBtn.Location = new System.Drawing.Point(124, 35);
            this.generateAgeBtn.Name = "generateAgeBtn";
            this.generateAgeBtn.Size = new System.Drawing.Size(134, 26);
            this.generateAgeBtn.TabIndex = 15;
            this.generateAgeBtn.Text = "Generate Age";
            this.generateAgeBtn.UseVisualStyleBackColor = true;
            this.generateAgeBtn.Click += new System.EventHandler(this.generateAgeBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.ageResultTxt);
            this.panel1.Controls.Add(this.generateAgeBtn);
            this.panel1.Controls.Add(this.lowerAgeRangeTxt);
            this.panel1.Controls.Add(this.higherAgeRangeTxt);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(342, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(416, 100);
            this.panel1.TabIndex = 16;
            // 
            // ageResultTxt
            // 
            this.ageResultTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ageResultTxt.Location = new System.Drawing.Point(289, 34);
            this.ageResultTxt.Name = "ageResultTxt";
            this.ageResultTxt.ReadOnly = true;
            this.ageResultTxt.Size = new System.Drawing.Size(100, 26);
            this.ageResultTxt.TabIndex = 16;
            this.ageResultTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mottosRadio
            // 
            this.mottosRadio.AutoSize = true;
            this.mottosRadio.Location = new System.Drawing.Point(109, 75);
            this.mottosRadio.Name = "mottosRadio";
            this.mottosRadio.Size = new System.Drawing.Size(57, 17);
            this.mottosRadio.TabIndex = 17;
            this.mottosRadio.TabStop = true;
            this.mottosRadio.Text = "Mottos";
            this.mottosRadio.UseVisualStyleBackColor = true;
            this.mottosRadio.CheckedChanged += new System.EventHandler(this.mottosRadio_CheckedChanged);
            // 
            // CharacterCreationTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 334);
            this.Controls.Add(this.mottosRadio);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.generateBtn);
            this.Controls.Add(this.skillsRadio);
            this.Controls.Add(this.personalityRadio);
            this.Controls.Add(this.likesRadio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.resultPosibilitiesLbl);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::RandChar.Properties.Settings.Default, "FormLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = global::RandChar.Properties.Settings.Default.FormLocation;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CharacterCreationTool";
            this.Text = "Character Creation Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CharacterCreationTool_FormClosing);
            this.Load += new System.EventHandler(this.CharacterCreationTool_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.amountGeneratedNumeric)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton likesRadio;
        private System.Windows.Forms.RadioButton personalityRadio;
        private System.Windows.Forms.RadioButton skillsRadio;
        private System.Windows.Forms.Button generateBtn;
        private System.Windows.Forms.Label resultPosibilitiesLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown amountGeneratedNumeric;
        private System.Windows.Forms.TextBox lowerAgeRangeTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox higherAgeRangeTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button generateAgeBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox ageResultTxt;
        private System.Windows.Forms.RadioButton mottosRadio;
    }
}

