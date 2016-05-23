namespace Project.Interfaces
{
    partial class DeleteCustomer
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
            this.RemoveCustomerFirstName = new System.Windows.Forms.TextBox();
            this.RemoveCustomerLastName = new System.Windows.Forms.TextBox();
            this.RemoveCustomerList = new System.Windows.Forms.ComboBox();
            this.searchCustomer = new System.Windows.Forms.Button();
            this.removeCustomerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name";
            // 
            // RemoveCustomerFirstName
            // 
            this.RemoveCustomerFirstName.Location = new System.Drawing.Point(143, 15);
            this.RemoveCustomerFirstName.Name = "RemoveCustomerFirstName";
            this.RemoveCustomerFirstName.Size = new System.Drawing.Size(100, 20);
            this.RemoveCustomerFirstName.TabIndex = 2;
            // 
            // RemoveCustomerLastName
            // 
            this.RemoveCustomerLastName.Location = new System.Drawing.Point(143, 64);
            this.RemoveCustomerLastName.Name = "RemoveCustomerLastName";
            this.RemoveCustomerLastName.Size = new System.Drawing.Size(100, 20);
            this.RemoveCustomerLastName.TabIndex = 3;
            // 
            // RemoveCustomerList
            // 
            this.RemoveCustomerList.FormattingEnabled = true;
            this.RemoveCustomerList.Location = new System.Drawing.Point(83, 118);
            this.RemoveCustomerList.Name = "RemoveCustomerList";
            this.RemoveCustomerList.Size = new System.Drawing.Size(121, 21);
            this.RemoveCustomerList.TabIndex = 4;
            // 
            // searchCustomer
            // 
            this.searchCustomer.Location = new System.Drawing.Point(44, 159);
            this.searchCustomer.Name = "searchCustomer";
            this.searchCustomer.Size = new System.Drawing.Size(75, 23);
            this.searchCustomer.TabIndex = 5;
            this.searchCustomer.Text = "Search";
            this.searchCustomer.UseVisualStyleBackColor = true;
            this.searchCustomer.Click += new System.EventHandler(this.searchCustomer_Click);
            // 
            // removeCustomerButton
            // 
            this.removeCustomerButton.Location = new System.Drawing.Point(168, 159);
            this.removeCustomerButton.Name = "removeCustomerButton";
            this.removeCustomerButton.Size = new System.Drawing.Size(75, 23);
            this.removeCustomerButton.TabIndex = 6;
            this.removeCustomerButton.Text = "Delete";
            this.removeCustomerButton.UseVisualStyleBackColor = true;
            this.removeCustomerButton.Click += new System.EventHandler(this.removeCustomerButton_Click);
            // 
            // DeleteCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 206);
            this.Controls.Add(this.removeCustomerButton);
            this.Controls.Add(this.searchCustomer);
            this.Controls.Add(this.RemoveCustomerList);
            this.Controls.Add(this.RemoveCustomerLastName);
            this.Controls.Add(this.RemoveCustomerFirstName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DeleteCustomer";
            this.Text = "DeleteCustomer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RemoveCustomerFirstName;
        private System.Windows.Forms.TextBox RemoveCustomerLastName;
        private System.Windows.Forms.ComboBox RemoveCustomerList;
        private System.Windows.Forms.Button searchCustomer;
        private System.Windows.Forms.Button removeCustomerButton;
    }
}