namespace Project
{
    partial class Add_Coach
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.addCoachFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.addCoachLastNameTextBox = new System.Windows.Forms.TextBox();
            this.addCoachColour = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Coach First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Coach Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Coach Colour";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(97, 121);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // addCoachFirstNameTextBox
            // 
            this.addCoachFirstNameTextBox.Location = new System.Drawing.Point(151, 6);
            this.addCoachFirstNameTextBox.Name = "addCoachFirstNameTextBox";
            this.addCoachFirstNameTextBox.Size = new System.Drawing.Size(121, 20);
            this.addCoachFirstNameTextBox.TabIndex = 5;
            // 
            // addCoachLastNameTextBox
            // 
            this.addCoachLastNameTextBox.Location = new System.Drawing.Point(151, 38);
            this.addCoachLastNameTextBox.Name = "addCoachLastNameTextBox";
            this.addCoachLastNameTextBox.Size = new System.Drawing.Size(120, 20);
            this.addCoachLastNameTextBox.TabIndex = 6;
            // 
            // addCoachColour
            // 
            this.addCoachColour.Location = new System.Drawing.Point(151, 70);
            this.addCoachColour.Name = "addCoachColour";
            this.addCoachColour.Size = new System.Drawing.Size(120, 20);
            this.addCoachColour.TabIndex = 7;
            this.addCoachColour.Click += new System.EventHandler(this.addCoachColour_Click);
            // 
            // Add_Coach
            // 
            this.ClientSize = new System.Drawing.Size(284, 166);
            this.Controls.Add(this.addCoachColour);
            this.Controls.Add(this.addCoachLastNameTextBox);
            this.Controls.Add(this.addCoachFirstNameTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Add_Coach";
            this.Text = "Add Coach";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox addCoachFirstNameTextBox;
        private System.Windows.Forms.TextBox addCoachLastNameTextBox;
        private System.Windows.Forms.TextBox addCoachColour;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}