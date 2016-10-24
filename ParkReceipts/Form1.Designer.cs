using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ParkReceipts
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        private RichTextBox statusRTB;

        private Label label1;

        private TextBox UserTxtBox;

        private Label label2;

        private TextBox PwdTxtBox;

        private TextBox FileTxtBox;

        private Label label3;

        private Button button1;

        private Button button2;

        private OpenFileDialog openFileDialog1;

        private Button button3;

        private Label label4;

        private TextBox destFolderTxtBox;

        private FolderBrowserDialog folderBrowserDialog1;

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
            this.statusRTB = new RichTextBox();
            this.label1 = new Label();
            this.UserTxtBox = new TextBox();
            this.label2 = new Label();
            this.PwdTxtBox = new TextBox();
            this.FileTxtBox = new TextBox();
            this.label3 = new Label();
            this.button1 = new Button();
            this.button2 = new Button();
            this.openFileDialog1 = new OpenFileDialog();
            this.button3 = new Button();
            this.label4 = new Label();
            this.destFolderTxtBox = new TextBox();
            this.folderBrowserDialog1 = new FolderBrowserDialog();
            base.SuspendLayout();
            this.statusRTB.Enabled = false;
            this.statusRTB.Location = new Point(12, 153);
            this.statusRTB.Name = "statusRTB";
            this.statusRTB.Size = new Size(527, 252);
            this.statusRTB.TabIndex = 0;
            this.statusRTB.Text = "";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(75, 15);
            this.label1.Name = "label1";
            this.label1.Size = new Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "User";
            this.UserTxtBox.Location = new Point(110, 12);
            this.UserTxtBox.Name = "UserTxtBox";
            this.UserTxtBox.Size = new Size(150, 20);
            this.UserTxtBox.TabIndex = 2;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(51, 45);
            this.label2.Name = "label2";
            this.label2.Size = new Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            this.PwdTxtBox.Location = new Point(110, 42);
            this.PwdTxtBox.Name = "PwdTxtBox";
            this.PwdTxtBox.Size = new Size(150, 20);
            this.PwdTxtBox.TabIndex = 4;
            this.PwdTxtBox.UseSystemPasswordChar = true;
            this.FileTxtBox.Enabled = false;
            this.FileTxtBox.Location = new Point(110, 69);
            this.FileTxtBox.Name = "FileTxtBox";
            this.FileTxtBox.Size = new Size(344, 20);
            this.FileTxtBox.TabIndex = 5;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(55, 72);
            this.label3.Name = "label3";
            this.label3.Size = new Size(49, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Excel file";
            this.button1.Location = new Point(460, 122);
            this.button1.Name = "button1";
            this.button1.Size = new Size(79, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Start!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.button2.Location = new Point(460, 67);
            this.button2.Name = "button2";
            this.button2.Size = new Size(79, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Browse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Excel files|*.xlsx;*.xls;*.xlsm";
            this.button3.Location = new Point(460, 93);
            this.button3.Name = "button3";
            this.button3.Size = new Size(79, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Browse";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new EventHandler(this.button3_Click);
            this.label4.AutoSize = true;
            this.label4.Location = new Point(15, 98);
            this.label4.Name = "label4";
            this.label4.Size = new Size(89, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Destination folder";
            this.destFolderTxtBox.Enabled = false;
            this.destFolderTxtBox.Location = new Point(110, 95);
            this.destFolderTxtBox.Name = "destFolderTxtBox";
            this.destFolderTxtBox.Size = new Size(344, 20);
            this.destFolderTxtBox.TabIndex = 9;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(551, 416);
            base.Controls.Add(this.button3);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.destFolderTxtBox);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.FileTxtBox);
            base.Controls.Add(this.PwdTxtBox);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.UserTxtBox);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.statusRTB);
            base.Name = "Form1";
            this.Text = "Parking receipts scraper";
            base.Load += new EventHandler(this.Form1_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion
    }
}

