namespace RandChar
{
    partial class FrmCharCreateToolMod
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
            this.radMottos = new System.Windows.Forms.RadioButton();
            this.radSkills = new System.Windows.Forms.RadioButton();
            this.radPersonality = new System.Windows.Forms.RadioButton();
            this.radLikes = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewPossibility = new System.Windows.Forms.TextBox();
            this.btnAddPossibility = new System.Windows.Forms.Button();
            this.lstNewlyAddedPossibilities = new System.Windows.Forms.ListBox();
            this.btnRemovePossibility = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radMottos
            // 
            this.radMottos.AutoSize = true;
            this.radMottos.Location = new System.Drawing.Point(12, 55);
            this.radMottos.Name = "radMottos";
            this.radMottos.Size = new System.Drawing.Size(57, 17);
            this.radMottos.TabIndex = 21;
            this.radMottos.TabStop = true;
            this.radMottos.Text = "Mottos";
            this.radMottos.UseVisualStyleBackColor = true;
            this.radMottos.CheckedChanged += new System.EventHandler(this.radMottos_CheckedChanged);
            // 
            // radSkills
            // 
            this.radSkills.AutoSize = true;
            this.radSkills.Location = new System.Drawing.Point(109, 55);
            this.radSkills.Name = "radSkills";
            this.radSkills.Size = new System.Drawing.Size(116, 17);
            this.radSkills.TabIndex = 20;
            this.radSkills.Text = "Skills/Weaknesses";
            this.radSkills.UseVisualStyleBackColor = true;
            this.radSkills.CheckedChanged += new System.EventHandler(this.radSkills_CheckedChanged);
            // 
            // radPersonality
            // 
            this.radPersonality.AutoSize = true;
            this.radPersonality.Location = new System.Drawing.Point(109, 32);
            this.radPersonality.Name = "radPersonality";
            this.radPersonality.Size = new System.Drawing.Size(105, 17);
            this.radPersonality.TabIndex = 19;
            this.radPersonality.Text = "Personality Traits";
            this.radPersonality.UseVisualStyleBackColor = true;
            this.radPersonality.CheckedChanged += new System.EventHandler(this.radPersonality_CheckedChanged);
            // 
            // radLikes
            // 
            this.radLikes.AutoSize = true;
            this.radLikes.Checked = true;
            this.radLikes.Location = new System.Drawing.Point(12, 32);
            this.radLikes.Name = "radLikes";
            this.radLikes.Size = new System.Drawing.Size(91, 17);
            this.radLikes.TabIndex = 18;
            this.radLikes.TabStop = true;
            this.radLikes.Text = "Likes/Dislikes";
            this.radLikes.UseVisualStyleBackColor = true;
            this.radLikes.CheckedChanged += new System.EventHandler(this.radLikes_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Please select a category to add to.";
            // 
            // txtNewPossibility
            // 
            this.txtNewPossibility.Location = new System.Drawing.Point(12, 78);
            this.txtNewPossibility.Name = "txtNewPossibility";
            this.txtNewPossibility.Size = new System.Drawing.Size(213, 20);
            this.txtNewPossibility.TabIndex = 23;
            this.txtNewPossibility.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewPossibility_KeyPress);
            // 
            // btnAddPossibility
            // 
            this.btnAddPossibility.Location = new System.Drawing.Point(231, 76);
            this.btnAddPossibility.Name = "btnAddPossibility";
            this.btnAddPossibility.Size = new System.Drawing.Size(107, 23);
            this.btnAddPossibility.TabIndex = 24;
            this.btnAddPossibility.Text = "Add";
            this.btnAddPossibility.UseVisualStyleBackColor = true;
            this.btnAddPossibility.Click += new System.EventHandler(this.btnAddPossibility_Click);
            // 
            // lstNewlyAddedPossibilities
            // 
            this.lstNewlyAddedPossibilities.FormattingEnabled = true;
            this.lstNewlyAddedPossibilities.Location = new System.Drawing.Point(12, 104);
            this.lstNewlyAddedPossibilities.Name = "lstNewlyAddedPossibilities";
            this.lstNewlyAddedPossibilities.Size = new System.Drawing.Size(213, 134);
            this.lstNewlyAddedPossibilities.TabIndex = 25;
            // 
            // btnRemovePossibility
            // 
            this.btnRemovePossibility.Location = new System.Drawing.Point(231, 105);
            this.btnRemovePossibility.Name = "btnRemovePossibility";
            this.btnRemovePossibility.Size = new System.Drawing.Size(107, 23);
            this.btnRemovePossibility.TabIndex = 26;
            this.btnRemovePossibility.Text = "Remove";
            this.btnRemovePossibility.UseVisualStyleBackColor = true;
            this.btnRemovePossibility.Click += new System.EventHandler(this.btnRemovePossibility_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(231, 213);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 27;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(312, 213);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmCharCreateToolMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 248);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnRemovePossibility);
            this.Controls.Add(this.lstNewlyAddedPossibilities);
            this.Controls.Add(this.btnAddPossibility);
            this.Controls.Add(this.txtNewPossibility);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radMottos);
            this.Controls.Add(this.radSkills);
            this.Controls.Add(this.radPersonality);
            this.Controls.Add(this.radLikes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCharCreateToolMod";
            this.ShowIcon = false;
            this.Text = "Character Creation Mod Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radMottos;
        private System.Windows.Forms.RadioButton radSkills;
        private System.Windows.Forms.RadioButton radPersonality;
        private System.Windows.Forms.RadioButton radLikes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNewPossibility;
        private System.Windows.Forms.Button btnAddPossibility;
        private System.Windows.Forms.ListBox lstNewlyAddedPossibilities;
        private System.Windows.Forms.Button btnRemovePossibility;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}