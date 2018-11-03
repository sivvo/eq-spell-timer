namespace EQ_Parser
{
    partial class spellbar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblspellname = new System.Windows.Forms.Label();
            this.progress = new ColorProgressBar.ColorProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbltimeleft = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblspellname
            // 
            this.lblspellname.AutoSize = true;
            this.lblspellname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblspellname.Location = new System.Drawing.Point(21, 16);
            this.lblspellname.Name = "lblspellname";
            this.lblspellname.Size = new System.Drawing.Size(82, 15);
            this.lblspellname.TabIndex = 0;
            this.lblspellname.Text = "Spell Name";
            this.lblspellname.Click += new System.EventHandler(this.lblspellname_Click);
            // 
            // progress
            // 
            this.progress.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.progress.BorderColor = System.Drawing.Color.Black;
            this.progress.FillStyle = ColorProgressBar.ColorProgressBar.FillStyles.Solid;
            this.progress.Location = new System.Drawing.Point(109, 15);
            this.progress.Maximum = 100;
            this.progress.Minimum = 0;
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(136, 15);
            this.progress.Step = 10;
            this.progress.TabIndex = 1;
            this.progress.Value = 100;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbltimeleft
            // 
            this.lbltimeleft.AutoSize = true;
            this.lbltimeleft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltimeleft.Location = new System.Drawing.Point(251, 15);
            this.lbltimeleft.Name = "lbltimeleft";
            this.lbltimeleft.Size = new System.Drawing.Size(34, 15);
            this.lbltimeleft.TabIndex = 3;
            this.lbltimeleft.Text = "900s";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.lblspellname);
            this.groupBox1.Controls.Add(this.lbltimeleft);
            this.groupBox1.Controls.Add(this.progress);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 36);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 16);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // spellbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.groupBox1);
            this.Name = "spellbar";
            this.Size = new System.Drawing.Size(316, 42);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblspellname;
        private ColorProgressBar.ColorProgressBar progress;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbltimeleft;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
