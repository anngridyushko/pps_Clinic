namespace Clinic.UI
{
    partial class SignUpForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwTextBox = new System.Windows.Forms.TextBox();
            this.passwRepeatTextBox = new System.Windows.Forms.TextBox();
            this.singUp = new System.Windows.Forms.Button();
            this.doctorButton = new System.Windows.Forms.RadioButton();
            this.registrarButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(348, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(351, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(348, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(351, 301);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Confirm password";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(351, 176);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 22);
            this.nameTextBox.TabIndex = 4;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(351, 221);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(100, 22);
            this.usernameTextBox.TabIndex = 5;
            this.usernameTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // passwTextBox
            // 
            this.passwTextBox.Location = new System.Drawing.Point(351, 266);
            this.passwTextBox.Name = "passwTextBox";
            this.passwTextBox.Size = new System.Drawing.Size(100, 22);
            this.passwTextBox.TabIndex = 6;
            // 
            // passwRepeatTextBox
            // 
            this.passwRepeatTextBox.Location = new System.Drawing.Point(351, 321);
            this.passwRepeatTextBox.Name = "passwRepeatTextBox";
            this.passwRepeatTextBox.Size = new System.Drawing.Size(100, 22);
            this.passwRepeatTextBox.TabIndex = 7;
            // 
            // singUp
            // 
            this.singUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.singUp.Location = new System.Drawing.Point(354, 359);
            this.singUp.Name = "singUp";
            this.singUp.Size = new System.Drawing.Size(75, 23);
            this.singUp.TabIndex = 8;
            this.singUp.Text = "Sign up";
            this.singUp.UseVisualStyleBackColor = false;
            this.singUp.Click += new System.EventHandler(this.singUp_Click);
            // 
            // doctorButton
            // 
            this.doctorButton.AutoSize = true;
            this.doctorButton.Checked = true;
            this.doctorButton.Location = new System.Drawing.Point(354, 96);
            this.doctorButton.Name = "doctorButton";
            this.doctorButton.Size = new System.Drawing.Size(69, 21);
            this.doctorButton.TabIndex = 9;
            this.doctorButton.TabStop = true;
            this.doctorButton.Text = "doctor";
            this.doctorButton.UseVisualStyleBackColor = true;
            this.doctorButton.CheckedChanged += new System.EventHandler(this.doctorButton_CheckedChanged);
            // 
            // registrarButton
            // 
            this.registrarButton.AutoSize = true;
            this.registrarButton.Location = new System.Drawing.Point(354, 123);
            this.registrarButton.Name = "registrarButton";
            this.registrarButton.Size = new System.Drawing.Size(81, 21);
            this.registrarButton.TabIndex = 10;
            this.registrarButton.TabStop = true;
            this.registrarButton.Text = "registrat";
            this.registrarButton.UseVisualStyleBackColor = true;
            this.registrarButton.CheckedChanged += new System.EventHandler(this.registrarButton_CheckedChanged);
            // 
            // SignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(818, 497);
            this.Controls.Add(this.registrarButton);
            this.Controls.Add(this.doctorButton);
            this.Controls.Add(this.singUp);
            this.Controls.Add(this.passwRepeatTextBox);
            this.Controls.Add(this.passwTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SignUpForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwTextBox;
        private System.Windows.Forms.TextBox passwRepeatTextBox;
        private System.Windows.Forms.Button singUp;
        private System.Windows.Forms.RadioButton doctorButton;
        private System.Windows.Forms.RadioButton registrarButton;
    }
}