namespace RandChar
{
    partial class FrmCharacterCreationTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCharacterCreationTool));
            this.label1 = new System.Windows.Forms.Label();
            this.radLikes = new System.Windows.Forms.RadioButton();
            this.radPersonality = new System.Windows.Forms.RadioButton();
            this.radSkills = new System.Windows.Forms.RadioButton();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblResultPossibilities = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numAmountGenerated = new System.Windows.Forms.NumericUpDown();
            this.txtLowerAgeRange = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHigherAgeRange = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGenAge = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAgeResult = new System.Windows.Forms.TextBox();
            this.radMottos = new System.Windows.Forms.RadioButton();
            this.btnMOD = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmountGenerated)).BeginInit();
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
            // radLikes
            // 
            this.radLikes.AutoSize = true;
            this.radLikes.Checked = true;
            this.radLikes.Location = new System.Drawing.Point(12, 52);
            this.radLikes.Name = "radLikes";
            this.radLikes.Size = new System.Drawing.Size(91, 17);
            this.radLikes.TabIndex = 1;
            this.radLikes.TabStop = true;
            this.radLikes.Text = "Likes/Dislikes";
            this.radLikes.UseVisualStyleBackColor = true;
            // 
            // radPersonality
            // 
            this.radPersonality.AutoSize = true;
            this.radPersonality.Location = new System.Drawing.Point(109, 52);
            this.radPersonality.Name = "radPersonality";
            this.radPersonality.Size = new System.Drawing.Size(105, 17);
            this.radPersonality.TabIndex = 2;
            this.radPersonality.Text = "Personality Traits";
            this.radPersonality.UseVisualStyleBackColor = true;
            // 
            // radSkills
            // 
            this.radSkills.AutoSize = true;
            this.radSkills.Location = new System.Drawing.Point(220, 52);
            this.radSkills.Name = "radSkills";
            this.radSkills.Size = new System.Drawing.Size(116, 17);
            this.radSkills.TabIndex = 3;
            this.radSkills.Text = "Skills/Weaknesses";
            this.radSkills.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(220, 118);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(324, 43);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.generateBtn_Click);
            // 
            // lblResultPossibilities
            // 
            this.lblResultPossibilities.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultPossibilities.Location = new System.Drawing.Point(6, 217);
            this.lblResultPossibilities.Name = "lblResultPossibilities";
            this.lblResultPossibilities.Size = new System.Drawing.Size(698, 108);
            this.lblResultPossibilities.TabIndex = 5;
            this.lblResultPossibilities.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(718, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 9);
            this.label2.TabIndex = 6;
            this.label2.Text = "V. 0.3.1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numAmountGenerated);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 66);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "How many should be generated?";
            // 
            // numAmountGenerated
            // 
            this.numAmountGenerated.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.numAmountGenerated.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::RandChar.Properties.Settings.Default, "GenerateAmount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numAmountGenerated.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAmountGenerated.Location = new System.Drawing.Point(74, 34);
            this.numAmountGenerated.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numAmountGenerated.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAmountGenerated.Name = "numAmountGenerated";
            this.numAmountGenerated.ReadOnly = true;
            this.numAmountGenerated.Size = new System.Drawing.Size(32, 26);
            this.numAmountGenerated.TabIndex = 0;
            this.numAmountGenerated.Value = global::RandChar.Properties.Settings.Default.GenerateAmount;
            // 
            // txtLowerAgeRange
            // 
            this.txtLowerAgeRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLowerAgeRange.Location = new System.Drawing.Point(3, 34);
            this.txtLowerAgeRange.MaxLength = 3;
            this.txtLowerAgeRange.Name = "txtLowerAgeRange";
            this.txtLowerAgeRange.Size = new System.Drawing.Size(39, 26);
            this.txtLowerAgeRange.TabIndex = 11;
            this.txtLowerAgeRange.Text = "0";
            this.txtLowerAgeRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLowerAgeRange.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numbersOnly_KeyPress);
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
            // txtHigherAgeRange
            // 
            this.txtHigherAgeRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHigherAgeRange.Location = new System.Drawing.Point(77, 34);
            this.txtHigherAgeRange.MaxLength = 3;
            this.txtHigherAgeRange.Name = "txtHigherAgeRange";
            this.txtHigherAgeRange.Size = new System.Drawing.Size(41, 26);
            this.txtHigherAgeRange.TabIndex = 13;
            this.txtHigherAgeRange.Text = "100";
            this.txtHigherAgeRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHigherAgeRange.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numbersOnly_KeyPress);
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
            // btnGenAge
            // 
            this.btnGenAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenAge.Location = new System.Drawing.Point(124, 35);
            this.btnGenAge.Name = "btnGenAge";
            this.btnGenAge.Size = new System.Drawing.Size(134, 26);
            this.btnGenAge.TabIndex = 15;
            this.btnGenAge.Text = "Generate Age";
            this.btnGenAge.UseVisualStyleBackColor = true;
            this.btnGenAge.Click += new System.EventHandler(this.generateAgeBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtAgeResult);
            this.panel1.Controls.Add(this.btnGenAge);
            this.panel1.Controls.Add(this.txtLowerAgeRange);
            this.panel1.Controls.Add(this.txtHigherAgeRange);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(342, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(416, 100);
            this.panel1.TabIndex = 16;
            // 
            // txtAgeResult
            // 
            this.txtAgeResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgeResult.Location = new System.Drawing.Point(289, 34);
            this.txtAgeResult.Name = "txtAgeResult";
            this.txtAgeResult.ReadOnly = true;
            this.txtAgeResult.Size = new System.Drawing.Size(100, 26);
            this.txtAgeResult.TabIndex = 16;
            this.txtAgeResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // radMottos
            // 
            this.radMottos.AutoSize = true;
            this.radMottos.Location = new System.Drawing.Point(109, 75);
            this.radMottos.Name = "radMottos";
            this.radMottos.Size = new System.Drawing.Size(57, 17);
            this.radMottos.TabIndex = 17;
            this.radMottos.TabStop = true;
            this.radMottos.Text = "Mottos";
            this.radMottos.UseVisualStyleBackColor = true;
            this.radMottos.CheckedChanged += new System.EventHandler(this.mottosRadio_CheckedChanged);
            // 
            // btnMOD
            // 
            this.btnMOD.Location = new System.Drawing.Point(677, 118);
            this.btnMOD.Name = "btnMOD";
            this.btnMOD.Size = new System.Drawing.Size(75, 40);
            this.btnMOD.TabIndex = 18;
            this.btnMOD.Text = "Add Possibilities";
            this.btnMOD.UseVisualStyleBackColor = true;
            this.btnMOD.Click += new System.EventHandler(this.btnMOD_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Red;
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(550, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 40);
            this.label5.TabIndex = 19;
            this.label5.Text = "Try the new MOD tool:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmCharacterCreationTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 334);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnMOD);
            this.Controls.Add(this.radMottos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.radSkills);
            this.Controls.Add(this.radPersonality);
            this.Controls.Add(this.radLikes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblResultPossibilities);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::RandChar.Properties.Settings.Default, "FormLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = global::RandChar.Properties.Settings.Default.FormLocation;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCharacterCreationTool";
            this.Text = "Character Creation Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CharacterCreationTool_FormClosing);
            this.Load += new System.EventHandler(this.CharacterCreationTool_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numAmountGenerated)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radLikes;
        private System.Windows.Forms.RadioButton radPersonality;
        private System.Windows.Forms.RadioButton radSkills;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblResultPossibilities;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numAmountGenerated;
        private System.Windows.Forms.TextBox txtLowerAgeRange;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHigherAgeRange;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGenAge;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtAgeResult;
        private System.Windows.Forms.RadioButton radMottos;
        private System.Windows.Forms.Button btnMOD;
        private System.Windows.Forms.Label label5;
    }
}

